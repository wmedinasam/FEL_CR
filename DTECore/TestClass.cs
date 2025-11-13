using DTECore.Models;
using System.Data;

namespace DTECore
{
    public class TestClass
    {
        public void testInvoice()
        {
            var datos = new DataTable();
            // obtener datos del DataTable
            // fake data
            datos.Columns.Add("Version", typeof(decimal)); // cambiar según catálogo de tipo de documentos
            datos.Columns.Add("TipoeCF", typeof(int));
            datos.Columns.Add("TipoIngresos", typeof(string));
            datos.Columns.Add("TipoPago", typeof(string));
            datos.Columns.Add("eNCF", typeof(int));

            // Emisor
            datos.Columns.Add("RNCEmisor", typeof(int));
            datos.Columns.Add("RazonSocialEmisor", typeof(string));
            datos.Columns.Add("NombreComercial", typeof(string));
            datos.Columns.Add("DireccionEmisor", typeof(string));
            datos.Columns.Add("Municipio", typeof(string));
            datos.Columns.Add("Provincia", typeof(string));
            datos.Columns.Add("TelefonoEmisor", typeof(string));
            datos.Columns.Add("CorreoEmisor", typeof(string));
            datos.Columns.Add("WebSite", typeof(string));
            datos.Columns.Add("CodigoVendedor", typeof(string));
            datos.Columns.Add("NumeroFacturaInterna", typeof(string));
            datos.Columns.Add("NumeroPedidoInterno", typeof(string));
            datos.Columns.Add("ZonaVenta", typeof(string));
            datos.Columns.Add("FechaEmision", typeof(string));
            datos.Columns.Add("RutaVenta", typeof(string));
            datos.Columns.Add("InformacionAdicionalComprador", typeof(string));

            // Comprador
            datos.Columns.Add("RNCComprador", typeof(int));
            datos.Columns.Add("RazonSocialComprador", typeof(string));
            datos.Columns.Add("ContactoComprador", typeof(string));
            datos.Columns.Add("CorreoComprador", typeof(string));
            datos.Columns.Add("DireccionComprador", typeof(string));
            datos.Columns.Add("MunicipioComprador", typeof(string));
            datos.Columns.Add("ProvinciaComprador", typeof(string));
            datos.Columns.Add("FechaEntrega", typeof(string));
            datos.Columns.Add("FechaOrdenCompra", typeof(string));
            datos.Columns.Add("NumeroOrdenCompra", typeof(string));
            datos.Columns.Add("CodigoInternoComprador", typeof(string));

            // totales
            datos.Columns.Add("MontoTotal", typeof(decimal));
            datos.Columns.Add("MontoGravadoI1", typeof(decimal));
            datos.Columns.Add("MontoGravadoI3", typeof(decimal));
            datos.Columns.Add("ITBIS1", typeof(decimal));
            datos.Columns.Add("ITBIS3", typeof(decimal));
            datos.Columns.Add("TotalITBIS", typeof(decimal));
            datos.Columns.Add("TotalITBIS1", typeof(decimal));
            datos.Columns.Add("TotalITBIS3", typeof(decimal));
            datos.Columns.Add("MontoGravadoTotal", typeof(decimal));
            datos.Columns.Add("MontoExento", typeof(decimal));
            datos.Columns.Add("SaldoAnterior", typeof(decimal));

            // Detalle
            datos.Columns.Add("NumeroLinea", typeof(int));
            datos.Columns.Add("IndicadorFacturacion", typeof(int));
            datos.Columns.Add("NombreItem", typeof(string));
            datos.Columns.Add("IndicadorBienoServicio", typeof(int));
            datos.Columns.Add("CantidadItem", typeof(decimal));
            datos.Columns.Add("UnidadMedida", typeof(int));
            datos.Columns.Add("PrecioUnitarioItem", typeof(decimal));
            datos.Columns.Add("MontoItem", typeof(decimal));
            datos.Columns.Add("DescuentoMonto", typeof(decimal));

            // Agregar filas manualmente
            DataRow fila1 = datos.NewRow();
            fila1["Version"] = "1.0"; 
            fila1["TipoeCF"] = 32;
            fila1["TipoIngresos"] = "01";
            fila1["TipoPago"] = "1";
            fila1["eNCF"] = 70;
            fila1["RNCEmisor"] = "131098207";
            fila1["RazonSocialEmisor"] = "DOCUMENTOS ELECTRONICOS DE 02";
            fila1["NombreComercial"] = "DOCUMENTOS ELECTRONICOS DE 02";
            fila1["DireccionEmisor"] = "AVE. ISABEL AGUIAR NO. 269, ZONA INDUSTRIAL DE HERRERA";
            fila1["Municipio"] = "320301";
            fila1["Provincia"] = "320000";
            fila1["TelefonoEmisor"] = "32484480";
            fila1["CorreoEmisor"] = "test@test.com";
            fila1["WebSite"] = "www.test.com"; 
            fila1["CodigoVendedor"] = "AA0000000100000000010000000002000000000300000000050000000006";
            fila1["NumeroFacturaInterna"] = "123456789016";
            fila1["NumeroPedidoInterno"] = "123456789016";
            fila1["ZonaVenta"] = "NORTE";
            fila1["FechaEmision"] = "01-04-2020";
            fila1["RutaVenta"] = "";
            fila1["RNCComprador"] = "131880681";
            fila1["RazonSocialComprador"] = "DOCUMENTOS ELECTRONICOS DE 03";
            fila1["ContactoComprador"] = "MARCOS LATIPLOL";
            fila1["CorreoComprador"] = "contacto@test.com";
            fila1["DireccionComprador"] = "CALLE JACINTO DE LA CONCHA FELIZ ESQUINA 27 DE FEBRERO,FRENTE A DOMINO";
            fila1["MunicipioComprador"] = "010100"; 
            fila1["ProvinciaComprador"] = "010000";
            fila1["FechaEntrega"] = "10-10-2020"; 
            fila1["FechaOrdenCompra"] = "10-11-2018";
            fila1["NumeroOrdenCompra"] = "4500352238";
            fila1["CodigoInternoComprador"] = "10633440";
            fila1["InformacionAdicionalComprador"] = "PRUEBA DE INFORMACION ADICIONAL";

            fila1["MontoExento"] = 0;
            fila1["MontoGravadoTotal"] = 16520;
            fila1["MontoGravadoI1"] = 16520;
            fila1["MontoGravadoI3"] = 0;
            fila1["ITBIS1"] = 18;
            fila1["ITBIS3"] = 0;
            fila1["TotalITBIS"] = 18;
            fila1["TotalITBIS1"] = 18;
            fila1["TotalITBIS3"] = 0;
            fila1["MontoTotal"] = 16520;
            fila1["SaldoAnterior"] = 0;

            fila1["NumeroLinea"] = 1;
            fila1["IndicadorFacturacion"] = 1;
            fila1["NombreItem"] = "ACCESO A APLICACION";
            fila1["IndicadorBienoServicio"] = 2;
            fila1["CantidadItem"] = 7500;
            fila1["UnidadMedida"] = 47;
            fila1["PrecioUnitarioItem"] = 40;
            fila1["MontoItem"] = 300000;
            fila1["DescuentoMonto"] = 0;


            datos.Rows.Add(fila1);

            //DataRow fila2 = datos.NewRow();
            //fila2["Version"] = "1.0";
            //fila2["TipoeCF"] = 32;
            //fila2["TipoIngresos"] = "01";
            //fila2["TipoPago"] = "1";
            //fila2["RNCEmisor"] = "131098207";
            //fila2["RazonSocialEmisor"] = "DOCUMENTOS ELECTRONICOS DE 02";
            //fila2["NombreComercial"] = "DOCUMENTOS ELECTRONICOS DE 02";
            //fila2["DireccionEmisor"] = "AVE. ISABEL AGUIAR NO. 269, ZONA INDUSTRIAL DE HERRERA";
            //fila2["Municipio"] = "320301";
            //fila2["Provincia"] = "320000";
            //fila2["TelefonoEmisor"] = "809-472-7676";
            //fila2["CorreoEmisor"] = "test@test.com";
            //fila2["WebSite"] = "www.test.com";
            //fila2["CodigoVendedor"] = "AA0000000100000000010000000002000000000300000000050000000006";
            //fila2["NumeroFacturaInterna"] = "123456789016";
            //fila2["NumeroPedidoInterno"] = "123456789016";
            //fila2["ZonaVenta"] = "NORTE";
            //fila2["FechaEmision"] = "01-04-2020";
            //fila2["RNCComprador"] = "131880681";
            //fila2["RazonSocialComprador"] = "DOCUMENTOS ELECTRONICOS DE 03";
            //fila2["ContactoComprador"] = "MARCOS LATIPLOL";
            //fila2["CorreoComprador"] = "contacto@test.com";
            //fila2["DireccionComprador"] = "CALLE JACINTO DE LA CONCHA FELIZ ESQUINA 27 DE FEBRERO,FRENTE A DOMINO";
            //fila2["MunicipioComprador"] = "010100";
            //fila2["ProvinciaComprador"] = "010000";
            //fila2["FechaEntrega"] = "10-10-2020";
            //fila2["FechaOrdenCompra"] = "10-11-2018";
            //fila2["NumeroOrdenCompra"] = "4500352238";
            //fila2["CodigoInternoComprador"] = "10633440";
            //fila2["MontoExento"] = 0;
            //fila2["MontoTotal"] = 0;


            //fila2["NumeroLinea"] = 2;
            //fila2["IndicadorFacturacion"] = 1;
            //fila2["NombreItem"] = "ACCESO A APLICACION";
            //fila2["IndicadorBienoServicio"] = 2;
            //fila2["CantidadItem"] = 1;
            //fila2["UnidadMedida"] = 47;
            //fila2["PrecioUnitarioItem"] = 4000.00;
            //fila2["MontoItem"] = 3350.00;
            //fila2["DescuentoMonto"] = 700;


            //datos.Rows.Add(fila2);


            IDocumentStrategy strategy = new InvoiceDocumentStrategy();
            Document document = new Document(strategy);

            var response = document.MakeDocument(datos);            
            var xml = Methods.SerializeObjectToXML(response.Object);
            var test = xml;
        }

