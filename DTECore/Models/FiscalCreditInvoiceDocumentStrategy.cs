using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using WIS_Security;

namespace DTECore
{
    public class FiscalCreditInvoiceDocumentStrategy : IDocumentStrategy
    {
        public ResponseModel<ECF> MakeDocument(DataTable datos)
        {
            ECF documento = new ECF();
            ResponseModel<ECF> response = new ResponseModel<ECF>();

            // Mapear los datos del DataTable a la clase ECF para una factura de crédito fiscal
            if (datos.Rows.Count > 0)
            {
                DataRow row = datos.Rows[0];
                documento.Encabezado = new ECFEncabezado
                {
                    Version = row["Version"].ToString(),

                    IdDoc = new ECFEncabezadoIdDoc
                    {
                        TipoeCF = Convert.ToInt32(row["TipoeCF"].ToString()),
                        eNCF = row["eNCF"].ToString(),
                        FechaVencimientoSecuencia = row["FechaVencimientoSecuencia"].ToString(),
                        IndicadorMontoGravado = row["IndicadorMontoGravado"].ToString(),
                        TipoIngresos = row["TipoIngresos"].ToString(),
                        TipoPago = row["TipoPago"].ToString(),
                        TablaFormasPago = new ECFEncabezadoIdDocTablaFormasPago[] 
                        {
                            new ECFEncabezadoIdDocTablaFormasPago
                            {
                                FormaDePago = new ECFEncabezadoIdDocTablaFormasPagoFormaDePago
                                {
                                    FormaPago = row["FormaPago"].ToString(),
                                    MontoPago = Convert.ToDecimal(row["MontoPago"].ToString())
                                }
                            }                            
                        }
                    },

                    Emisor = new ECFEncabezadoEmisor
                    {
                        RNCEmisor = Convert.ToUInt32(row["RNCEmisor"].ToString()),
                        RazonSocialEmisor = row["RazonSocialEmisor"].ToString(),
                        NombreComercial = row["NombreComercial"].ToString(),
                        DireccionEmisor = row["DireccionEmisor"].ToString(),
                        Municipio = row["Municipio"].ToString(),
                        Provincia = row["Provincia"].ToString(),
                        TablaTelefonoEmisor = new string[]
                        {
                            row["TelefonoEmisor"].ToString(),
                        },
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
                        MontoGravadoTotal = Convert.ToDecimal(row["MontoGravadoTotal"].ToString()),
                        MontoGravadoTotalSpecified = Convert.ToDecimal(row["MontoGravadoTotal"].ToString()) > 0,
                        MontoGravadoI1 = Convert.ToDecimal(row["MontoGravadoI1"].ToString()),
                        MontoGravadoI1Specified = Convert.ToDecimal(row["MontoGravadoI1"].ToString()) > 0,
                        MontoGravadoI3 = Convert.ToDecimal(row["MontoGravadoI3"].ToString()),
                        MontoGravadoI3Specified = Convert.ToDecimal(row["MontoGravadoI3"].ToString()) > 0,
                        ITBIS1 = Convert.ToDecimal(row["ITBIS1"].ToString()),
                        ITBIS1Specified = Convert.ToDecimal(row["ITBIS1"].ToString()) > 0,
                        ITBIS3 = Convert.ToDecimal(row["ITBIS3"].ToString()),
                        ITBIS3Specified = Convert.ToDecimal(row["ITBIS3"].ToString()) > 0,
                        TotalITBIS = Convert.ToDecimal(row["TotalITBIS"].ToString()),
                        TotalITBIS1 = Convert.ToDecimal(row["TotalITBIS1"].ToString()),
                        TotalITBIS1Specified = Convert.ToDecimal(row["TotalITBIS1"].ToString()) > 0,
                        TotalITBIS3 = Convert.ToDecimal(row["TotalITBIS3"].ToString()),
                        TotalITBIS3Specified = Convert.ToDecimal(row["TotalITBIS3"].ToString()) > 0,
                        MontoTotal = Convert.ToDecimal(row["MontoTotal"].ToString()),
                    }
                };

                List<ECFItem> items = new List<ECFItem>();
                var index = 1;
                foreach (DataRow itemRow in datos.Rows)
                {
                    ECFItem item = new ECFItem
                    {
                        NumeroLinea = index,
                        IndicadorFacturacion = Convert.ToInt32(itemRow["IndicadorFacturacion"].ToString()),
                        NombreItem = itemRow["NombreItem"].ToString(),
                        IndicadorBienoServicio = Convert.ToInt32(itemRow["IndicadorBienoServicio"].ToString()),
                        CantidadItem = Convert.ToDecimal(itemRow["CantidadItem"].ToString()),
                        UnidadMedida = Convert.ToInt32(itemRow["UnidadMedida"].ToString()),
                        PrecioUnitarioItem = Convert.ToDecimal(itemRow["PrecioUnitarioItem"].ToString()),
                        MontoItem = Convert.ToDecimal(itemRow["MontoItem"].ToString()),
                    };
                    items.Add(item);
                    index++;
                }
                documento.DetallesItems = items.ToArray();
            }

            response.Object = documento;
            response.Success = true;
            response.Message = "Documento de factura creado y serializado correctamente.";

            return response;
        }

    }
}
