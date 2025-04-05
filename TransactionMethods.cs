using FELRD.Helpers;
using FELRD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTECore;

namespace FELRD
{
    public static class TransactionMethods
    {
        /// <summary>
        /// Método encargado de firmar cualquier documento
        /// </summary>
        public static void SignDocument()
        {
            TransactionModel model = new TransactionModel();
            var responseGetPendingTransactions = model.GetPendings();
            if (responseGetPendingTransactions.Success)
            {
                if (responseGetPendingTransactions.Object.Count > 0)
                {
                    var transaction = responseGetPendingTransactions.Object.FirstOrDefault();
                    transaction.Status = "PROCESANDO";
                    transaction.Result = string.Empty;
                    var responseActionTransactionSetProcessing = model.ActionTransaction("ChangeStatusResult", transaction);
                    if (responseActionTransactionSetProcessing.Success)
                    {
                        HandleLogs.SaveLog("Log", "Cambio de estatus realizado con existo a PENDIENTE");
                        SaeFelModel saeFelModel = new SaeFelModel();
                        var responseGetSaeFelData = saeFelModel.GetSaeFelData(transaction.Company.Id, transaction.Subsidiary.Id, transaction.SAENumber, transaction.SAESerial, transaction.DocumentType, transaction.Company.DBSAE, transaction.Company.SuffixTable);
                        if (responseGetSaeFelData.Success)
                        {
                            HandleLogs.SaveLog("Log", "Obteniendo datos del SAE");
                            //Document rDDocument = new Document();
                            //var responseDocument = rDDocument.MakeDocument(responseGetSaeFelData.Object); // crear DT con datos desde SAE
                            //if (responseDocument.Success)
                            //{
                                HandleLogs.SaveLog("Log", "Creando el JSON Request");
                                //InfileService infileService = new InfileService();
                                //    CertificadorModel cert = new CertificadorModel();
                                //    var certResponse = cert.Get(transaction.Company.Certificador.Id);
                                //    //string output = responseDocument.Object.SerializeDocument(responseDocument.Object);
                                //    //string output = DTECore.Helpers.SerializeDocument(responseDocument.Object);


                                //    HandleLogs.SaveJson(transaction.SAESerial + transaction.SAENumber, output);
                                //    var internalId = string.Format($"{transaction.SAESerial}{transaction.SAENumber}");
                                //    var responseInfileService = infileService.SignDocument(certResponse.Object.EndPointFirma, output, certResponse.Object.UsuarioWS, certResponse.Object.PasswordWS, internalId);
                                //    HandleLogs.SaveLog("Log", $"Se envió a firmar el documento: {internalId} con respuesta: {responseInfileService.Success} - {responseInfileService.Message}");
                                //    if (responseInfileService.Success)
                                //    {
                                //        HandleLogs.SaveLog("Log", "Entramos a Documento firmado con exito");
                                //        transaction.Result = responseInfileService.Message;
                                //        transaction.Status = "ACEPTADO";
                                //        transaction.UUID = responseInfileService.Object.respuesta.codigoGeneracion;
                                //        transaction.ControlNumber = responseInfileService.Object.respuesta.numeroControl;
                                //        transaction.Sign = responseInfileService.Object.json.firmaElectronica;
                                //        transaction.ReceivedStamp = responseInfileService.Object.json.selloRecibido;
                                //        // Save Response JSON to JSON path
                                //        HandleLogs.SaveJson($"Response-{transaction.SAESerial}-{transaction.SAENumber}", responseInfileService.Object.json.ToString());

                                //        var responseActionTransaction = model.ActionTransaction("Accepted", transaction);
                                //        if (!responseActionTransaction.Success)
                                //        {
                                //            HandleLogs.SaveLog("Debug", "Problemas para actualizar estatus de transaccion rechazada Serie: " + transaction.SAESerial + " y Numero: " + transaction.SAENumber + " Error: " + responseActionTransaction.Message);
                                //        }
                                //    }
                                //    else
                                //    {
                                //        HandleLogs.SaveLog("Debug", $"Error al firmar el documento {internalId}");
                                //        transaction.Result = responseInfileService.Message.Replace('{', ' ').Replace('}', ' ');
                                //        transaction.Status = "RECHAZADO";
                                //        var responseActionTransaction = model.ActionTransaction("ChangeStatusResult", transaction);

                                //        if (!responseActionTransaction.Success)
                                //        {
                                //            HandleLogs.SaveLog("Debug", "Problemas para actualizar estatus de transaccion rechazada Serie: " + transaction.SAESerial + " y Numero: " + transaction.SAENumber + " Error: " + responseActionTransaction.Message);
                                //        }
                                //    }
                                //}
                                //else
                                //{

                                //    transaction.Status = "RECHAZADO";
                                //    transaction.Result = $"Problemas para llenar objeto Serie: {transaction.SAESerial} y Numero: {transaction.SAENumber} Error: {responseDocument.Message}";
                                //    var responseActionTransactionSetReject = model.ActionTransaction("ChangeStatusResult", transaction);
                                //    HandleLogs.SaveLog("Debug", transaction.Result);
                                //}

                            //}
                            //else
                            //{
                            //    transaction.Status = "RECHAZADO";
                            //    transaction.Result = "Problemas para obtener la factura desde SAE documento con Serie: " + transaction.SAESerial + " y Numero: " + transaction.SAENumber + " Error: " + responseGetSaeFelData.Message;
                            //    var response = model.ActionTransaction("ChangeStatusResult", transaction);
                            //    HandleLogs.SaveLog("Debug", transaction.Result);
                            //}
                        }
                        else
                        {
                            HandleLogs.SaveLog("Debug", "Problemas al tomar documento con Serie: " + transaction.SAESerial + " y Numero: " + transaction.SAENumber + " Error: " + responseActionTransactionSetProcessing.Message);
                            transaction.Status = "RECHAZADO";
                            var responseActionTransactionSetReject = model.ActionTransaction("ChangeStatus", transaction);
                        }
                    }
                }
                else
                {
                    HandleLogs.SaveLog("Debug", "Problemas al obtener documentos pendientes " + responseGetPendingTransactions.Message);

                }
            }
        }

        /// <summary>
        /// Método encargado de anular cualquier documento.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool CancelDocument(int Id)
        {
            return true;
        }
    }
}