        public void testFiscalCreditInvoice()
        {
            var datos = new DataTable();
            // obtener datos del DataTable
            // fake data
            datos.Columns.Add("Version", typeof(decimal)); // cambiar según catálogo de tipo de documentos
            datos.Columns.Add("TipoeCF", typeof(int));
            datos.Columns.Add("eNCF", typeof(string));
            datos.Columns.Add("FechaVencimientoSecuencia", typeof(string));
            datos.Columns.Add("IndicadorMontoGravado", typeof(int));
            datos.Columns.Add("TipoIngresos", typeof(string));
            datos.Columns.Add("TipoPago", typeof(string));
            datos.Columns.Add("FormaPago", typeof(string));
            datos.Columns.Add("MontoPago", typeof(decimal));

            // Emisor
            datos.Columns.Add("RNCEmisor", typeof(int));
            datos.Columns.Add("RazonSocialEmisor", typeof(string));
            datos.Columns.Add("NombreComercial", typeof(string));
            datos.Columns.Add("DireccionEmisor", typeof(string));
            datos.Columns.Add("Municipio", typeof(string));
            datos.Columns.Add("Provincia", typeof(string));
            datos.Columns.Add("TelefonoEmisor", typeof(string));
            datos.Columns.Add("CorreoEmisor", typeof(string));
            datos.Columns.Add("WebSite", typeof(string));
            datos.Columns.Add("CodigoVendedor", typeof(string));
            datos.Columns.Add("NumeroFacturaInterna", typeof(string));
            datos.Columns.Add("NumeroPedidoInterno", typeof(string));
            datos.Columns.Add("ZonaVenta", typeof(string));
            datos.Columns.Add("FechaEmision", typeof(string));

            // Comprador
            datos.Columns.Add("RNCComprador", typeof(int));
            datos.Columns.Add("RazonSocialComprador", typeof(string));
            datos.Columns.Add("ContactoComprador", typeof(string));
            datos.Columns.Add("CorreoComprador", typeof(string));
            datos.Columns.Add("DireccionComprador", typeof(string));
            datos.Columns.Add("MunicipioComprador", typeof(string));
            datos.Columns.Add("ProvinciaComprador", typeof(string));
            datos.Columns.Add("FechaEntrega", typeof(string));
            datos.Columns.Add("FechaOrdenCompra", typeof(string));
            datos.Columns.Add("NumeroOrdenCompra", typeof(string));
            datos.Columns.Add("CodigoInternoComprador", typeof(string));

            // totales
            datos.Columns.Add("MontoTotal", typeof(decimal));
            datos.Columns.Add("MontoGravadoTotal", typeof(decimal));
            datos.Columns.Add("MontoGravadoI1", typeof(decimal));
            datos.Columns.Add("ITBIS1", typeof(decimal));
            datos.Columns.Add("TotalITBIS", typeof(decimal));
            datos.Columns.Add("TotalITBIS1", typeof(decimal));

            // Detalle
            datos.Columns.Add("NumeroLinea", typeof(int));
            datos.Columns.Add("IndicadorFacturacion", typeof(int));
            datos.Columns.Add("NombreItem", typeof(string));
            datos.Columns.Add("IndicadorBienoServicio", typeof(int));
            datos.Columns.Add("CantidadItem", typeof(decimal));
            datos.Columns.Add("UnidadMedida", typeof(int));
            datos.Columns.Add("PrecioUnitarioItem", typeof(decimal));
            datos.Columns.Add("MontoItem", typeof(decimal));

            // Agregar filas manualmente
            DataRow fila1 = datos.NewRow();
            fila1["Version"] = "1.0";
            fila1["TipoeCF"] = 32;
            fila1["eNCF"] = "E310000000401";
            fila1["FechaVencimientoSecuencia"] = "31-12-2025";
            fila1["IndicadorMontoGravado"] = 0;
            fila1["TipoIngresos"] = "01";
            fila1["TipoPago"] = "1";
            fila1["FormaPago"] = "1";
            fila1["MontoPago"] = 100.00;
            fila1["RNCEmisor"] = "132788419";
            fila1["RazonSocialEmisor"] = "DOCUMENTOS ELECTRONICOS DE 02";
            fila1["NombreComercial"] = "DOCUMENTOS ELECTRONICOS DE 02";
            fila1["DireccionEmisor"] = "AVE. ISABEL AGUIAR NO. 269, ZONA INDUSTRIAL DE HERRERA";
            fila1["Municipio"] = "320301";
            fila1["Provincia"] = "320000";
            fila1["TelefonoEmisor"] = "32484480";
            fila1["CorreoEmisor"] = "test@test.com";
            fila1["WebSite"] = "www.test.com";
            fila1["CodigoVendedor"] = "AA0000000100000000010000000002000000000300000000050000000006";
            fila1["NumeroFacturaInterna"] = "123456789016";
            fila1["NumeroPedidoInterno"] = "123456789016";
            fila1["ZonaVenta"] = "NORTE";
            fila1["FechaEmision"] = "01-04-2020";
            fila1["RNCComprador"] = "131880681";
            fila1["RazonSocialComprador"] = "DOCUMENTOS ELECTRONICOS DE 03";
            fila1["ContactoComprador"] = "MARCOS LATIPLOL";
            fila1["CorreoComprador"] = "contacto@test.com";
            fila1["DireccionComprador"] = "CALLE JACINTO DE LA CONCHA FELIZ ESQUINA 27 DE FEBRERO,FRENTE A DOMINO";
            fila1["MunicipioComprador"] = "010100";
            fila1["ProvinciaComprador"] = "010000";
            fila1["FechaEntrega"] = "10-10-2020";
            fila1["FechaOrdenCompra"] = "10-11-2018";
            fila1["NumeroOrdenCompra"] = "4500352238";
            fila1["CodigoInternoComprador"] = "10633440";
            
            fila1["MontoTotal"] = 100;
            fila1["MontoGravadoTotal"] = 101;
            fila1["MontoGravadoI1"] = 102;
            fila1["ITBIS1"] = 103;
            fila1["TotalITBIS"] = 104;
            fila1["TotalITBIS1"] = 105;

            fila1["NumeroLinea"] = 1;
            fila1["IndicadorFacturacion"] = 4;
            fila1["NombreItem"] = "LECHE";
            fila1["IndicadorBienoServicio"] = 1;
            fila1["CantidadItem"] = 7500.00;
            fila1["UnidadMedida"] = 47;
            fila1["PrecioUnitarioItem"] = 40.00;
            fila1["MontoItem"] = 300000.00;


            datos.Rows.Add(fila1);


            IDocumentStrategy strategy = new FiscalCreditInvoiceDocumentStrategy();
            Document document = new Document(strategy);

            var response = document.MakeDocument(datos);
            string xml = Methods.SerializeObjectToXML(response.Object);
        }

