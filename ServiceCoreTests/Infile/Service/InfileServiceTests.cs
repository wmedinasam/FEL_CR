using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceCore.Infile.Model;
using ServiceCore.Infile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static ServiceCore.Infile.Service.InfileService;

namespace ServiceCore.Infile.Service.Tests
{
    [TestClass()]
    public class InfileServiceTests
    {
        InfileService infileService = new InfileService();
        string url = "https://fe-webservice-test.infile.com.do/republica_dominicana/auth/login";
        string username = "infile-ws-test";
        string password = "5285D1A3";
        string key = "SK6FEAA903461486B5FDC2C3CA1824FD";
        string xml = string.Empty;

        RequestToken requestToken = new RequestToken
        {
            rnc = "131098207",
            llave = "252D4EF516194E7BA2F210FBAA5DD479"
        };

        [TestMethod()]
        public void GetTokenTest()
        {
            var response = infileService.GetToken(url, username, password, key, requestToken);
            var isValidToken = (response.Contains("Error")) ? false : true;
            Assert.IsTrue(isValidToken);
        }

        [TestMethod()]
        public void GetTokenFailTest()
        {
            // only to test the fail case
            string password = "5285D1A3ssssssssssssss";

            var response = infileService.GetToken(url, username, password, key, requestToken);
            var isValidToken = (response.Contains("Error")) ? false : true;

            Assert.IsFalse(isValidToken);
        }


        [TestMethod()]
        public void CorrectSignInvoiceTest()
        {
            var token = infileService.GetToken(url, username, password, key, requestToken);
            url = "https://fe-webservice-test.infile.com.do/republica_dominicana/api/v1/emision/ecf";
            xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<ECF xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <Encabezado>\r\n    <Version>1.0</Version>\r\n    <IdDoc>\r\n      <TipoeCF>32</TipoeCF>\r\n      <eNCF>E320000000002</eNCF>\r\n      <TipoIngresos>01</TipoIngresos>\r\n      <TipoPago>1</TipoPago>\r\n    </IdDoc>\r\n    <Emisor>\r\n      <RNCEmisor>131098207</RNCEmisor>\r\n      <RazonSocialEmisor>DOCUMENTOS ELECTRONICOS DE 02</RazonSocialEmisor>\r\n      <NombreComercial>DOCUMENTOS ELECTRONICOS DE 02</NombreComercial>\r\n      <DireccionEmisor>AVE. ISABEL AGUIAR NO. 269, ZONA INDUSTRIAL DE HERRERA</DireccionEmisor>\r\n      <Municipio>320301</Municipio>\r\n      <Provincia>320000</Provincia>\r\n      <TablaTelefonoEmisor>\r\n        <TelefonoEmisor>809-472-7676</TelefonoEmisor>\r\n      </TablaTelefonoEmisor>\r\n      <WebSite>www.test.com</WebSite>\r\n      <CodigoVendedor>AA0000000100000000010000000002000000000300000000050000000006</CodigoVendedor>\r\n      <NumeroFacturaInterna>123456789016</NumeroFacturaInterna>\r\n      <NumeroPedidoInterno>123456789016</NumeroPedidoInterno>\r\n      <ZonaVenta>NORTE</ZonaVenta>\r\n      <FechaEmision>11-04-2025</FechaEmision>\r\n    </Emisor>\r\n    <Comprador>\r\n      <RNCComprador>131880681</RNCComprador>\r\n      <RazonSocialComprador>DOCUMENTOS ELECTRONICOS DE 03</RazonSocialComprador>\r\n      <ContactoComprador>MARCOS LATIPLOL</ContactoComprador>\r\n      <CorreoComprador>contacto@test.com</CorreoComprador>\r\n      <DireccionComprador>CALLE JACINTO DE LA CONCHA FELIZ ESQUINA 27 DE FEBRERO,FRENTE A DOMINO</DireccionComprador>\r\n      <MunicipioComprador>010100</MunicipioComprador>\r\n      <ProvinciaComprador>010000</ProvinciaComprador>\r\n      <FechaEntrega>15-04-2025</FechaEntrega>\r\n      <FechaOrdenCompra>01-04-2025</FechaOrdenCompra>\r\n      <NumeroOrdenCompra>4500352238</NumeroOrdenCompra>\r\n      <CodigoInternoComprador>10633440</CodigoInternoComprador>\r\n    </Comprador>\r\n    <Totales>\r\n      <MontoExento>300000.00</MontoExento>\r\n      <MontoTotal>300000.00</MontoTotal>\r\n    </Totales>\r\n  </Encabezado>\r\n  <DetallesItems>\r\n   <Item>\r\n      <NumeroLinea>1</NumeroLinea>\r\n      <IndicadorFacturacion>4</IndicadorFacturacion>\r\n      <NombreItem>LECHE</NombreItem>\r\n      <IndicadorBienoServicio>1</IndicadorBienoServicio>\r\n      <CantidadItem>7500.00</CantidadItem>\r\n      <UnidadMedida>47</UnidadMedida>\r\n      <PrecioUnitarioItem>40.00</PrecioUnitarioItem>\r\n      <MontoItem>300000.00</MontoItem>\r\n    </Item>\r\n  </DetallesItems>\r\n</ECF>";
            var response = infileService.SendXmlDocument(url, token, xml);
            Assert.IsTrue(response.Success);

        }

