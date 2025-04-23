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

                    var sumMontoItem = 0m;
                    var sumMontoExento = 0m;

                    List<ECFItem> items = new List<ECFItem>();
                    foreach (DataRow itemRow in datos.Rows)
                    {
                        var descuentoMontoIsVsible = Math.Round(Convert.ToDecimal(itemRow["DescuentoMonto"].ToString()), 2) > 0 ? true : false;

                        ECFItem item = new ECFItem
                        {
                            NumeroLinea = Convert.ToInt32(itemRow["NumeroLinea"].ToString()),
                            IndicadorFacturacion = Convert.ToInt32(itemRow["IndicadorFacturacion"].ToString()),
                            NombreItem = itemRow["NombreItem"].ToString(),
                            IndicadorBienoServicio = Convert.ToInt32(itemRow["IndicadorBienoServicio"].ToString()),
                            CantidadItem = Math.Round(Convert.ToDecimal(itemRow["CantidadItem"].ToString()), 2),
                            UnidadMedida = Convert.ToInt32(itemRow["UnidadMedida"].ToString()),
                            PrecioUnitarioItem = Math.Round(Convert.ToDecimal(itemRow["PrecioUnitarioItem"].ToString()), 2),
                            DescuentoMonto = Math.Round(Convert.ToDecimal(itemRow["DescuentoMonto"].ToString()), 2),
                            DescuentoMontoSpecified = descuentoMontoIsVsible,
                            MontoItem = Math.Round(Convert.ToDecimal(itemRow["MontoItem"].ToString()), 2),
                        };
                        items.Add(item);
                        sumMontoItem += item.MontoItem;
                        sumMontoExento += item.IndicadorFacturacion == 4 ? item.MontoItem : 0; // Sumar solo si el IndicadorFacturacion es 4
                    }
                    documento.DetallesItems = items.ToArray();

                    // Validar si algún item tiene IndicadorFacturacion igual a 4
                    documento.Encabezado.Totales.MontoExentoSpecified = items.Any(i => i.IndicadorFacturacion == 4);

                    // llenado de totales
                    documento.Encabezado.Totales.MontoExento = sumMontoItem;
                    documento.Encabezado.Totales.MontoTotal = sumMontoItem;

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