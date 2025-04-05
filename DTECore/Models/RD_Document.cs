// NOTA: El código generado puede requerir, como mínimo, .NET Framework 4.5 o .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class ECF
{

    private ECFEncabezado encabezadoField;

    private ECFItem[] detallesItemsField;

    private ECFInformacionReferencia informacionReferenciaField;

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    private decimal versionField;

    private ECFEncabezadoIdDoc idDocField;

    private ECFEncabezadoEmisor emisorField;

    private ECFEncabezadoComprador compradorField;

    private ECFEncabezadoInformacionesAdicionales informacionesAdicionalesField;

    private ECFEncabezadoTransporte transporteField;

    private ECFEncabezadoTotales totalesField;

    /// <remarks/>
    public decimal Version
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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


    /// <remarks/>
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

    /// <remarks/>
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

    private string indicadorMontoGravadoField;

    private string tipoIngresosField;

    private string tipoPagoField;

    private ECFEncabezadoIdDocTablaFormasPago tablaFormasPagoField;

    private string[] textField;

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
    public ECFEncabezadoIdDocTablaFormasPago TablaFormasPago
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

    /// <remarks/>
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

    /// <remarks/>
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
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ECFEncabezadoInformacionesAdicionales
{

    private string fechaEmbarqueField;

    private string numeroEmbarqueField;

    private string numeroContenedorField;

    private ushort numeroReferenciaField;

    private string nombrePuertoEmbarqueField;

    private string condicionesEntregaField;

    private decimal totalFobField;

    private decimal seguroField;

    private decimal fleteField;

    private decimal totalCifField;

    private string regimenAduaneroField;

    private string nombrePuertoSalidaField;

    private string nombrePuertoDesembarqueField;

    private decimal pesoBrutoField;

    private decimal pesoNetoField;

    private byte unidadPesoBrutoField;

    private byte unidadPesoNetoField;

    private decimal cantidadBultoField;

    private byte unidadBultoField;

    private byte volumenBultoField;

    private byte unidadVolumenField;

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
    public ushort NumeroReferencia
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
    public byte UnidadPesoBruto
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

    /// <remarks/>
    public byte UnidadPesoNeto
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

    /// <remarks/>
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

    /// <remarks/>
    public byte UnidadBulto
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

    /// <remarks/>
    public byte VolumenBulto
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

    /// <remarks/>
    public byte UnidadVolumen
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
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ECFEncabezadoIdDocTablaFormasPagoFormaDePago
{

    private byte formaPagoField;

    private decimal montoPagoField;

    /// <remarks/>
    public byte FormaPago
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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


    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    private decimal montoGravadoI1Field;

    private decimal montoExentoField;

    private byte iTBIS1Field;

    private decimal totalITBISField;

    private decimal totalITBIS1Field;

    private decimal montoTotalField;

    private decimal totalITBISRetenidoField;

    private decimal totalISRRetencionField;


    /// <remarks/>
    public decimal MontoGravadoTotal
    {
        get
        {
            return this.montoGravadoTotalField;
        }
        set
        {
            this.montoGravadoTotalField = value;
        }
    }

    /// <remarks/>
    public decimal MontoGravadoI1
    {
        get
        {
            return this.montoGravadoI1Field;
        }
        set
        {
            this.montoGravadoI1Field = value;
        }
    }

    /// <remarks/>
    public decimal MontoExento
    {
        get
        {
            return this.montoExentoField;
        }
        set
        {
            this.montoExentoField = value;
        }
    }

    /// <remarks/>
    public byte ITBIS1
    {
        get
        {
            return this.iTBIS1Field;
        }
        set
        {
            this.iTBIS1Field = value;
        }
    }

    /// <remarks/>
    public decimal TotalITBIS
    {
        get
        {
            return this.totalITBISField;
        }
        set
        {
            this.totalITBISField = value;
        }
    }

    /// <remarks/>
    public decimal TotalITBIS1
    {
        get
        {
            return this.totalITBIS1Field;
        }
        set
        {
            this.totalITBIS1Field = value;
        }
    }

    /// <remarks/>
    public decimal MontoTotal
    {
        get
        {
            return this.montoTotalField;
        }
        set
        {
            this.montoTotalField = value;
        }
    }

    /// <remarks/>
    public decimal TotalITBISRetenido
    {
        get
        {
            return this.totalITBISRetenidoField;
        }
        set
        {
            this.totalITBISRetenidoField = value;
        }
    }

    /// <remarks/>
    public decimal TotalISRRetencion
    {
        get
        {
            return this.totalISRRetencionField;
        }
        set
        {
            this.totalISRRetencionField = value;
        }
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

    private ECFItemSubDescuento[] tablaSubDescuentoField;

    private decimal recargoMontoField;

    private bool recargoMontoFieldSpecified;

    private ECFItemTablaSubRecargo tablaSubRecargoField;

    private decimal montoItemField;

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    private byte codigoModificacionField;

    private string razonModificacionField;

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
    public byte CodigoModificacion
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    private byte viaTransporteField;

    private string paisOrigenField;

    private string direccionDestinoField;

    private string paisDestinoField;

    private string numeroAlbaranField;

    /// <remarks/>
    public byte ViaTransporte
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
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
}