        [TestMethod()]
        public void IncorrectSignInvoiceTest()
        {
            var token = infileService.GetToken(url, username, password, key, requestToken);
            url = "https://fe-webservice-test.infile.com.do/republica_dominicana/api/v1/emision/ecf";
            xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<ECF xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <Encabezado>\r\n    <Version>1.0</Version>\r\n    <IdDoc>\r\n      <TipoeCF>32</TipoeCF>\r\n      <eNCF>E320000000002</eNCF>\r\n      <TipoIngresos>01</TipoIngresos>\r\n      <TipoPago>1</TipoPago>\r\n    </IdDoc>\r\n    <Emisor>\r\n      <RNCEmisor>131098207</RNCEmisor>\r\n      <RazonSocialEmisor>DOCUMENTOS ELECTRONICOS DE 02</RazonSocialEmisor>\r\n      <NombreComercial>DOCUMENTOS ELECTRONICOS DE 02</NombreComercial>\r\n      <DireccionEmisor>AVE. ISABEL AGUIAR NO. 269, ZONA INDUSTRIAL DE HERRERA</DireccionEmisor>\r\n      <Municipio>320301</Municipio>\r\n      <Provincia>320000</Provincia>\r\n      <TablaTelefonoEmisor>\r\n        <TelefonoEmisor>809-472-7676</TelefonoEmisor>\r\n      </TablaTelefonoEmisor>\r\n      <WebSite>www.test.com</WebSite>\r\n      <CodigoVendedor>AA0000000100000000010000000002000000000300000000050000000006</CodigoVendedor>\r\n      <NumeroFacturaInterna>123456789016</NumeroFacturaInterna>\r\n      <NumeroPedidoInterno>123456789016</NumeroPedidoInterno>\r\n      <ZonaVenta>NORTE</ZonaVenta>\r\n      <FechaEmision>11-04-2025</FechaEmision>\r\n    </Emisor>\r\n    <Comprador>\r\n      <RNCComprador>131880681</RNCComprador>\r\n      <RazonSocialComprador>DOCUMENTOS ELECTRONICOS DE 03</RazonSocialComprador>\r\n      <ContactoComprador>MARCOS LATIPLOL</ContactoComprador>\r\n      <CorreoComprador>contacto@test.com</CorreoComprador>\r\n      <DireccionComprador>CALLE JACINTO DE LA CONCHA FELIZ ESQUINA 27 DE FEBRERO,FRENTE A DOMINO</DireccionComprador>\r\n      <MunicipioComprador>010100</MunicipioComprador>\r\n      <ProvinciaComprador>010000</ProvinciaComprador>\r\n      <FechaEntrega>15-04-2025</FechaEntrega>\r\n      <FechaOrdenCompra>01-04-2025</FechaOrdenCompra>\r\n      <NumeroOrdenCompra>4500352238</NumeroOrdenCompra>\r\n      <CodigoInternoComprador>10633440</CodigoInternoComprador>\r\n    </Comprador>\r\n    <Totales>\r\n      <MontoExento>300000.00</MontoExento>\r\n      <MontoTotal>300000.00</MontoTotal>\r\n    </Totales>\r\n  </Encabezado>\r\n  <DetallesItems>\r\n   <Item>\r\n      <NumeroLinea>1</NumeroLinea>\r\n      <IndicadorFacturacion>4</IndicadorFacturacion>\r\n      <NombreItem>LECHE</NombreItem>\r\n      <IndicadorBienoServicio>1</IndicadorBienoServicio>\r\n      <CantidadItem>7500.00</CantidadItem>\r\n      <UnidadMedida>47</UnidadMedida>\r\n      <PrecioUnitarioItem>40.00</PrecioUnitarioItem>\r\n      <MontoItem>300000.00</MontoItem>\r\n    </Item>\r\n  </DetallesItems>\r\n</ECF>";
            var response = infileService.SendXmlDocument(url, token, xml);
            Assert.IsTrue(!response.Success);

        }

        [TestMethod()]
        public void GetDocumentPdfInBrowserTest()
        {
            string baseUrl = "https://report-test.infile.com.do/report/v1/documento/emision";
            string rnc = "132788419";
            string encf = "E310000000421";
            string codigoSeguridad = "mUkF4P";
            InfileService.GetDocumentPdfInBrowser(baseUrl, rnc, encf, codigoSeguridad);
        }
    }
}