        public void testExportInvoice()
        {
            var datos = new DataTable();
            // obtener datos del DataTable
            // fake data
            datos.Columns.Add("Version", typeof(decimal)); // cambiar según catálogo de tipo de documentos
            datos.Columns.Add("TipoeCF", typeof(int));
            datos.Columns.Add("eNCF", typeof(int));
            datos.Columns.Add("FechaVencimientoSecuencia", typeof(string));            
            datos.Columns.Add("TipoIngresos", typeof(string));
            datos.Columns.Add("FechaLimitePago", typeof(string));
            datos.Columns.Add("TerminoPago", typeof(string));
            datos.Columns.Add("TipoPago", typeof(string));
            datos.Columns.Add("FormaPago", typeof(string));
            datos.Columns.Add("MontoPago", typeof(decimal));

            // Emisor
            datos.Columns.Add("RNCEmisor", typeof(int));
            datos.Columns.Add("RazonSocialEmisor", typeof(string));
            datos.Columns.Add("NombreComercial", typeof(string));
            datos.Columns.Add("DireccionEmisor", typeof(string));
            datos.Columns.Add("Municipio", typeof(string));
            datos.Columns.Add("Provincia", typeof(string));
            datos.Columns.Add("TelefonoEmisor", typeof(string));
            datos.Columns.Add("CorreoEmisor", typeof(string));
            datos.Columns.Add("WebSite", typeof(string));
            datos.Columns.Add("CodigoVendedor", typeof(string));
            datos.Columns.Add("NumeroFacturaInterna", typeof(string));
            datos.Columns.Add("NumeroPedidoInterno", typeof(string));
            datos.Columns.Add("ZonaVenta", typeof(string));
            datos.Columns.Add("FechaEmision", typeof(string));

            // Comprador
            datos.Columns.Add("RNCComprador", typeof(int));
            datos.Columns.Add("RazonSocialComprador", typeof(string));
            datos.Columns.Add("ContactoComprador", typeof(string));
            datos.Columns.Add("CorreoComprador", typeof(string));
            datos.Columns.Add("DireccionComprador", typeof(string));
            datos.Columns.Add("MunicipioComprador", typeof(string));
            datos.Columns.Add("ProvinciaComprador", typeof(string));
            datos.Columns.Add("FechaEntrega", typeof(string));
            datos.Columns.Add("ContactoEntrega", typeof(string));
            datos.Columns.Add("DireccionEntrega", typeof(string));
            datos.Columns.Add("TelefonoAdicional", typeof(string));
            datos.Columns.Add("FechaOrdenCompra", typeof(string));
            datos.Columns.Add("NumeroOrdenCompra", typeof(string));
            datos.Columns.Add("CodigoInternoComprador", typeof(string));

            // Informaciones adicionales
            datos.Columns.Add("FechaEmbarque", typeof(string));
            datos.Columns.Add("NumeroEmbarque", typeof(string));
            datos.Columns.Add("NumeroContenedor", typeof(string));
            datos.Columns.Add("NumeroReferencia", typeof(string));
            datos.Columns.Add("NombrePuertoEmbarque", typeof(string));
            datos.Columns.Add("CondicionesEntrega", typeof(string));
            datos.Columns.Add("TotalFob", typeof(decimal));
            datos.Columns.Add("Seguro", typeof(decimal));
            datos.Columns.Add("Flete", typeof(decimal));
            datos.Columns.Add("TotalCif", typeof(decimal));
            datos.Columns.Add("RegimenAduanero", typeof(string));
            datos.Columns.Add("NombrePuertoSalida", typeof(string));
            datos.Columns.Add("NombrePuertoDesembarque", typeof(string));
            datos.Columns.Add("PesoBruto", typeof(decimal));
            datos.Columns.Add("PesoNeto", typeof(decimal));
            datos.Columns.Add("UnidadPesoBruto", typeof(string));
            datos.Columns.Add("UnidadPesoNeto", typeof(string));
            datos.Columns.Add("CantidadBulto", typeof(decimal));
            datos.Columns.Add("UnidadBulto", typeof(string));
            datos.Columns.Add("VolumenBulto", typeof(string));
            datos.Columns.Add("UnidadVolumen", typeof(decimal));

            // transporte
            datos.Columns.Add("ViaTransporte", typeof(string));
            datos.Columns.Add("PaisOrigen", typeof(string));
            datos.Columns.Add("DireccionDestino", typeof(string));
            datos.Columns.Add("PaisDestino", typeof(string));
            datos.Columns.Add("NumeroAlbaran", typeof(string));

            // totales            
            datos.Columns.Add("MontoGravadoTotal", typeof(decimal));
            datos.Columns.Add("MontoGravadoI3", typeof(decimal));
            datos.Columns.Add("ITBIS3", typeof(decimal));
            datos.Columns.Add("TotalITBIS", typeof(decimal));
            datos.Columns.Add("TotalITBIS3", typeof(decimal));
            datos.Columns.Add("MontoTotal", typeof(decimal));

            // Detalle
            datos.Columns.Add("NumeroLinea", typeof(int));
            datos.Columns.Add("IndicadorFacturacion", typeof(int));
            datos.Columns.Add("NombreItem", typeof(string));
            datos.Columns.Add("IndicadorBienoServicio", typeof(int));
            datos.Columns.Add("CantidadItem", typeof(decimal));
            datos.Columns.Add("UnidadMedida", typeof(int));
            datos.Columns.Add("PrecioUnitarioItem", typeof(decimal));
            datos.Columns.Add("MontoItem", typeof(decimal));
            datos.Columns.Add("DescuentoMonto", typeof(decimal));

            // Agregar filas manualmente
            DataRow fila1 = datos.NewRow();
            fila1["Version"] = "1.0";
            fila1["TipoeCF"] = 46;
            fila1["eNCF"] = 77;
            //fila1["FechaVencimientoSecuencia"] = "31-12-2025";
            fila1["TipoIngresos"] = "01";
            fila1["TipoPago"] = "2";
            fila1["FechaLimitePago"] = "06-05-2025";
            fila1["TerminoPago"] = "1 mes";
            fila1["FormaPago"] = "2";
            fila1["MontoPago"] = 100.00;
            fila1["RNCEmisor"] = "132788419";
            fila1["RazonSocialEmisor"] = "DOCUMENTOS ELECTRONICOS DE 02";
            fila1["NombreComercial"] = "DOCUMENTOS ELECTRONICOS DE 02";
            fila1["DireccionEmisor"] = "AVE. ISABEL AGUIAR NO. 269, ZONA INDUSTRIAL DE HERRERA";
            fila1["Municipio"] = "320301";
            fila1["Provincia"] = "320000";
            fila1["TelefonoEmisor"] = "32484480";
            fila1["CorreoEmisor"] = "test@test.com";
            fila1["WebSite"] = "www.test.com";
            fila1["CodigoVendedor"] = "AA0000000100000000010000000002000000000300000000050000000006";
            fila1["NumeroFacturaInterna"] = "123456789016";
            fila1["NumeroPedidoInterno"] = "123456789016";
            fila1["ZonaVenta"] = "NORTE";
            fila1["FechaEmision"] = "01-04-2020";
            fila1["RNCComprador"] = "131880681";
            fila1["RazonSocialComprador"] = "DOCUMENTOS ELECTRONICOS DE 03";
            fila1["ContactoComprador"] = "MARCOS LATIPLOL";
            fila1["CorreoComprador"] = "contacto@test.com";
            fila1["DireccionComprador"] = "CALLE JACINTO DE LA CONCHA FELIZ ESQUINA 27 DE FEBRERO,FRENTE A DOMINO";
            fila1["MunicipioComprador"] = "010100";
            fila1["ProvinciaComprador"] = "010000";
            fila1["FechaEntrega"] = "10-10-2020";
            fila1["ContactoEntrega"] = "JACINTO MANON";
            fila1["DireccionEntrega"] = "ZONA HAINA";
            fila1["TelefonoAdicional"] = "809-555-5050";
            fila1["FechaOrdenCompra"] = "10-11-2018";
            fila1["NumeroOrdenCompra"] = "4500352238";
            fila1["CodigoInternoComprador"] = "10633440";

            fila1["FechaEmbarque"] = null;
            fila1["NumeroEmbarque"] = null;
            fila1["NumeroContenedor"] = null;
            fila1["NumeroReferencia"] = null;
            fila1["NombrePuertoEmbarque"] = "ZONA HAINA";
            fila1["CondicionesEntrega"] = "FOB";
            fila1["TotalFob"] = 1800.00;
            fila1["Seguro"] = 250.00;
            fila1["Flete"] = 22.00;
            fila1["TotalCif"] = 2000.00;
            fila1["RegimenAduanero"] = "EXPORTACION NACIONAL";
            fila1["NombrePuertoSalida"] = "DOSDQ";
            fila1["NombrePuertoDesembarque"] = "PTO RICO";
            fila1["PesoBruto"] = 25000.00;
            fila1["PesoNeto"] = 24878.00;
            fila1["UnidadPesoBruto"] = 21;
            fila1["UnidadPesoNeto"] = 21;
            fila1["CantidadBulto"] = 250.00;
            fila1["UnidadBulto"] = 25;
            fila1["VolumenBulto"] = 45;
            fila1["UnidadVolumen"] = 27;

            fila1["ViaTransporte"] = "02";
            fila1["PaisOrigen"] = "RAPUBLICA DOMINICANA";
            fila1["DireccionDestino"] = null;
            fila1["PaisDestino"] = null;
            fila1["NumeroAlbaran"] = null;


            fila1["MontoTotal"] = 100;
            fila1["MontoGravadoTotal"] = 101;
            fila1["MontoGravadoI3"] = 102;
            fila1["ITBIS3"] = 0;
            fila1["TotalITBIS"] = 104;
            fila1["TotalITBIS3"] = 105;

            fila1["NumeroLinea"] = 1;
            fila1["IndicadorFacturacion"] = 4;
            fila1["NombreItem"] = "LECHE";
            fila1["IndicadorBienoServicio"] = 1;
            fila1["CantidadItem"] = 7500.00;
            fila1["UnidadMedida"] = 47;
            fila1["PrecioUnitarioItem"] = 40.00;
            fila1["MontoItem"] = 300000.00;
            fila1["DescuentoMonto"] = 0;


            datos.Rows.Add(fila1);


            IDocumentStrategy strategy = new ExportInvoiceDocumentStrategy();
            Document document = new Document(strategy);

            var response = document.MakeDocument(datos);
            string xml = Methods.SerializeObjectToXML(response.Object);
        }

