using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using WIS_Security;

namespace DTECore
{
    public class InvoiceDocumentStrategy : IDocumentStrategy
    {
        public ResponseModel<ECF> MakeDocument(DataTable datos)
        {
            ECF documento = new ECF();
            ResponseModel<ECF> response = new ResponseModel<ECF>();

            // Mapear los datos del DataTable a la clase ECF para una factura
            if (datos.Rows.Count > 0)
            {
                DataRow row = datos.Rows[0];
                documento.Encabezado = new ECFEncabezado
                {
                    Version = Convert.ToDecimal(row["Version"].ToString()),

                    IdDoc = new ECFEncabezadoIdDoc
                    {
                        TipoeCF = Convert.ToInt32(row["TipoeCF"].ToString()),
                        TipoIngresos = row["TipoIngresos"].ToString(),
                        TipoPago = row["TipoPago"].ToString()
                    },

                    Emisor = new ECFEncabezadoEmisor
                    {
                        RNCEmisor = Convert.ToUInt32(row["RNCEmisor"].ToString()),
                        RazonSocialEmisor = row["RazonSocialEmisor"].ToString(),
                        NombreComercial = row["NombreComercial"].ToString(),
                        DireccionEmisor = row["DireccionEmisor"].ToString(),
                        Municipio = row["Municipio"].ToString(),
                        Provincia = row["Provincia"].ToString(),
                        //tabla de telefonos emisor
                        CorreoEmisor = row["CorreoEmisor"].ToString(),
                        WebSite = row["WebSite"].ToString(),
                        CodigoVendedor = row["CodigoVendedor"].ToString(),
                        NumeroFacturaInterna = row["NumeroFacturaInterna"].ToString(),
                        NumeroPedidoInterno = row["NumeroPedidoInterno"].ToString(),
                        ZonaVenta = row["ZonaVenta"].ToString(),
                        FechaEmision = row["FechaEmision"].ToString(), // enviarlo como dd/MM/yyyy
                    },

                    Comprador = new ECFEncabezadoComprador
                    {
                        RNCComprador = Convert.ToUInt32(row["RNCComprador"].ToString()),
                        RazonSocialComprador = row["RazonSocialComprador"].ToString(),
                        ContactoComprador = row["ContactoComprador"].ToString(),
                        CorreoComprador = row["CorreoComprador"].ToString(),
                        DireccionComprador = row["DireccionComprador"].ToString(),
                        MunicipioComprador = row["MunicipioComprador"].ToString(),
                        ProvinciaComprador = row["ProvinciaComprador"].ToString(),
                        FechaEntrega = row["FechaEntrega"].ToString(),
                        FechaOrdenCompra = row["FechaOrdenCompra"].ToString(),
                        NumeroOrdenCompra = row["NumeroOrdenCompra"].ToString(),
                        CodigoInternoComprador = row["CodigoInternoComprador"].ToString(),
                    },
                   
                    Totales = new ECFEncabezadoTotales
                    {
                        MontoTotal = Convert.ToDecimal(row["MontoTotal"].ToString()),
                        MontoExento = Convert.ToDecimal(row["MontoExento"].ToString()),                        
                    }
                };

                List<ECFItem> items = new List<ECFItem>();
                foreach (DataRow itemRow in datos.Rows)
                {
                    ECFItem item = new ECFItem
                    {
                       NumeroLinea = Convert.ToInt32(itemRow["NumeroLinea"].ToString()),
                       IndicadorFacturacion = Convert.ToInt32(itemRow["IndicadorFacturacion"].ToString()),
                       NombreItem = itemRow["NombreItem"].ToString(),
                       IndicadorBienoServicio = Convert.ToInt32(itemRow["IndicadorBienoServicio"].ToString()),
                       CantidadItem = Convert.ToDecimal(itemRow["CantidadItem"].ToString()),
                       UnidadMedida = Convert.ToInt32(itemRow["UnidadMedida"].ToString()),
                       PrecioUnitarioItem = Convert.ToDecimal(itemRow["PrecioUnitarioItem"].ToString()),
                       MontoItem = Convert.ToDecimal(itemRow["MontoItem"].ToString()),
                    };
                    items.Add(item);
                }
                documento.DetallesItems = items.ToArray();
            }

            response.Object = documento;
            response.Success = true;
            response.Message = "Documento de factura creado y serializado correctamente.";

            return response;
        }

        public string SerializeDocument(ECF documento)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ECF));
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Encoding = new UTF8Encoding(false),
                Indent = true,
                OmitXmlDeclaration = false
            };

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (StreamWriter streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(false)))
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(streamWriter, settings))
                    {
                        serializer.Serialize(xmlWriter, documento);
                    }
                }
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }
    }
}