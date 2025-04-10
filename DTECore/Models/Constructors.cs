using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTECore
{
    public partial class ECFEncabezado
    {
        public ECFEncabezado()
        {

        }
    }

    public partial class ECFEncabezadoEmisor
    {
        // Constructor vacío
        public ECFEncabezadoEmisor()
        {
            TablaTelefonoEmisor = null;
        }

        public ECFEncabezadoEmisor(uint rncEmisor, string razonSocialEmisor, string nombreComercial, string direccionEmisor, string municipio, string provincia
            , string[] tablaTelefonoEmisor
            , string correoEmisor
            , string website, string codigoVendedor, string numeroFacturaInterna, string numeroPedidoInterno, string zonaVenta, string fechaEmision)
        {
            this.RNCEmisor = rncEmisor;
            this.RazonSocialEmisor = razonSocialEmisor;
            this.NombreComercial = nombreComercial;
            this.DireccionEmisor = direccionEmisor;
            this.Municipio = municipio;
            this.Provincia = provincia;
            this.TablaTelefonoEmisor = tablaTelefonoEmisor;
            this.CorreoEmisor = correoEmisor;
            this.WebSite = website;
            this.CodigoVendedor = codigoVendedor;
            this.NumeroFacturaInterna = numeroFacturaInterna;
            this.NumeroPedidoInterno = numeroPedidoInterno;
            this.ZonaVenta = zonaVenta;
            this.FechaEmision = fechaEmision;
        }
    }

    public partial class ECFEncabezadoComprador
    {
        public ECFEncabezadoComprador() { }

        public ECFEncabezadoComprador(uint rncComprador, string razonSocialComprador, string contactoComprador, string correoComprador, string direccionComprador, string municipioComprador, string provinciaComprador, string fechaEntrega, string fechaOrdenCompra, string numeroOrdenCompra, string codigoInternoComprador)
        {
            this.RNCComprador = rncComprador;
            this.RazonSocialComprador = razonSocialComprador;
            this.ContactoComprador = contactoComprador;
            this.CorreoComprador = correoComprador;
            this.DireccionComprador = direccionComprador;
            this.MunicipioComprador = municipioComprador;
            this.ProvinciaComprador = provinciaComprador;
            this.FechaEntrega = fechaEntrega;
            this.FechaOrdenCompra = fechaOrdenCompra;
            this.NumeroOrdenCompra = numeroOrdenCompra;
            this.CodigoInternoComprador = codigoInternoComprador;
        }
    }    
    
}
