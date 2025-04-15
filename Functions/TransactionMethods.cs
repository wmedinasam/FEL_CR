using FELRD.Helpers;
using FELRD.Models;
using System;
using System.Collections.Generic;
using DTECore;
using System.Data;
using WIS_Security;
using DTECore.Models;
using ServiceCore.Infile.Service;
using ServiceCore.Infile.Model;

namespace FELRD
{
    public static class TransactionMethods
    {
        /// <summary>
        /// Método encargado de obtener los documentos pendientes de firmar
        /// </summary>
        /// <returns></returns>
        public static ResponseModel<List<TransactionModel>> GetPendings()
        {
            var model = new TransactionModel();
            var responseGetPendingTransactions = model.GetPendings();

            if (responseGetPendingTransactions.Success && responseGetPendingTransactions.Object.Count > 0)
            {
                return responseGetPendingTransactions;
            }

            return new ResponseModel<List<TransactionModel>>
            {
                Success = false,
                Message = "No fueron encontradas transacciones pendientes.",
                Object = new List<TransactionModel>()
            };
        }

        /// <summary>
        /// Método encargado de serializar el XML de acuerdo al tipo de documento
        /// </summary>
        /// <param name="documentType"></param>
        /// <param name="pendingDocument"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static string ReturnXml(string documentType, DataTable pendingDocument)
        {
            string xmlContent = string.Empty;
            IDocumentStrategy strategy = null;

            switch (documentType)
            {
                case "FACT":
                    strategy = new InvoiceDocumentStrategy();
                    break;
                case "FCAM":
                    strategy = new FiscalCreditInvoiceDocumentStrategy();
                    break;
                case "FEXP":
                    strategy = new ExportInvoiceDocumentStrategy();
                    break;
                default:
                    throw new ArgumentException("Tipo de documento inválido");
            }

            var response = strategy.MakeDocument(pendingDocument);
            if (!response.Success)
            {
                HandleLogs.SaveLog("Error", $"Error al serializar el documento interno: {response.Message}");
                return xmlContent;
            }
            xmlContent = Methods.SerializeObjectToXML(response.Object);
            return xmlContent;
        }

        /// <summary>
        /// Método encargado de firmar documentos
        /// </summary>
        /// <param name="document"></param>
        public static void Sign(TransactionModel document)
        {
            try
            {
                var saeDataTableResponse = SaeFelModel.GetSaeFelData(document.Company.Id, document.Subsidiary.Id, document.SAENumber, document.SAESerial, document.DocumentType, document.Company.DBSAE, document.Company.SuffixTable);
                if (saeDataTableResponse.Object.Rows.Count == 0)
                {
                    HandleLogs.SaveLog("Info", $"No se encontro data para documento interno: {document.SAESerial}-{document.SAENumber}.");
                    return;
                }

                var xmlContent = ReturnXml(document.DocumentType, saeDataTableResponse.Object);
                if (String.IsNullOrEmpty(xmlContent))
                {
                    HandleLogs.SaveLog("Error", $"Error al serializar el documento interno: {document.SAESerial}-{document.SAENumber}.");
                    return;
                }

                var requestToken = new RequestToken
                {
                    rnc = document.Company.Certificador.Nit,
                    llave = document.Company.Certificador.SecurityKey
                };

                var token = new InfileService().GetToken(document.Company.Certificador.EndPoint, document.Company.Certificador.UsuarioWS, document.Company.Certificador.PasswordWS, document.Company.Certificador.Key, requestToken);
                if (token.ToLower().Contains("error"))
                {
                    // Error al obtener token
                    HandleLogs.SaveLog("Error", "Error al obtener token.");
                    return;
                }

                var response = new InfileService().SendXmlDocument(document.Company.Certificador.EndPoint, token, xmlContent);
                if (!response.Success && response.Object.cantidad_errores > 0)
                {
                    // Transacción no firmada por algún error en el XML
                    HandleLogs.SaveLog("Error", $"Error de estructura del XML del documento interno: {document.SAESerial}-{document.SAENumber} por: {response.Message}");
                    var responseActionTransactionWithError = document.ActionTransaction("Rejected", document);
                    if (!responseActionTransactionWithError.Success)
                    {
                        HandleLogs.SaveLog("Error", $"Error actualizando la  transaction: {document.SAESerial}-{document.SAENumber} por:  {responseActionTransactionWithError.Message}");
                        return;
                    }
                    return;
                }

                document.Result = response.Object.descripcion;
                document.UUID = response.Object.solicitud_id;
                document.ReceivedStamp = response.Object.fecha.ToLongTimeString();

                // Actualizar estado a firmado de la transacción
                var responseActionPendingTransaction = document.ActionTransaction("Accepted", document);
                if (!responseActionPendingTransaction.Success)
                {
                    HandleLogs.SaveLog("Error", $"Error actualizando la  transaction: {document.SAESerial}-{document.SAENumber} por:  {responseActionPendingTransaction.Message}");
                }

            }
            catch (Exception ex)
            {
                HandleLogs.SaveLog("Error", $"Exception en método de firmado:  {ex.Message}");
                throw;
            }
        }
    }
}
