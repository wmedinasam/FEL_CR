using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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

            try
            {
                // Mapear los datos del DataTable a la clase ECF para una factura
                if (datos.Rows.Count > 0)
                {
                    DataRow row = datos.Rows[0];
                    var tipoEcf = Convert.ToInt32(row["TipoeCF"].ToString());
                    documento.Encabezado = new ECFEncabezado
                    {
                        Version = row["Version"].ToString(),

                        IdDoc = new ECFEncabezadoIdDoc
                        {
                            TipoeCF = tipoEcf,
                            eNCF = $"E{tipoEcf}{row["eNCF"].ToString().PadLeft(10, '0')}",
                            TipoIngresos = row["TipoIngresos"].ToString(),
                            TipoPago = row["TipoPago"].ToString(),
                            IndicadorNotaCreditoSpecified = false
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
                            WebSiteSpecified = String.IsNullOrEmpty(row["WebSite"].ToString()) ? false : true,
                            CodigoVendedor = row["CodigoVendedor"].ToString(),
                            CodigoVendedorSpecified = String.IsNullOrEmpty(row["CodigoVendedor"].ToString()) ? false : true,
                            NumeroFacturaInterna = row["NumeroFacturaInterna"].ToString(),
                            NumeroFacturaInternaSpecified = String.IsNullOrEmpty(row["NumeroFacturaInterna"].ToString()) ? false : true,
                            NumeroPedidoInterno = row["NumeroPedidoInterno"].ToString(),
                            NumeroPedidoInternoSpecified = String.IsNullOrEmpty(row["NumeroPedidoInterno"].ToString()) ? false : true,
                            ZonaVenta = row["ZonaVenta"].ToString(),
                            ZonaVentaSpecified = String.IsNullOrEmpty(row["ZonaVenta"].ToString()) ? false : true,
                            RutaVenta = row["RutaVenta"].ToString(),
                            RutaVentaSpecified = String.IsNullOrEmpty(row["RutaVenta"].ToString()) ? false : true,
                            FechaEmision = row["FechaEmision"].ToString(), // enviarlo como dd/MM/yyyy
                            FechaEmisionSpecified = String.IsNullOrEmpty(row["FechaEmision"].ToString()) ? false : true,
                            InformacionAdicionalComprador = row["InformacionAdicionalComprador"].ToString(),
                        },

                        Comprador = new ECFEncabezadoComprador
                        {
                            RNCComprador = Convert.ToUInt32(row["RNCComprador"].ToString()),
                            RazonSocialComprador = row["RazonSocialComprador"].ToString(),
                            ContactoComprador = row["ContactoComprador"].ToString(),
                            ContactoCompradorSpecified = String.IsNullOrEmpty(row["ContactoComprador"].ToString()) ? false : true,
                            CorreoComprador = row["CorreoComprador"].ToString(),
                            CorreoCompradorSpecified = String.IsNullOrEmpty(row["CorreoComprador"].ToString()) ? false : true,
                            DireccionComprador = row["DireccionComprador"].ToString(),
                            MunicipioComprador = row["MunicipioComprador"].ToString(),
                            MunicipioCompradorSpecified = String.IsNullOrEmpty(row["MunicipioComprador"].ToString()) ? false : true,
                            ProvinciaComprador = row["ProvinciaComprador"].ToString(),
                            ProvinciaCompradorSpecified = String.IsNullOrEmpty(row["ProvinciaComprador"].ToString()) ? false : true,
                            FechaEntrega = row["FechaEntrega"].ToString(),
                            FechaEntregaSpecified = String.IsNullOrEmpty(row["FechaEntrega"].ToString()) ? false : true,
                            FechaOrdenCompra = row["FechaOrdenCompra"].ToString(),
                            FechaOrdenCompraSpecified = String.IsNullOrEmpty(row["FechaOrdenCompra"].ToString()) ? false : true,
                            NumeroOrdenCompra = row["NumeroOrdenCompra"].ToString(),
                            NumeroOrdenCompraSpecified = String.IsNullOrEmpty(row["NumeroOrdenCompra"].ToString()) ? false : true,
                            CodigoInternoComprador = row["CodigoInternoComprador"].ToString(),
                            CodigoInternoCompradorSpecified = String.IsNullOrEmpty(row["CodigoInternoComprador"].ToString()) ? false : true,
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
                            TotalITBISSpecified = Convert.ToDecimal(row["TotalITBIS"].ToString()) > 0,
                            TotalITBIS1 = Convert.ToDecimal(row["TotalITBIS1"].ToString()),
                            TotalITBIS1Specified = Convert.ToDecimal(row["TotalITBIS1"].ToString()) > 0,
                            TotalITBIS3 = Convert.ToDecimal(row["TotalITBIS3"].ToString()),
                            TotalITBIS3Specified = Convert.ToDecimal(row["TotalITBIS3"].ToString()) > 0,
                            MontoTotal = Convert.ToDecimal(row["MontoTotal"].ToString()),
                            SaldoAnterior = Convert.ToDecimal(row["SaldoAnterior"].ToString()),
                            SaldoAnteriorSpecified = Convert.ToDecimal(row["SaldoAnterior"].ToString()) > 0,
                        }
                    };

                    var sumMontoItem = 0m;
                    var sumMontoExento = 0m;
                    var sumMontoImpuesto = 0m;

                    List<ECFItem> items = new List<ECFItem>();
                    var index = 1;
                    foreach (DataRow itemRow in datos.Rows)
                    {
                        var descuentoMontoIsVsible = Convert.ToDecimal(itemRow["DescuentoMonto"].ToString()) > 0 ? true : false;

                        ECFItem item = new ECFItem
                        {
                            NumeroLinea = index,
                            IndicadorFacturacion = Convert.ToInt32(itemRow["IndicadorFacturacion"].ToString()),
                            NombreItem = itemRow["NombreItem"].ToString(),
                            IndicadorBienoServicio = Convert.ToInt32(itemRow["IndicadorBienoServicio"].ToString()),
                            CantidadItem = Math.Round(Convert.ToDecimal(itemRow["CantidadItem"].ToString()), 2),
                            UnidadMedida = Convert.ToInt32(itemRow["UnidadMedida"].ToString()),
                            PrecioUnitarioItem = Convert.ToDecimal(itemRow["PrecioUnitarioItem"].ToString()),
                            DescuentoMonto = Convert.ToDecimal(itemRow["DescuentoMonto"].ToString()),
                            DescuentoMontoSpecified = descuentoMontoIsVsible,
                            MontoItem = Convert.ToDecimal(itemRow["MontoItem"].ToString()),
                        };
                        items.Add(item);
                        index++;
                        sumMontoItem += item.MontoItem;
                        sumMontoExento += item.IndicadorFacturacion == 4 ? item.MontoItem : 0; // Sumar solo si el IndicadorFacturacion es 4
                        sumMontoImpuesto += Convert.ToDecimal(itemRow["TotalITBIS"].ToString());
                    }
                    documento.DetallesItems = items.ToArray();

                    // Validar si alg�n item tiene IndicadorFacturacion igual a 4
                    documento.Encabezado.Totales.MontoExentoSpecified = items.Any(i => i.IndicadorFacturacion == 4);

                    // llenado de totales
                    documento.Encabezado.Totales.MontoExento = sumMontoItem;
                    documento.Encabezado.Totales.MontoGravadoTotal = sumMontoItem;
                    documento.Encabezado.Totales.TotalITBIS = sumMontoImpuesto;
                    documento.Encabezado.Totales.TotalITBIS1 = documento.Encabezado.Totales.TotalITBIS > 0 ? sumMontoImpuesto : 0;
                    documento.Encabezado.Totales.MontoGravadoI1 = documento.Encabezado.Totales.MontoGravadoTotal > 0 ? sumMontoItem : 0;
                    documento.Encabezado.Totales.MontoTotal = sumMontoItem + documento.Encabezado.Totales.TotalITBIS1 + documento.Encabezado.Totales.TotalITBIS3;                    
                }

                response.Object = documento;
                response.Success = true;
                response.Message = "Documento de factura creado y serializado correctamente.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = String.Format($"Error al crear el documento de factura por: {ex.Message}");
            }

            return response;
        }
    }
}