        public void testCreditNote()
        {
            var datos = new DataTable();
            // obtener datos del DataTable
            // fake data
            datos.Columns.Add("Version", typeof(decimal)); // cambiar según catálogo de tipo de documentos
            datos.Columns.Add("TipoeCF", typeof(int));
            datos.Columns.Add("eNCF", typeof(int));
            datos.Columns.Add("FechaVencimientoSecuencia", typeof(string));
            datos.Columns.Add("TipoIngresos", typeof(string));
            datos.Columns.Add("FechaLimitePago", typeof(string));
            datos.Columns.Add("TerminoPago", typeof(string));
            datos.Columns.Add("TipoPago", typeof(string));
            datos.Columns.Add("IndicadorNotaCredito", typeof(string));
            datos.Columns.Add("IndicadorMontoGravado", typeof(int));

            datos.Columns.Add("FormaPago", typeof(string));
            datos.Columns.Add("MontoPago", typeof(decimal));

            // Emisor
            datos.Columns.Add("RNCEmisor", typeof(int));
            datos.Columns.Add("RazonSocialEmisor", typeof(string));
            datos.Columns.Add("NombreComercial", typeof(string));
            datos.Columns.Add("DireccionEmisor", typeof(string));
            datos.Columns.Add("Municipio", typeof(string));
            datos.Columns.Add("Provincia", typeof(string));
            datos.Columns.Add("TelefonoEmisor", typeof(string));
            datos.Columns.Add("CorreoEmisor", typeof(string));
            datos.Columns.Add("WebSite", typeof(string));
            datos.Columns.Add("CodigoVendedor", typeof(string));
            datos.Columns.Add("NumeroFacturaInterna", typeof(string));
            datos.Columns.Add("NumeroPedidoInterno", typeof(string));
            datos.Columns.Add("ZonaVenta", typeof(string));
            datos.Columns.Add("FechaEmision", typeof(string));

            // Comprador
            datos.Columns.Add("RNCComprador", typeof(int));
            datos.Columns.Add("RazonSocialComprador", typeof(string));
            datos.Columns.Add("ContactoComprador", typeof(string));
            datos.Columns.Add("CorreoComprador", typeof(string));
            datos.Columns.Add("DireccionComprador", typeof(string));
            datos.Columns.Add("MunicipioComprador", typeof(string));
            datos.Columns.Add("ProvinciaComprador", typeof(string));
            datos.Columns.Add("FechaEntrega", typeof(string));
            datos.Columns.Add("ContactoEntrega", typeof(string));
            datos.Columns.Add("DireccionEntrega", typeof(string));
            datos.Columns.Add("TelefonoAdicional", typeof(string));
            datos.Columns.Add("FechaOrdenCompra", typeof(string));
            datos.Columns.Add("NumeroOrdenCompra", typeof(string));
            datos.Columns.Add("CodigoInternoComprador", typeof(string));

            // Informaciones adicionales
            datos.Columns.Add("FechaEmbarque", typeof(string));
            datos.Columns.Add("NumeroEmbarque", typeof(string));
            datos.Columns.Add("NumeroContenedor", typeof(string));
            datos.Columns.Add("NumeroReferencia", typeof(string));
            datos.Columns.Add("NombrePuertoEmbarque", typeof(string));
            datos.Columns.Add("CondicionesEntrega", typeof(string));
            datos.Columns.Add("TotalFob", typeof(decimal));
            datos.Columns.Add("Seguro", typeof(decimal));
            datos.Columns.Add("Flete", typeof(decimal));
            datos.Columns.Add("TotalCif", typeof(decimal));
            datos.Columns.Add("RegimenAduanero", typeof(string));
            datos.Columns.Add("NombrePuertoSalida", typeof(string));
            datos.Columns.Add("NombrePuertoDesembarque", typeof(string));
            datos.Columns.Add("PesoBruto", typeof(decimal));
            datos.Columns.Add("PesoNeto", typeof(decimal));
            datos.Columns.Add("UnidadPesoBruto", typeof(string));
            datos.Columns.Add("UnidadPesoNeto", typeof(string));
            datos.Columns.Add("CantidadBulto", typeof(decimal));
            datos.Columns.Add("UnidadBulto", typeof(string));
            datos.Columns.Add("VolumenBulto", typeof(string));
            datos.Columns.Add("UnidadVolumen", typeof(decimal));

            // transporte
            datos.Columns.Add("ViaTransporte", typeof(string));
            datos.Columns.Add("PaisOrigen", typeof(string));
            datos.Columns.Add("DireccionDestino", typeof(string));
            datos.Columns.Add("PaisDestino", typeof(string));
            datos.Columns.Add("NumeroAlbaran", typeof(string));

            // totales            
            datos.Columns.Add("MontoGravadoTotal", typeof(decimal));
            datos.Columns.Add("MontoGravadoI1", typeof(decimal));
            datos.Columns.Add("ITBIS1", typeof(decimal));
            datos.Columns.Add("TotalITBIS", typeof(decimal));
            datos.Columns.Add("TotalITBIS1", typeof(decimal));
            datos.Columns.Add("MontoTotal", typeof(decimal));

            // Detalle
            datos.Columns.Add("NumeroLinea", typeof(int));
            datos.Columns.Add("IndicadorFacturacion", typeof(int));
            datos.Columns.Add("NombreItem", typeof(string));
            datos.Columns.Add("IndicadorBienoServicio", typeof(int));
            datos.Columns.Add("CantidadItem", typeof(decimal));
            datos.Columns.Add("UnidadMedida", typeof(int));
            datos.Columns.Add("PrecioUnitarioItem", typeof(decimal));
            datos.Columns.Add("MontoItem", typeof(decimal));
            datos.Columns.Add("DescuentoMonto", typeof(decimal));

            // Referencia
            datos.Columns.Add("NCFModificado", typeof(string));
            datos.Columns.Add("FechaNCFModificado", typeof(string));
            datos.Columns.Add("CodigoModificacion", typeof(string));
            datos.Columns.Add("RazoModificacion", typeof(string));

            // Agregar filas manualmente
            DataRow fila1 = datos.NewRow();
            fila1["Version"] = "1.0";
            fila1["TipoeCF"] = 34;
            fila1["eNCF"] = 77;
            //fila1["FechaVencimientoSecuencia"] = "31-12-2025";
            fila1["TipoIngresos"] = "01";
            fila1["TipoPago"] = "2";
            fila1["IndicadorNotaCredito"] = "0";
            fila1["IndicadorMontoGravado"] = 0;

            fila1["FechaLimitePago"] = "06-05-2025";
            fila1["TerminoPago"] = "1 mes";
            fila1["FormaPago"] = "2";
            fila1["MontoPago"] = 100.00;
            fila1["RNCEmisor"] = "132788419";
            fila1["RazonSocialEmisor"] = "DOCUMENTOS ELECTRONICOS DE 02";
            fila1["NombreComercial"] = "DOCUMENTOS ELECTRONICOS DE 02";
            fila1["DireccionEmisor"] = "AVE. ISABEL AGUIAR NO. 269, ZONA INDUSTRIAL DE HERRERA";
            fila1["Municipio"] = "320301";
            fila1["Provincia"] = "320000";
            fila1["TelefonoEmisor"] = "32484480";
            fila1["CorreoEmisor"] = "test@test.com";
            fila1["WebSite"] = "www.test.com";
            fila1["CodigoVendedor"] = "AA0000000100000000010000000002000000000300000000050000000006";
            fila1["NumeroFacturaInterna"] = "123456789016";
            fila1["NumeroPedidoInterno"] = "123456789016";
            fila1["ZonaVenta"] = "NORTE";
            fila1["FechaEmision"] = "01-04-2020";
            fila1["RNCComprador"] = "131880681";
            fila1["RazonSocialComprador"] = "DOCUMENTOS ELECTRONICOS DE 03";
            fila1["ContactoComprador"] = "MARCOS LATIPLOL";
            fila1["CorreoComprador"] = "contacto@test.com";
            fila1["DireccionComprador"] = "CALLE JACINTO DE LA CONCHA FELIZ ESQUINA 27 DE FEBRERO,FRENTE A DOMINO";
            fila1["MunicipioComprador"] = "010100";
            fila1["ProvinciaComprador"] = "010000";
            fila1["FechaEntrega"] = "10-10-2020";
            fila1["ContactoEntrega"] = "JACINTO MANON";
            fila1["DireccionEntrega"] = "ZONA HAINA";
            fila1["TelefonoAdicional"] = "809-555-5050";
            fila1["FechaOrdenCompra"] = "10-11-2018";
            fila1["NumeroOrdenCompra"] = "4500352238";
            fila1["CodigoInternoComprador"] = "10633440";

            fila1["FechaEmbarque"] = null;
            fila1["NumeroEmbarque"] = null;
            fila1["NumeroContenedor"] = null;
            fila1["NumeroReferencia"] = null;
            fila1["NombrePuertoEmbarque"] = "ZONA HAINA";
            fila1["CondicionesEntrega"] = "FOB";
            fila1["TotalFob"] = 1800.00;
            fila1["Seguro"] = 250.00;
            fila1["Flete"] = 22.00;
            fila1["TotalCif"] = 2000.00;
            fila1["RegimenAduanero"] = "EXPORTACION NACIONAL";
            fila1["NombrePuertoSalida"] = "DOSDQ";
            fila1["NombrePuertoDesembarque"] = "PTO RICO";
            fila1["PesoBruto"] = 25000.00;
            fila1["PesoNeto"] = 24878.00;
            fila1["UnidadPesoBruto"] = 21;
            fila1["UnidadPesoNeto"] = 21;
            fila1["CantidadBulto"] = 250.00;
            fila1["UnidadBulto"] = 25;
            fila1["VolumenBulto"] = 45;
            fila1["UnidadVolumen"] = 27;

            fila1["ViaTransporte"] = "02";
            fila1["PaisOrigen"] = "RAPUBLICA DOMINICANA";
            fila1["DireccionDestino"] = null;
            fila1["PaisDestino"] = null;
            fila1["NumeroAlbaran"] = null;


            fila1["MontoTotal"] = 100;
            fila1["MontoGravadoTotal"] = 101;
            fila1["MontoGravadoI1"] = 102;
            fila1["ITBIS1"] = 0;
            fila1["TotalITBIS"] = 104;
            fila1["TotalITBIS1"] = 105;

            fila1["NumeroLinea"] = 1;
            fila1["IndicadorFacturacion"] = 4;
            fila1["NombreItem"] = "LECHE";
            fila1["IndicadorBienoServicio"] = 1;
            fila1["CantidadItem"] = 7500.00;
            fila1["UnidadMedida"] = 47;
            fila1["PrecioUnitarioItem"] = 40.00;
            fila1["MontoItem"] = 300000.00;
            fila1["DescuentoMonto"] = 0;

            fila1["NCFModificado"] = "E310000000001";
            fila1["FechaNCFModificado"] = "01-04-2020";
            fila1["CodigoModificacion"] = "2";
            fila1["RazoModificacion"] = "Error al enviar datos de prueba.";


            datos.Rows.Add(fila1);


            IDocumentStrategy strategy = new CreditNoteDocumentStrategy();
            Document document = new Document(strategy);

            var response = document.MakeDocument(datos);
            string xml = Methods.SerializeObjectToXML(response.Object);
        }
    }
}
