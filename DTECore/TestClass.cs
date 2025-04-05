using System.Data;

namespace DTECore
{
    public class TestClass
    {
        public void test()
        {
            var datos = new DataTable();
            // obtener datos del DataTable
            // fake data
            datos.Columns.Add("Version", typeof(decimal)); // cambiar según catálogo de tipo de documentos
            datos.Columns.Add("TipoeCF", typeof(int));
            datos.Columns.Add("TipoIngresos", typeof(string));
            datos.Columns.Add("TipoPago", typeof(string));

            // Emisor
            datos.Columns.Add("RNCEmisor", typeof(int));
            datos.Columns.Add("RazonSocialEmisor", typeof(string));
            datos.Columns.Add("NombreComercial", typeof(string));
            datos.Columns.Add("DireccionEmisor", typeof(string));
            datos.Columns.Add("Municipio", typeof(string));
            datos.Columns.Add("Provincia", typeof(string));
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
            datos.Columns.Add("MontoExento", typeof(decimal));

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
            fila1["Version"] = 1.0; 
            fila1["TipoeCF"] = 32;
            fila1["TipoIngresos"] = "01";
            fila1["TipoPago"] = "1";
            fila1["RNCEmisor"] = "132788419";
            fila1["RazonSocialEmisor"] = "DOCUMENTOS ELECTRONICOS DE 02";
            fila1["NombreComercial"] = "DOCUMENTOS ELECTRONICOS DE 02";
            fila1["DireccionEmisor"] = "AVE. ISABEL AGUIAR NO. 269, ZONA INDUSTRIAL DE HERRERA";
            fila1["Municipio"] = "320301";
            fila1["Provincia"] = "320000"; 
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
            fila1["MontoExento"] = 0;
            fila1["MontoTotal"] = 100;


            fila1["NumeroLinea"] = 1;
            fila1["IndicadorFacturacion"] = 4;
            fila1["NombreItem"] = "LECHE";
            fila1["IndicadorBienoServicio"] = 1;
            fila1["CantidadItem"] = 7500.00;
            fila1["UnidadMedida"] = 47;
            fila1["PrecioUnitarioItem"] = 40.00;
            fila1["MontoItem"] = 300000.00;
            

            datos.Rows.Add(fila1);


            IDocumentStrategy strategy = new InvoiceDocumentStrategy();
            Document document = new Document(strategy);

            var response = document.MakeDocument(datos);
            string xml = document.SerializeDocument(response.Object);
        }
    }
}
