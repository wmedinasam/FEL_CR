using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIS_Security;

namespace DTECore.Models
{
    public class ExportInvoiceDocumentStrategy : IDocumentStrategy
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
                        TipoIngresos = row["TipoIngresos"].ToString(),
                        FechaLimitePago = row["FechaLimitePago"].ToString(),
                        TerminoPago = row["TerminoPago"].ToString(),
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
                        ContactoEntrega = row["ContactoEntrega"].ToString(),
                        DireccionEntrega = row["DireccionEntrega"].ToString(),
                        TelefonoAdicional = row["TelefonoAdicional"].ToString(),
                        FechaOrdenCompra = row["FechaOrdenCompra"].ToString(),
                        NumeroOrdenCompra = row["NumeroOrdenCompra"].ToString(),
                        CodigoInternoComprador = row["CodigoInternoComprador"].ToString(),
                    },

                    InformacionesAdicionales = new ECFEncabezadoInformacionesAdicionales
                    {
                        FechaEmbarque = row["FechaEmbarque"].ToString(),
                        NumeroEmbarque = row["NumeroEmbarque"].ToString(),
                        NumeroContenedor = row["NumeroContenedor"].ToString(),
                        NumeroReferencia = row["NumeroReferencia"].ToString(),
                        NombrePuertoEmbarque = row["NombrePuertoEmbarque"].ToString(),
                        CondicionesEntrega = row["CondicionesEntrega"].ToString(),
                        TotalFob = Convert.ToDecimal(row["TotalFob"].ToString()),
                        Seguro = Convert.ToDecimal(row["Seguro"].ToString()),
                        Flete = Convert.ToDecimal(row["Flete"].ToString()),
                        TotalCif = Convert.ToDecimal(row["TotalCif"].ToString()),
                        RegimenAduanero = row["RegimenAduanero"].ToString(),
                        NombrePuertoSalida = row["NombrePuertoSalida"].ToString(),
                        NombrePuertoDesembarque = row["NombrePuertoDesembarque"].ToString(),
                        PesoBruto = Convert.ToDecimal(row["PesoBruto"].ToString()),
                        PesoNeto = Convert.ToDecimal(row["PesoNeto"].ToString()),
                        UnidadPesoBruto = row["UnidadPesoBruto"].ToString(),
                        UnidadPesoNeto = row["UnidadPesoNeto"].ToString(),
                        CantidadBulto = Convert.ToInt32(row["CantidadBulto"].ToString()),
                        UnidadBulto = row["UnidadBulto"].ToString(),
                        UnidadVolumen = row["UnidadVolumen"].ToString(),

                    },

                    Transporte = new ECFEncabezadoTransporte
                    {
                        ViaTransporte = row["ViaTransporte"].ToString(),
                        PaisOrigen = row["PaisOrigen"].ToString(),
                        DireccionDestino = row["DireccionDestino"].ToString(),
                        PaisDestino = row["PaisDestino"].ToString(),
                        NumeroAlbaran = row["NumeroAlbaran"].ToString(),
                    },

                    Totales = new ECFEncabezadoTotales
                    {
                        MontoGravadoTotal = Convert.ToDecimal(row["MontoGravadoTotal"].ToString()),
                        MontoGravadoI3 = Convert.ToDecimal(row["MontoGravadoI3"].ToString()),
                        ITBIS3 = Convert.ToDecimal(row["ITBIS3"].ToString()),
                        TotalITBIS = Convert.ToDecimal(row["TotalITBIS"].ToString()),
                        TotalITBIS3 = Convert.ToDecimal(row["TotalITBIS3"].ToString()),
                        MontoTotal = Convert.ToDecimal(row["MontoTotal"].ToString()),
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
    }
}
