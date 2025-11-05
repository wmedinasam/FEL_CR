using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIS_Security;

namespace DTECore.Models
{
    public class CreditNoteDocumentStrategy : IDocumentStrategy
    {
        public ResponseModel<ECF> MakeDocument(DataTable datos)
        {
            ECF documento = new ECF();
            ResponseModel<ECF> response = new ResponseModel<ECF>();
            try
            {
                // Mapear los datos del DataTable a la clase ECF para una nota de crédito
                if (datos.Rows.Count > 0)
                {
                    DataRow row = datos.Rows[0];
                    var tipoEcf = Convert.ToInt32(row["TipoeCF"].ToString());

                    documento.Encabezado = new ECFEncabezado
                    {
                        Version = row["Version"].ToString(),

                        IdDoc = new ECFEncabezadoIdDoc
                        {
                            TipoeCF = Convert.ToInt32(row["TipoeCF"].ToString()),
                            eNCF = $"E{tipoEcf}{row["eNCF"].ToString().PadLeft(10, '0')}",
                            IndicadorNotaCredito = Convert.ToInt32(row["IndicadorNotaCredito"].ToString()),
                            IndicadorNotaCreditoSpecified = true,
                            IndicadorMontoGravado = row["IndicadorMontoGravado"].ToString(),
                            TipoIngresos = row["TipoIngresos"].ToString(),
                            TipoPago = row["TipoPago"].ToString(),
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

                        InformacionesAdicionales = new ECFEncabezadoInformacionesAdicionales
                        {
                            FechaEmbarque = row["FechaEmbarque"].ToString(),
                            FechaEmbarqueSpecified = row["FechaEmbarque"] != DBNull.Value,
                            NumeroEmbarque = row["NumeroEmbarque"].ToString(),
                            NumeroEmbarqueSpecified = row["NumeroEmbarque"] != DBNull.Value,
                            NumeroContenedor = row["NumeroContenedor"].ToString(),
                            NumeroContenedorSpecified = row["NumeroContenedor"] != DBNull.Value,
                            NumeroReferencia = row["NumeroReferencia"].ToString(),
                            NumeroReferenciaSpecified = row["NumeroReferencia"] != DBNull.Value,
                            NombrePuertoEmbarque = row["NombrePuertoEmbarque"].ToString(),
                            NombrePuertoEmbarqueSpecified = row["NombrePuertoEmbarque"] != DBNull.Value,
                            CondicionesEntrega = row["CondicionesEntrega"].ToString(),
                            CondicionesEntregaSpecified = row["CondicionesEntrega"] != DBNull.Value,
                            TotalFob = Convert.ToDecimal(row["TotalFob"].ToString()),
                            TotalFobSpecified = Convert.ToDecimal(row["TotalFob"].ToString()) > 0,
                            Seguro = Convert.ToDecimal(row["Seguro"].ToString()),
                            SeguroSpecified = Convert.ToDecimal(row["Seguro"].ToString()) > 0,
                            Flete = Convert.ToDecimal(row["Flete"].ToString()),
                            FleteSpecified = Convert.ToDecimal(row["Flete"].ToString()) > 0,
                            TotalCif = Convert.ToDecimal(row["TotalCif"].ToString()),
                            TotalCifSpecified = Convert.ToDecimal(row["TotalCif"].ToString()) > 0,
                            RegimenAduanero = row["RegimenAduanero"].ToString(),
                            RegimenAduaneroSpecified = row["RegimenAduanero"] != DBNull.Value,
                            NombrePuertoSalida = row["NombrePuertoSalida"].ToString(),
                            NombrePuertoSalidaSpecified = row["NombrePuertoSalida"] != DBNull.Value,
                            NombrePuertoDesembarque = row["NombrePuertoDesembarque"].ToString(),
                            NombrePuertoDesembarqueSpecified = row["NombrePuertoDesembarque"] != DBNull.Value,
                            PesoBruto = Convert.ToDecimal(row["PesoBruto"].ToString()),
                            PesoBrutoSpecified = Convert.ToDecimal(row["PesoBruto"].ToString()) > 0,
                            PesoNeto = Convert.ToDecimal(row["PesoNeto"].ToString()),
                            PesoNetoSpecified = Convert.ToDecimal(row["PesoNeto"].ToString()) > 0,
                            UnidadPesoBruto = row["UnidadPesoBruto"].ToString(),
                            UnidadPesoBrutoSpecified = row["UnidadPesoBruto"] != DBNull.Value,
                            UnidadPesoNeto = row["UnidadPesoNeto"].ToString(),
                            UnidadPesoNetoSpecified = row["UnidadPesoNeto"] != DBNull.Value,
                            CantidadBulto = Convert.ToInt32(row["CantidadBulto"].ToString()),
                            CantidadBultoSpecified = Convert.ToInt32(row["CantidadBulto"].ToString()) > 0,
                            UnidadBulto = row["UnidadBulto"].ToString(),
                            UnidadBultoSpecified = row["UnidadBulto"] != DBNull.Value,
                            UnidadVolumen = row["UnidadVolumen"].ToString(),
                            UnidadVolumenSpecified = row["UnidadVolumen"] != DBNull.Value,
                        },

                        Transporte = new ECFEncabezadoTransporte
                        {
                            ViaTransporte = row["ViaTransporte"].ToString(),
                            ViaTransporteSpecified = row["ViaTransporte"] != DBNull.Value,
                            PaisOrigen = row["PaisOrigen"].ToString(),
                            PaisOrigenSpecified = row["PaisOrigen"] != DBNull.Value,
                            DireccionDestino = row["DireccionDestino"].ToString(),
                            DireccionDestinoSpecified = row["DireccionDestino"] != DBNull.Value,
                            PaisDestino = row["PaisDestino"].ToString(),
                            PaisDestinoSpecified = row["PaisDestino"] != DBNull.Value,
                            NumeroAlbaran = row["NumeroAlbaran"].ToString(),
                            NumeroAlbaranSpecified = row["NumeroAlbaran"] != DBNull.Value,
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
                            CantidadItem = Convert.ToDecimal(itemRow["CantidadItem"].ToString()),
                            UnidadMedida = Convert.ToInt32(itemRow["UnidadMedida"].ToString()),
                            PrecioUnitarioItem = Convert.ToDecimal(itemRow["PrecioUnitarioItem"].ToString()),
                            DescuentoMonto = Math.Round(Convert.ToDecimal(itemRow["DescuentoMonto"].ToString()), 2),
                            DescuentoMontoSpecified = descuentoMontoIsVsible,
                            MontoItem = Convert.ToDecimal(itemRow["MontoItem"].ToString()),
                        };
                        items.Add(item);
                        sumMontoItem += item.MontoItem;
                        sumMontoExento += item.IndicadorFacturacion == 4 ? item.MontoItem : 0; // Sumar solo si el IndicadorFacturacion es 4
                    }
                    documento.DetallesItems = items.ToArray();

                    documento.InformacionReferencia = new ECFInformacionReferencia
                    {
                        NCFModificado = row["NCFModificado"].ToString(),
                        FechaNCFModificado = row["FechaNCFModificado"].ToString(),
                        CodigoModificacion = row["CodigoModificacion"].ToString(),
                        RazoModificacion = row["RazoModificacion"].ToString(),
                    };

                    // Validar si algún item tiene IndicadorFacturacion igual a 4
                    documento.Encabezado.Totales.MontoExentoSpecified = items.Any(i => i.IndicadorFacturacion == 4);

                    // llenado de totales
                    documento.Encabezado.Totales.MontoExento = sumMontoItem;
                    documento.Encabezado.Totales.MontoTotal = sumMontoItem + documento.Encabezado.Totales.TotalITBIS1 + documento.Encabezado.Totales.TotalITBIS3;
                }

                response.Object = documento;
                response.Success = true;
                response.Message = "Documento de factura creado y serializado correctamente.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = String.Format($"Error al crear el documento de factura exportación por: {ex.Message}");
            }

            return response;
        }
    }
}
