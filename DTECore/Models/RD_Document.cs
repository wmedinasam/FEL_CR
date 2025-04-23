/// <remarks/>
/// Este código fue generado por una herramienta. 
/// Versión de runtime: 4.0.30319.42000
/// 
/// Los cambios en este archivo pueden causar un comportamiento incorrecto y se perderán si
/// se vuelve a generar el código.
// NOTA: El código generado puede requerir, como mínimo, .NET Framework 4.5 o .NET Core/Standard 2.0.
namespace DTECore
{
    using System.Xml.Serialization;

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ECF
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        private ECFEncabezado encabezadoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        private ECFItem[] detallesItemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        private ECFInformacionReferencia informacionReferenciaField;

        public ECF()
        {
            this.encabezadoField = new ECFEncabezado();
            this.detallesItemsField = new ECFItem[0];
        }

        public ECFEncabezado Encabezado
        {
            get
            {
                return this.encabezadoField;
            }
            set
            {
                this.encabezadoField = value;
            }
        }
       
        [System.Xml.Serialization.XmlArrayItemAttribute("Item", IsNullable = false)]
        public ECFItem[] DetallesItems
        {
            get
            {
                return this.detallesItemsField;
            }
            set
            {
                this.detallesItemsField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public ECFInformacionReferencia InformacionReferencia
        {
            get
            {
                return this.informacionReferenciaField;
            }
            set
            {
                this.informacionReferenciaField = value;
            }
        }


    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ECFEncabezado
    {

        private string versionField;

        private ECFEncabezadoIdDoc idDocField;

        private ECFEncabezadoEmisor emisorField;

        private ECFEncabezadoComprador compradorField;

        private ECFEncabezadoInformacionesAdicionales informacionesAdicionalesField;

        private ECFEncabezadoTransporte transporteField;

        private ECFEncabezadoTotales totalesField;

        [XmlElement(IsNullable = false)]
        public string Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public ECFEncabezadoIdDoc IdDoc
        {
            get
            {
                return this.idDocField;
            }
            set
            {
                this.idDocField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public ECFEncabezadoEmisor Emisor
        {
            get
            {
                return this.emisorField;
            }
            set
            {
                this.emisorField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public ECFEncabezadoComprador Comprador
        {
            get
            {
                return this.compradorField;
            }
            set
            {
                this.compradorField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public ECFEncabezadoTransporte Transporte
        {
            get
            {
                return this.transporteField;
            }
            set
            {
                this.transporteField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public ECFEncabezadoTotales Totales
        {
            get
            {
                return this.totalesField;
            }
            set
            {
                this.totalesField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public ECFEncabezadoInformacionesAdicionales InformacionesAdicionales
        {
            get
            {
                return this.informacionesAdicionalesField;
            }
            set
            {
                this.informacionesAdicionalesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ECFEncabezadoIdDoc
    {

        private int tipoeCFField;

        private string eNCFField;

        private string fechaVencimientoSecuenciaField;

        private int indicadorNotaCreditoField;

        private string indicadorMontoGravadoField;

        private string tipoIngresosField;

        private string tipoPagoField;

        private string fechaLimitePagoField;

        private string TerminoPagoField;

        private ECFEncabezadoIdDocTablaFormasPago[] tablaFormasPagoField;

        private string[] textField;

        [XmlElement(IsNullable = false)]
        public int TipoeCF
        {
            get
            {
                return this.tipoeCFField;
            }
            set
            {
                this.tipoeCFField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string eNCF
        {
            get
            {
                return this.eNCFField;
            }
            set
            {
                this.eNCFField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string FechaVencimientoSecuencia
        {
            get
            {
                return this.fechaVencimientoSecuenciaField;
            }
            set
            {
                this.fechaVencimientoSecuenciaField = value;
            }
        }

        [XmlElement(IsNullable =false)]
        public int IndicadorNotaCredito
        {
            get
            {
                return this.indicadorNotaCreditoField;
            }
            set
            {
                this.indicadorNotaCreditoField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string IndicadorMontoGravado
        {
            get
            {
                return this.indicadorMontoGravadoField;
            }
            set
            {
                this.indicadorMontoGravadoField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string TipoIngresos
        {
            get
            {
                return this.tipoIngresosField;
            }
            set
            {
                this.tipoIngresosField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string TipoPago
        {
            get
            {
                return this.tipoPagoField;
            }
            set
            {
                this.tipoPagoField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string FechaLimitePago
        {
            get
            {
                return this.fechaLimitePagoField;
            }
            set
            {
                this.fechaLimitePagoField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string TerminoPago
        {
            get
            {
                return this.TerminoPagoField;
            }
            set
            {
                this.TerminoPagoField = value;
            }
        }

        public ECFEncabezadoIdDocTablaFormasPago[] TablaFormasPago
        {
            get
            {
                return this.tablaFormasPagoField;
            }
            set
            {
                this.tablaFormasPagoField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ECFEncabezadoIdDocTablaFormasPago
    {

        private ECFEncabezadoIdDocTablaFormasPagoFormaDePago formaDePagoField;

        [XmlElement(IsNullable = false)]
        public ECFEncabezadoIdDocTablaFormasPagoFormaDePago FormaDePago
        {
            get
            {
                return this.formaDePagoField;
            }
            set
            {
                this.formaDePagoField = value;
            }
        }

        public ECFEncabezadoIdDocTablaFormasPago()
        {
            this.formaDePagoField = new ECFEncabezadoIdDocTablaFormasPagoFormaDePago();
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ECFEncabezadoInformacionesAdicionales
    {

        private string fechaEmbarqueField;

        private bool fechaEmbarqueFieldSpecified;

        private string numeroEmbarqueField;

        private bool numeroEmbarqueFieldSpecified;

        private string numeroContenedorField;

        private bool numeroContenedorFieldSpecified;

        private string numeroReferenciaField;

        private bool numeroReferenciaFieldSpecified;

        private string nombrePuertoEmbarqueField;

        private bool nombrePuertoEmbarqueFieldSpecified;

        private string condicionesEntregaField;

        private bool condicionesEntregaFieldSpecified;

        private decimal totalFobField;

        private bool totalFobFieldSpecified;

        private decimal seguroField;

        private bool seguroFieldSpecified;

        private decimal fleteField;

        private bool fleteFieldSpecified;

        private decimal totalCifField;

        private bool totalCifFieldSpecified;

        private string regimenAduaneroField;

        private bool regimenAduaneroFieldSpecified;

        private string nombrePuertoSalidaField;

        private bool nombrePuertoSalidaFieldSpecified;

        private string nombrePuertoDesembarqueField;

        private bool nombrePuertoDesembarqueFieldSpecified;

        private decimal pesoBrutoField;

        private bool pesoBrutoFieldSpecified;

        private decimal pesoNetoField;

        private bool pesoNetoFieldSpecified;

        private string unidadPesoBrutoField;

        private bool unidadPesoBrutoFieldSpecified;

        private string unidadPesoNetoField;

        private bool unidadPesoNetoFieldSpecified;

        private decimal cantidadBultoField;

        private bool cantidadBultoFieldSpecified;

        private string unidadBultoField;

        private bool unidadBultoFieldSpecified;

        private string volumenBultoField;

        private bool volumenBultoFieldSpecified;

        private string unidadVolumenField;

        private bool unidadVolumenFieldSpecified;

        [XmlElement(IsNullable = false)]
        public string FechaEmbarque
        {
            get
            {
                return this.fechaEmbarqueField;
            }
            set
            {
                this.fechaEmbarqueField = value;
            }
        }

        [XmlIgnore]
        public bool FechaEmbarqueSpecified
        {
            get
            {
                return this.fechaEmbarqueFieldSpecified;
            }
            set
            {
                this.fechaEmbarqueFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string NumeroEmbarque
        {
            get
            {
                return this.numeroEmbarqueField;
            }
            set
            {
                this.numeroEmbarqueField = value;
            }
        }

        [XmlIgnore]
        public bool NumeroEmbarqueSpecified
        {
            get
            {
                return this.numeroEmbarqueFieldSpecified;
            }
            set
            {
                this.numeroEmbarqueFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string NumeroContenedor
        {
            get
            {
                return this.numeroContenedorField;
            }
            set
            {
                this.numeroContenedorField = value;
            }
        }

        [XmlIgnore]
        public bool NumeroContenedorSpecified
        {
            get
            {
                return this.numeroContenedorFieldSpecified;
            }
            set
            {
                this.numeroContenedorFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string NumeroReferencia
        {
            get
            {
                return this.numeroReferenciaField;
            }
            set
            {
                this.numeroReferenciaField = value;
            }
        }

        [XmlIgnore]
        public bool NumeroReferenciaSpecified
        {
            get
            {
                return this.numeroReferenciaFieldSpecified;
            }
            set
            {
                this.numeroReferenciaFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string NombrePuertoEmbarque
        {
            get
            {
                return this.nombrePuertoEmbarqueField;
            }
            set
            {
                this.nombrePuertoEmbarqueField = value;
            }
        }

        [XmlIgnore]
        public bool NombrePuertoEmbarqueSpecified
        {
            get
            {
                return this.nombrePuertoEmbarqueFieldSpecified;
            }
            set
            {
                this.nombrePuertoEmbarqueFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string CondicionesEntrega
        {
            get
            {
                return this.condicionesEntregaField;
            }
            set
            {
                this.condicionesEntregaField = value;
            }
        }

        [XmlIgnore]
        public bool CondicionesEntregaSpecified
        {
            get
            {
                return this.condicionesEntregaFieldSpecified;
            }
            set
            {
                this.condicionesEntregaFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public decimal TotalFob
        {
            get
            {
                return this.totalFobField;
            }
            set
            {
                this.totalFobField = value;
            }
        }

        [XmlIgnore]
        public bool TotalFobSpecified
        {
            get
            {
                return this.totalFobFieldSpecified;
            }
            set
            {
                this.totalFobFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public decimal Seguro
        {
            get
            {
                return this.seguroField;
            }
            set
            {
                this.seguroField = value;
            }
        }

        [XmlIgnore]
        public bool SeguroSpecified
        {
            get
            {
                return this.seguroFieldSpecified;
            }
            set
            {
                this.seguroFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public decimal Flete
        {
            get
            {
                return this.fleteField;
            }
            set
            {
                this.fleteField = value;
            }
        }

        [XmlIgnore]
        public bool FleteSpecified
        {
            get
            {
                return this.fleteFieldSpecified;
            }
            set
            {
                this.fleteFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public decimal TotalCif
        {
            get
            {
                return this.totalCifField;
            }
            set
            {
                this.totalCifField = value;
            }
        }

        [XmlIgnore]
        public bool TotalCifSpecified
        {
            get
            {
                return this.totalCifFieldSpecified;
            }
            set
            {
                this.totalCifFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string RegimenAduanero
        {
            get
            {
                return this.regimenAduaneroField;
            }
            set
            {
                this.regimenAduaneroField = value;
            }
        }

        [XmlIgnore]
        public bool RegimenAduaneroSpecified
        {
            get
            {
                return this.regimenAduaneroFieldSpecified;
            }
            set
            {
                this.regimenAduaneroFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string NombrePuertoSalida
        {
            get
            {
                return this.nombrePuertoSalidaField;
            }
            set
            {
                this.nombrePuertoSalidaField = value;
            }
        }

        [XmlIgnore]
        public bool NombrePuertoSalidaSpecified
        {
            get
            {
                return this.nombrePuertoSalidaFieldSpecified;
            }
            set
            {
                this.nombrePuertoSalidaFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string NombrePuertoDesembarque
        {
            get
            {
                return this.nombrePuertoDesembarqueField;
            }
            set
            {
                this.nombrePuertoDesembarqueField = value;
            }
        }

        [XmlIgnore]
        public bool NombrePuertoDesembarqueSpecified
        {
            get
            {
                return this.nombrePuertoDesembarqueFieldSpecified;
            }
            set
            {
                this.nombrePuertoDesembarqueFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public decimal PesoBruto
        {
            get
            {
                return this.pesoBrutoField;
            }
            set
            {
                this.pesoBrutoField = value;
            }
        }

        [XmlIgnore]
        public bool PesoBrutoSpecified
        {
            get
            {
                return this.pesoBrutoFieldSpecified;
            }
            set
            {
                this.pesoBrutoFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public decimal PesoNeto
        {
            get
            {
                return this.pesoNetoField;
            }
            set
            {
                this.pesoNetoField = value;
            }
        }

        [XmlIgnore]
        public bool PesoNetoSpecified
        {
            get
            {
                return this.pesoNetoFieldSpecified;
            }
            set
            {
                this.pesoNetoFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string UnidadPesoBruto
        {
            get
            {
                return this.unidadPesoBrutoField;
            }
            set
            {
                this.unidadPesoBrutoField = value;
            }
        }

        [XmlIgnore]
        public bool UnidadPesoBrutoSpecified
        {
            get
            {
                return this.unidadPesoBrutoFieldSpecified;
            }
            set
            {
                this.unidadPesoBrutoFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string UnidadPesoNeto
        {
            get
            {
                return this.unidadPesoNetoField;
            }
            set
            {
                this.unidadPesoNetoField = value;
            }
        }

        [XmlIgnore]
        public bool UnidadPesoNetoSpecified
        {
            get
            {
                return this.unidadPesoNetoFieldSpecified;
            }
            set
            {
                this.unidadPesoNetoFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public decimal CantidadBulto
        {
            get
            {
                return this.cantidadBultoField;
            }
            set
            {
                this.cantidadBultoField = value;
            }
        }

        [XmlIgnore]
        public bool CantidadBultoSpecified
        {
            get
            {
                return this.cantidadBultoFieldSpecified;
            }
            set
            {
                this.cantidadBultoFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string UnidadBulto
        {
            get
            {
                return this.unidadBultoField;
            }
            set
            {
                this.unidadBultoField = value;
            }
        }

        [XmlIgnore]
        public bool UnidadBultoSpecified
        {
            get
            {
                return this.unidadBultoFieldSpecified;
            }
            set
            {
                this.unidadBultoFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string VolumenBulto
        {
            get
            {
                return this.volumenBultoField;
            }
            set
            {
                this.volumenBultoField = value;
            }
        }

        [XmlIgnore]
        public bool VolumenBultoSpecified
        {
            get
            {
                return this.volumenBultoFieldSpecified;
            }
            set
            {
                this.volumenBultoFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string UnidadVolumen
        {
            get
            {
                return this.unidadVolumenField;
            }
            set
            {
                this.unidadVolumenField = value;
            }
        }

        [XmlIgnore]
        public bool UnidadVolumenSpecified
        {
            get
            {
                return this.unidadVolumenFieldSpecified;
            }
            set
            {
                this.unidadVolumenFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ECFEncabezadoIdDocTablaFormasPagoFormaDePago
    {

        private string formaPagoField;

        private decimal montoPagoField;

        [XmlElement(IsNullable = false)]
        public string FormaPago
        {
            get
            {
                return this.formaPagoField;
            }
            set
            {
                this.formaPagoField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public decimal MontoPago
        {
            get
            {
                return this.montoPagoField;
            }
            set
            {
                this.montoPagoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ECFEncabezadoEmisor
    {

        private uint rNCEmisorField;

        private string razonSocialEmisorField;

        private string nombreComercialField;

        private string direccionEmisorField;

        private string municipioField;

        private string provinciaField;

        private string[] tablaTelefonoEmisorField;

        private string webSiteField;

        private string codigoVendedorField;

        private string numeroFacturaInternaField;

        private string numeroPedidoInternoField;

        private string correoEmisorField;

        private string zonaVentaField;

        private string fechaEmisionField;

        [XmlElement(IsNullable = false)]
        public uint RNCEmisor
        {
            get
            {
                return this.rNCEmisorField;
            }
            set
            {
                this.rNCEmisorField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string RazonSocialEmisor
        {
            get
            {
                return this.razonSocialEmisorField;
            }
            set
            {
                this.razonSocialEmisorField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string NombreComercial
        {
            get
            {
                return this.nombreComercialField;
            }
            set
            {
                this.nombreComercialField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string DireccionEmisor
        {
            get
            {
                return this.direccionEmisorField;
            }
            set
            {
                this.direccionEmisorField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string Municipio
        {
            get
            {
                return this.municipioField;
            }
            set
            {
                this.municipioField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string Provincia
        {
            get
            {
                return this.provinciaField;
            }
            set
            {
                this.provinciaField = value;
            }
        }

        [System.Xml.Serialization.XmlArrayItemAttribute("TelefonoEmisor", IsNullable = false)]
        public string[] TablaTelefonoEmisor
        {
            get
            {
                return this.tablaTelefonoEmisorField;
            }
            set
            {
                this.tablaTelefonoEmisorField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string WebSite
        {
            get
            {
                return this.webSiteField;
            }
            set
            {
                this.webSiteField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string CodigoVendedor
        {
            get
            {
                return this.codigoVendedorField;
            }
            set
            {
                this.codigoVendedorField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string NumeroFacturaInterna
        {
            get
            {
                return this.numeroFacturaInternaField;
            }
            set
            {
                this.numeroFacturaInternaField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string NumeroPedidoInterno
        {
            get
            {
                return this.numeroPedidoInternoField;
            }
            set
            {
                this.numeroPedidoInternoField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string CorreoEmisor
        {
            get
            {
                return this.correoEmisorField;
            }
            set
            {
                this.correoEmisorField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string ZonaVenta
        {
            get
            {
                return this.zonaVentaField;
            }
            set
            {
                this.zonaVentaField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string FechaEmision
        {
            get
            {
                return this.fechaEmisionField;
            }
            set
            {
                this.fechaEmisionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ECFEncabezadoEmisorTablaTelefonoEmisor
    {

        private string telefonoEmisorField;

        [XmlElement(IsNullable = false)]
        public string TelefonoEmisor
        {
            get
            {
                return this.telefonoEmisorField;
            }
            set
            {
                this.telefonoEmisorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ECFEncabezadoComprador
    {

        private uint rNCCompradorField;

        private string razonSocialCompradorField;

        private string contactoCompradorField;

        private string correoCompradorField;

        private string direccionCompradorField;

        private string municipioCompradorField;

        private string provinciaCompradorField;

        private string fechaEntregaField;

        private string contactoEntregaField;

        private string direccionEntregaField;

        private string telefonoAdicionalField;

        private string fechaOrdenCompraField;

        private string numeroOrdenCompraField;

        private string codigoInternoCompradorField;

        [XmlElement(IsNullable = false)]
        public uint RNCComprador
        {
            get
            {
                return this.rNCCompradorField;
            }
            set
            {
                this.rNCCompradorField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string RazonSocialComprador
        {
            get
            {
                return this.razonSocialCompradorField;
            }
            set
            {
                this.razonSocialCompradorField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string ContactoComprador
        {
            get
            {
                return this.contactoCompradorField;
            }
            set
            {
                this.contactoCompradorField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string CorreoComprador
        {
            get
            {
                return this.correoCompradorField;
            }
            set
            {
                this.correoCompradorField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string DireccionComprador
        {
            get
            {
                return this.direccionCompradorField;
            }
            set
            {
                this.direccionCompradorField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string MunicipioComprador
        {
            get
            {
                return this.municipioCompradorField;
            }
            set
            {
                this.municipioCompradorField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string ProvinciaComprador
        {
            get
            {
                return this.provinciaCompradorField;
            }
            set
            {
                this.provinciaCompradorField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string FechaEntrega
        {
            get
            {
                return this.fechaEntregaField;
            }
            set
            {
                this.fechaEntregaField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string ContactoEntrega
        {
            get
            {
                return this.contactoEntregaField;
            }
            set
            {
                this.contactoEntregaField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntregaField;
            }
            set
            {
                this.direccionEntregaField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string TelefonoAdicional
        {
            get
            {
                return this.telefonoAdicionalField;
            }
            set
            {
                this.telefonoAdicionalField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string FechaOrdenCompra
        {
            get
            {
                return this.fechaOrdenCompraField;
            }
            set
            {
                this.fechaOrdenCompraField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string NumeroOrdenCompra
        {
            get
            {
                return this.numeroOrdenCompraField;
            }
            set
            {
                this.numeroOrdenCompraField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string CodigoInternoComprador
        {
            get
            {
                return this.codigoInternoCompradorField;
            }
            set
            {
                this.codigoInternoCompradorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ECFEncabezadoTotales
    {
        private decimal montoGravadoTotalField;

        private bool montoGravadoTotalSpecified;

        private decimal montoGravadoI1Field;

        private bool montoGravadoI1Specified;

        private decimal montoGravadoI3Field;

        private bool montoGravadoI3Specified;

        private decimal montoExentoField;

        private bool montoExentoSpecified;

        private decimal iTBIS1Field;

        private bool iTBIS1Specified;

        private decimal iTBIS3Field;

        private bool iTBIS3Specified;

        private decimal totalITBISField;

        private bool totalITBISSpecified;

        private decimal totalITBIS1Field;

        private bool totalITBIS1Specified;

        private decimal totalITBIS3Field;

        private bool totalITBIS3Specified;

        private decimal montoTotalField;

        private decimal totalITBISRetenidoField;

        private bool totalITBISRetenidoSpecified;

        private decimal totalISRRetencionField;

        private bool totalISRRetencionSpecified;

        [XmlElement(IsNullable = false)]
        public decimal MontoExento
        {
            get { return this.montoExentoField; }
            set { this.montoExentoField = value; }
        }

        [XmlIgnore]
        public bool MontoExentoSpecified
        {
            get { return this.montoExentoSpecified; }
            set { this.montoExentoSpecified = value; }
        }

        [XmlElement(IsNullable = false)]
        public decimal MontoTotal
        {
            get { return this.montoTotalField; }
            set { this.montoTotalField = value; }
        }

        [XmlElement(IsNullable = false)]
        public decimal MontoGravadoTotal
        {
            get { return this.montoGravadoTotalField; }
            set { this.montoGravadoTotalField = value; }
        }

        [XmlIgnore]
        public bool MontoGravadoTotalSpecified
        {
            get { return this.montoGravadoTotalSpecified; }
            set { this.montoGravadoTotalSpecified = value; }
        }

        [XmlElement(IsNullable = false)]
        public decimal MontoGravadoI1
        {
            get { return this.montoGravadoI1Field; }
            set { this.montoGravadoI1Field = value; }
        }

        [XmlIgnore]
        public bool MontoGravadoI1Specified
        {
            get { return this.montoGravadoI1Specified; }
            set { this.montoGravadoI1Specified = value; }
        }

        [XmlElement(IsNullable = false)]
        public decimal MontoGravadoI3
        {
            get { return this.montoGravadoI3Field; }
            set { this.montoGravadoI3Field = value; }
        }

        [XmlIgnore]
        public bool MontoGravadoI3Specified
        {
            get { return this.montoGravadoI3Specified; }
            set { this.montoGravadoI3Specified = value; }
        }

        [XmlElement(IsNullable = false)]
        public decimal ITBIS1
        {
            get { return this.iTBIS1Field; }
            set { this.iTBIS1Field = value; }
        }

        [XmlIgnore]
        public bool ITBIS1Specified
        {
            get { return this.iTBIS1Specified; }
            set { this.iTBIS1Specified = value; }
        }

        [XmlElement(IsNullable = false)]
        public decimal ITBIS3
        {
            get { return this.iTBIS3Field; }
            set { this.iTBIS3Field = value; }
        }

        [XmlIgnore]
        public bool ITBIS3Specified
        {
            get { return this.iTBIS3Specified; }
            set { this.iTBIS3Specified = value; }
        }

        [XmlElement(IsNullable = false)]
        public decimal TotalITBIS
        {
            get { return this.totalITBISField; }
            set { this.totalITBISField = value; }
        }

        [XmlIgnore]
        public bool TotalITBISSpecified
        {
            get { return this.totalITBISSpecified; }
            set { this.totalITBISSpecified = value; }
        }

        [XmlElement(IsNullable = false)]
        public decimal TotalITBIS1
        {
            get { return this.totalITBIS1Field; }
            set { this.totalITBIS1Field = value; }
        }

        [XmlIgnore]
        public bool TotalITBIS1Specified
        {
            get { return this.totalITBIS1Specified; }
            set { this.totalITBIS1Specified = value; }
        }

        [XmlElement(IsNullable = false)]
        public decimal TotalITBIS3
        {
            get { return this.totalITBIS3Field; }
            set { this.totalITBIS3Field = value; }
        }

        [XmlIgnore]
        public bool TotalITBIS3Specified
        {
            get { return this.totalITBIS3Specified; }
            set { this.totalITBIS3Specified = value; }
        }

        [XmlElement(IsNullable = false)]
        public decimal TotalITBISRetenido
        {
            get { return this.totalITBISRetenidoField; }
            set { this.totalITBISRetenidoField = value; }
        }

        [XmlIgnore]
        public bool TotalITBISRetenidoSpecified
        {
            get { return this.totalITBISRetenidoSpecified; }
            set { this.totalITBISRetenidoSpecified = value; }
        }

        [XmlElement(IsNullable = false)]
        public decimal TotalISRRetencion
        {
            get { return this.totalISRRetencionField; }
            set { this.totalISRRetencionField = value; }
        }

        [XmlIgnore]
        public bool TotalISRRetencionSpecified
        {
            get { return this.totalISRRetencionSpecified; }
            set { this.totalISRRetencionSpecified = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ECFItem
    {

        private int numeroLineaField;

        private int indicadorFacturacionField;

        private ECFDetallesItemsItemRetencion retencionField;

        private string nombreItemField;

        private int indicadorBienoServicioField;

        private decimal cantidadItemField;

        private int unidadMedidaField;

        private decimal precioUnitarioItemField;

        private decimal descuentoMontoField;

        private bool descuentoMontoSpecified;

        private ECFItemSubDescuento[] tablaSubDescuentoField;

        private decimal recargoMontoField;

        private bool recargoMontoFieldSpecified;

        private ECFItemTablaSubRecargo tablaSubRecargoField;

        private decimal montoItemField;

        [XmlElement(IsNullable = false)]
        public int NumeroLinea
        {
            get
            {
                return this.numeroLineaField;
            }
            set
            {
                this.numeroLineaField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public int IndicadorFacturacion
        {
            get
            {
                return this.indicadorFacturacionField;
            }
            set
            {
                this.indicadorFacturacionField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public ECFDetallesItemsItemRetencion Retencion
        {
            get
            {
                return this.retencionField;
            }
            set
            {
                this.retencionField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string NombreItem
        {
            get
            {
                return this.nombreItemField;
            }
            set
            {
                this.nombreItemField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public int IndicadorBienoServicio
        {
            get
            {
                return this.indicadorBienoServicioField;
            }
            set
            {
                this.indicadorBienoServicioField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public decimal CantidadItem
        {
            get
            {
                return this.cantidadItemField;
            }
            set
            {
                this.cantidadItemField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public int UnidadMedida
        {
            get
            {
                return this.unidadMedidaField;
            }
            set
            {
                this.unidadMedidaField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public decimal PrecioUnitarioItem
        {
            get
            {
                return this.precioUnitarioItemField;
            }
            set
            {
                this.precioUnitarioItemField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public decimal DescuentoMonto
        {
            get
            {
                return this.descuentoMontoField;
            }
            set
            {
                this.descuentoMontoField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DescuentoMontoSpecified
        {
            get
            {
                return this.descuentoMontoSpecified;
            }
            set
            {
                this.descuentoMontoSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("SubDescuento", IsNullable = false)]
        public ECFItemSubDescuento[] TablaSubDescuento
        {
            get
            {
                return this.tablaSubDescuentoField;
            }
            set
            {
                this.tablaSubDescuentoField = value;
            }
        }

        /// <remarks/>
        public decimal RecargoMonto
        {
            get
            {
                return this.recargoMontoField;
            }
            set
            {
                this.recargoMontoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RecargoMontoSpecified
        {
            get
            {
                return this.recargoMontoFieldSpecified;
            }
            set
            {
                this.recargoMontoFieldSpecified = value;
            }
        }

        /// <remarks/>
        public ECFItemTablaSubRecargo TablaSubRecargo
        {
            get
            {
                return this.tablaSubRecargoField;
            }
            set
            {
                this.tablaSubRecargoField = value;
            }
        }

        /// <remarks/>
        public decimal MontoItem
        {
            get
            {
                return this.montoItemField;
            }
            set
            {
                this.montoItemField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ECFItemSubDescuento
    {

        private string tipoSubDescuentoField;

        private decimal montoSubDescuentoField;

        [XmlElement(IsNullable = false)]
        public string TipoSubDescuento
        {
            get
            {
                return this.tipoSubDescuentoField;
            }
            set
            {
                this.tipoSubDescuentoField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public decimal MontoSubDescuento
        {
            get
            {
                return this.montoSubDescuentoField;
            }
            set
            {
                this.montoSubDescuentoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ECFItemTablaSubRecargo
    {

        private ECFItemTablaSubRecargoSubRecargo subRecargoField;

        [XmlElement(IsNullable = false)]
        public ECFItemTablaSubRecargoSubRecargo SubRecargo
        {
            get
            {
                return this.subRecargoField;
            }
            set
            {
                this.subRecargoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ECFItemTablaSubRecargoSubRecargo
    {

        private string tipoSubRecargoField;

        private decimal montoSubRecargoField;

        [XmlElement(IsNullable = false)]
        public string TipoSubRecargo
        {
            get
            {
                return this.tipoSubRecargoField;
            }
            set
            {
                this.tipoSubRecargoField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public decimal MontoSubRecargo
        {
            get
            {
                return this.montoSubRecargoField;
            }
            set
            {
                this.montoSubRecargoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ECFInformacionReferencia
    {

        private string nCFModificadoField;

        private string fechaNCFModificadoField;

        private string codigoModificacionField;

        private string razonModificacionField;

        [XmlElement(IsNullable = false)]
        public string NCFModificado
        {
            get
            {
                return this.nCFModificadoField;
            }
            set
            {
                this.nCFModificadoField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string FechaNCFModificado
        {
            get
            {
                return this.fechaNCFModificadoField;
            }
            set
            {
                this.fechaNCFModificadoField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string CodigoModificacion
        {
            get
            {
                return this.codigoModificacionField;
            }
            set
            {
                this.codigoModificacionField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string RazoModificacion
        {
            get
            {
                return this.razonModificacionField;
            }
            set
            {
                this.razonModificacionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ECFDetallesItemsItemRetencion
    {

        private byte indicadorAgenteRetencionoPercepcionField;

        private decimal montoITBISRetenidoField;

        private decimal montoISRRetenidoField;

        [XmlElement(IsNullable = false)]
        public byte IndicadorAgenteRetencionoPercepcion
        {
            get
            {
                return this.indicadorAgenteRetencionoPercepcionField;
            }
            set
            {
                this.indicadorAgenteRetencionoPercepcionField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public decimal MontoITBISRetenido
        {
            get
            {
                return this.montoITBISRetenidoField;
            }
            set
            {
                this.montoITBISRetenidoField = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public decimal MontoISRRetenido
        {
            get
            {
                return this.montoISRRetenidoField;
            }
            set
            {
                this.montoISRRetenidoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ECFEncabezadoTransporte
    {

        private string viaTransporteField;

        private bool viaTransporteFieldSpecified;

        private string paisOrigenField;

        private bool paisOrigenFieldSpecified;

        private string direccionDestinoField;

        private bool direccionDestinoFieldSpecified;

        private string paisDestinoField;

        private bool paisDestinoFieldSpecified;

        private string numeroAlbaranField;

        private bool numeroAlbaranFieldSpecified;

        [XmlElement(IsNullable = false)]
        public string ViaTransporte
        {
            get
            {
                return this.viaTransporteField;
            }
            set
            {
                this.viaTransporteField = value;
            }
        }

        [XmlIgnore]
        public bool ViaTransporteSpecified
        {
            get
            {
                return this.viaTransporteFieldSpecified;
            }
            set
            {
                this.viaTransporteFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string PaisOrigen
        {
            get
            {
                return this.paisOrigenField;
            }
            set
            {
                this.paisOrigenField = value;
            }
        }

        [XmlIgnore]
        public bool PaisOrigenSpecified
        {
            get
            {
                return this.paisOrigenFieldSpecified;
            }
            set
            {
                this.paisOrigenFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string DireccionDestino
        {
            get
            {
                return this.direccionDestinoField;
            }
            set
            {
                this.direccionDestinoField = value;
            }
        }

        [XmlIgnore]
        public bool DireccionDestinoSpecified
        {
            get
            {
                return this.direccionDestinoFieldSpecified;
            }
            set
            {
                this.direccionDestinoFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string PaisDestino
        {
            get
            {
                return this.paisDestinoField;
            }
            set
            {
                this.paisDestinoField = value;
            }
        }

        [XmlIgnore]
        public bool PaisDestinoSpecified
        {
            get
            {
                return this.paisDestinoFieldSpecified;
            }
            set
            {
                this.paisDestinoFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = false)]
        public string NumeroAlbaran
        {
            get
            {
                return this.numeroAlbaranField;
            }
            set
            {
                this.numeroAlbaranField = value;
            }
        }

        [XmlIgnore]
        public bool NumeroAlbaranSpecified
        {
            get
            {
                return this.numeroAlbaranFieldSpecified;
            }
            set
            {
                this.numeroAlbaranFieldSpecified = value;
            }
        }
    }
}