USE [FELRD]
GO
/****** Object:  StoredProcedure [dbo].[cusp_FEL_WIS]    Script Date: 14/04/2025 20:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<WIS>
-- Create date: <09/02/2024>
-- Description:	<Obtiene información FEL de documento>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[cusp_FEL_WIS] 
	@pCompanyId AS int=0,
	@pSubsidiaryId AS int = 0,
	@pNumber AS INT = 0,
	@pSerial AS VARCHAR(10) = null,
	@pDocumentType AS VARCHAR(4) = NULL,
	@pDataBase AS VARCHAR(255),
	@pSuffix AS VARCHAR(2)
AS
BEGIN
	SET NOCOUNT ON;

--IF     (@pDocumentType='FCAM') -------- FACTURA CAMBIARIA
--BEGIN
--	EXEC cusp_FEL_WIS_FCAM @pCompanyId,@pSubsidiaryId,@pNumber,@pSerial,@pDataBase,@pSuffix
--END
--ELSE 
IF(@pDocumentType='FCAM') -------- FACTURA
BEGIN
	EXEC cusp_WIS_FEL_FCAM_Get 
	@pCompanyId,
	@pSubsidiaryId,
	@pDataBase,
	@pSuffix,
	@pNumber,
	@pSerial		
END
ELSE IF(@pDocumentType='CFIS') -------- COMPROBANTE CRÉDITO FISCAL
BEGIN
	EXEC cusp_WIS_FEL_CCFIS_Get @pCompanyId,@pSubsidiaryId,@pNumber,@pSerial,@pDataBase,@pSuffix
END
ELSE IF(@pDocumentType='NCRE') -------- NOTA DE CREDITO
BEGIN
	EXEC cusp_WIS_FEL_NCRE_Get @pCompanyId,@pSubsidiaryId,@pNumber,@pSerial,@pDataBase,@pSuffix
END
ELSE IF(@pDocumentType='FEXP')
BEGIN
	EXEC cusp_WIS_FEL_FEXP_Get 
	@pCompanyId,
	@pSubsidiaryId,
	@pDataBase,
	@pSuffix,
	@pNumber,
	@pSerial	
END

--ELSE IF(@pDocumentType='NABN') -------- NOTA DE ABONO
--BEGIN
--	EXEC cusp_FEL_WIS_NABN @pCompanyId,@pSubsidiaryId,@pNumber,@pSerial,@pDataBase,@pSuffix
--END
--ELSE IF(@pDocumentType='NDEB') -------- NOTA DE DEBITO
--BEGIN
--	EXEC cusp_FEL_WIS_NDEB @pCompanyId,@pSubsidiaryId,@pNumber,@pSerial,@pDataBase,@pSuffix
--END
--ELSE IF(@pDocumentType='FACA') -------- FACTURA CONTRIBUYENTE AGROPECUARIO
--BEGIN
--	EXEC cusp_FEL_WIS_FACA @pCompanyId,@pSubsidiaryId,@pNumber,@pSerial,,@pDataBase,@pSuffix
--END
--ELSE IF(@pDocumentType='FCCA') -------- FACTURA CAMBIARIA CONTRIBUYENTE AGROPECUARIO
--BEGIN
--	EXEC cusp_FEL_WIS_FCCA @pCompanyId,@pSubsidiaryId,@pNumber,@pSerial,@pDataBase,@pSuffix
--END
--ELSE IF(@pDocumentType='FAAE') -------- FACTURA CONTRIBUYENTE AGROPECUARIO REGIMEN ELECTRONICO ESPECIAL
--BEGIN
--	EXEC cusp_FEL_WIS_FAAE @pCompanyId,@pSubsidiaryId,@pNumber,@pSerial,@pDataBase,@pSuffix
--END
--ELSE IF(@pDocumentType='FCAE') -------- FACTURA CAMBIARIA CONTRIBUYENTE AGROPECUARIO REGIMEN ELECTRONICO ESPECIAL
--BEGIN
--	EXEC cusp_FEL_WIS_FCAE @pCompanyId,@pSubsidiaryId,@pNumber,@pSerial,@pDataBase,@pSuffix
--END


END

GO
/****** Object:  StoredProcedure [dbo].[cusp_WIS_FEL_FACT_Get]    Script Date: 14/04/2025 20:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[cusp_WIS_FEL_FACT_Get] 
	@CompanyId AS INT,
	@SubsidiaryId AS INT,
	@DatabaseName AS VARCHAR(50),
	@TableSuffix AS VARCHAR(2),
	@Number AS INT,
	@Serial AS VARCHAR(10) AS 
BEGIN 
exec (
'
	SELECT	
		''1.0'' As [Version],
		32 As TipoeCF,
		encabezado.FOLIO As eNCF,
		''01'' As TipoIngresos,
		1 As TipoPago,
		-- *************************** Emisor
		empresa.Nit As [RNCEmisor],	
		empresa.Name As [RazonSocialEmisor],
		sucursal.EstablishmentName As [NombreComercial],
		empresa.Address As [DireccionEmisor],
		empresa.Municipality As Municipio,
		empresa.Province As Provincia,
		empresa.Phone As TelefonoEmisor,
		null As CorreoEmisor,
		null As WebSite,
		null As CodigoVendedor,
		encabezado.CVE_DOC As NumeroFacturaInterna,
		null As NumeroPedidoInterno,
		null As ZonaVenta,
		format(encabezado.FECHA_DOC,''dd-MM-yyyy'',''en-US'') As FechaEmision,
		-- *************************** Comprador
		cliente.RFC As RNCComprador,
		cliente.NOMBRE As RazonSocialComprador,
		null As ContactoComprador,
		null As CorreoComprador,
		cliente.CALLE As DireccionComprador,
		cliente.MUNICIPIO As MunicipioComprador,
		cliente.ESTADO As ProvinciaComprador,
		null As FechaEntrega,
		null As FechaOrdenCompra,
		null As NumeroOdenCompra,
		null As CodigoInternoComprador,
		-- *************************** Items
		detalle.NUM_PAR As NumeroLinea,
		CASE 		
			WHEN detalle.IMPU4 = 18 THEN 1
			WHEN detalle.IMPU4 = 16 THEN 2
			WHEN detalle.IMPU4 = 0  THEN 4
			ELSE 0
		END As IndicadorFacturacion, -- 4 es exento
		inventario.DESCR As NombreItem,
		CASE 
			WHEN inventario.TIPO_ELE = ''P'' THEN 1
			ELSE 2
		END AS IndicadorBienoServicio, 
		detalle.CANT AS CantidadItem,
		43 As UnidadMedida, -- Unidad
		(detalle.PREC * (1+detalle.IMPU4/100)) As PrecioUnitarioItem,
		(detalle.TOT_PARTIDA) * (detalle.DESC1 / 100) As DescuentoMonto,
		(detalle.TOT_PARTIDA + detalle.TOTIMP4) - (detalle.TOT_PARTIDA) * (detalle.DESC1 / 100) As MontoItem,
		encabezado.IMPORTE As Total
	FROM
	' + @DatabaseName + '.dbo.FACTF' + @TableSuffix + ' encabezado INNER JOIN
	' + @DatabaseName + '.dbo.PAR_FACTF' + @TableSuffix + ' detalle ON encabezado.CVE_DOC = detalle.CVE_DOC INNER JOIN
	' + @DatabaseName + '.dbo.FOLIOSF' + @TableSuffix + ' folios ON folios.SERIE = encabezado.SERIE AND folios.TIP_DOC = ''F'' LEFT JOIN
	FELRD.dbo.Document documentos ON encabezado.SERIE = documentos.SAESerial collate database_default AND encabezado.CVE_DOC = documentos.SAEDocumentId collate database_default INNER JOIN
	' + @DatabaseName + '.dbo.CLIE' + @TableSuffix + ' cliente ON encabezado.CVE_CLPV = cliente.CLAVE INNER JOIN
	' + @DatabaseName + '.dbo.INVE' + @TableSuffix + ' inventario ON detalle.CVE_ART = inventario.CVE_ART INNER JOIN
	FELRD.dbo.Subsidiary sucursal ON sucursal.Id = documentos.SubsidiaryId INNER JOIN
	FELRD.dbo.Company empresa ON empresa.Id = documentos.CompanyId
	encabezado.FOLIO =  ' + @Number  + '  AND encabezado.SERIE = ''' + @Serial + ''' AND documentos.CompanyId = ' + @CompanyId  + ' AND documentos.SubsidiaryId = ' + @SubsidiaryId + ';
')
END
GO
/****** Object:  StoredProcedure [dbo].[cusp_WIS_FEL_FCAM_Get]    Script Date: 14/04/2025 20:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- FACTURA NORMAL, CF Y DE EXPORTACION
CREATE OR ALTER  PROCEDURE [dbo].[cusp_WIS_FEL_FCAM_Get] @CompanyId AS INT,
@SubsidiaryId AS INT,
@DatabaseName AS VARCHAR(50),
@TableSuffix AS VARCHAR(2),
@Number AS INT,
@Serial AS VARCHAR(10) AS 
BEGIN 

exec (
    '
	SELECT
		documentos.CompanyId,
		documentos.SubsidiaryId,
		sucursal.Establishmentcode,
		encabezado.CVE_DOC,
		encabezado.SERIE,
		encabezado.FOLIO,
		''2'' AS ExportationItemType, 
		''FCAM'' AS DocumentType,
		CASE 
			WHEN inventario.TIPO_ELE = ''P'' THEN ''1'' 
			ELSE ''2'' 
		END AS [ItemType], 
		CASE 
			WHEN encabezado.CONTADO =''S'' Then ''01''
			ELSE '''' 
		END AS PaymentType,
		cliente.NOMBRE AS Name,
		'''' AS CommercialName,
		''02'' AS IdentityType,
		cliente.RFC AS Nit,
		''NIT'' AS CustomerIdDocumentType,
		cliente.PAIS AS Country,
		cliente.CALLE AS Address,
		'''' AS Email,
		'''' AS ActivityDescription,
		cliente.ESTADO AS Department,
		cliente.MUNICIPIO AS Municipality,
		detalle.CVE_ART AS ProductId,
		detalle.CANT AS Quantity,
		ROUND((round(detalle.PREC,2)/detalle.TIP_CAM),2) AS Price,
		detalle.DESC1 AS [Discount%],
		CASE 
			WHEN detalle.DESC1 != 0 THEN (detalle.PREC/detalle.TIP_CAM)*DESC1/100 * detalle.CANT 
		ELSE 0 END AS [Discount],
		detalle.IMPU4 AS [Tax%],
		detalle.TOTIMP4/detalle.TIP_CAM AS [Tax],
		detalle.TOT_PARTIDA/detalle.TIP_CAM AS [TotalWithoutTax],
		CASE 
			WHEN inventario.UNI_MED = ''pz'' THEN ''59''
			ELSE ''99''
		END AS [UnitOfMeasure],
		inventario.DESCR AS [Description],
		 CASE 
			WHEN inventario.TIPO_ELE = ''P'' THEN ''B'' 
			ELSE ''S'' 
		 END AS [ProductType],
		encabezado.FECHA_DOC As [Date]
	FROM
	' + @DatabaseName + '.dbo.FACTF' + @TableSuffix + ' encabezado INNER JOIN
	' + @DatabaseName + '.dbo.PAR_FACTF' + @TableSuffix + ' detalle ON encabezado.CVE_DOC = detalle.CVE_DOC INNER JOIN
	' + @DatabaseName + '.dbo.FOLIOSF' + @TableSuffix + ' folios ON folios.SERIE = encabezado.SERIE AND folios.TIP_DOC = ''F'' INNER JOIN
	FELRD.dbo.Document documentos ON encabezado.SERIE = documentos.SAESerial collate database_default AND encabezado.CVE_DOC = documentos.SAEDocumentId collate database_default INNER JOIN
	' + @DatabaseName + '.dbo.CLIE' + @TableSuffix + ' cliente ON encabezado.CVE_CLPV = cliente.CLAVE INNER JOIN
	' + @DatabaseName + '.dbo.INVE' + @TableSuffix + ' inventario ON detalle.CVE_ART = inventario.CVE_ART INNER JOIN
	FELRD.dbo.Subsidiary sucursal ON sucursal.Id = documentos.SubsidiaryId
	WHERE 
	encabezado.FOLIO =  ' + @Number  + '  AND encabezado.SERIE = ''' + @Serial + ''' AND documentos.CompanyId = ' + @CompanyId  + ' 
	AND documentos.SubsidiaryId = ' + @SubsidiaryId + ';
')

END
GO
/****** Object:  StoredProcedure [dbo].[cusp_WIS_FEL_FEXP_Get]    Script Date: 14/04/2025 20:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[cusp_WIS_FEL_FEXP_Get] 
	@CompanyId AS INT,
	@SubsidiaryId AS INT,
	@DatabaseName AS VARCHAR(50),
	@TableSuffix AS VARCHAR(2),
	@Number AS INT,
	@Serial AS VARCHAR(10) AS 
BEGIN 
exec (
'
	SELECT	
		''1.0'' As [Version],
		46 As TipoeCF,
		encabezado.FOLIO As eNCF,
		''01'' As TipoIngresos,
		1 As TipoPago,
		-- *************************** Emisor
		empresa.Nit As [RNCEmisor],	
		empresa.Name As [RazonSocialEmisor],
		sucursal.EstablishmentName As [NombreComercial],
		empresa.Address As [DireccionEmisor],
		empresa.Municipality As Municipio,
		empresa.Province As Provincia,
		empresa.Phone As TelefonoEmisor,
		null As CorreoEmisor,
		null As WebSite,
		null As CodigoVendedor,
		encabezado.CVE_DOC As NumeroFacturaInterna,
		null As NumeroPedidoInterno,
		null As ZonaVenta,
		format(encabezado.FECHA_DOC,''dd-MM-yyyy'',''en-US'') As FechaEmision,
		-- *************************** Comprador
		cliente.RFC As RNCComprador,
		cliente.NOMBRE As RazonSocialComprador,
		null As ContactoComprador,
		null As CorreoComprador,
		cliente.CALLE As DireccionComprador,
		cliente.MUNICIPIO As MunicipioComprador,
		cliente.ESTADO As ProvinciaComprador,
		null As FechaEntrega,
		null As FechaOrdenCompra,
		null As NumeroOdenCompra,
		null As CodigoInternoComprador,
		-- *************************** InformacionesAdicionales
		'''' As FechaEmbarque,
		'''' As NumeroEmbarque,
		'''' As NumeroContenedor,
		'''' As NumeroReferencia,
		'''' As NombrePuertoEmbarque,
		'''' As CondicionesEntrega,
		'''' As TotalFob,
		'''' As Seguro,
		'''' As Flete,
		'''' As TotalCif,
		'''' As RegimenAduanero,
		'''' As NombrePuertoSalida,
		'''' As NombrePuertoDesembarque,
		'''' As PesoBruto,
		'''' As PesoNeto,
		'''' As UnidadPesoBruto,
		'''' As UnidadPesoNeto,
		'''' As CantidadBulto,
		'''' As UnidadBulto,
		'''' As VolumenBulto,
		'''' As UnidadVolumen,
		-- *************************** Transporte
		'''' As ViaTransporte,
		'''' As PaisOrigen,
		'''' As DireccionDestino,
		'''' As PaisDestino,
		'''' As NumeroAlbaran,
		-- *************************** Items
		detalle.NUM_PAR As NumeroLinea,
		CASE 		
			WHEN detalle.IMPU4 = 18 THEN 1
			WHEN detalle.IMPU4 = 16 THEN 2
			WHEN detalle.IMPU4 = 0  THEN 4
			ELSE 0
		END As IndicadorFacturacion, -- 4 es exento
		inventario.DESCR As NombreItem,
		CASE 
			WHEN inventario.TIPO_ELE = ''P'' THEN 1
			ELSE 2
		END AS IndicadorBienoServicio, 
		detalle.CANT AS CantidadItem,
		43 As UnidadMedida, -- Unidad
		(detalle.PREC * (1+detalle.IMPU4/100)) As PrecioUnitarioItem,
		(detalle.TOT_PARTIDA) * (detalle.DESC1 / 100) As DescuentoMonto,
		(detalle.TOT_PARTIDA + detalle.TOTIMP4) - (detalle.TOT_PARTIDA) * (detalle.DESC1 / 100) As MontoItem,
		encabezado.IMPORTE As Total
	FROM
	' + @DatabaseName + '.dbo.FACTF' + @TableSuffix + ' encabezado INNER JOIN
	' + @DatabaseName + '.dbo.PAR_FACTF' + @TableSuffix + ' detalle ON encabezado.CVE_DOC = detalle.CVE_DOC INNER JOIN
	' + @DatabaseName + '.dbo.FOLIOSF' + @TableSuffix + ' folios ON folios.SERIE = encabezado.SERIE AND folios.TIP_DOC = ''F'' LEFT JOIN
	FELRD.dbo.Document documentos ON encabezado.SERIE = documentos.SAESerial collate database_default AND encabezado.CVE_DOC = documentos.SAEDocumentId collate database_default INNER JOIN
	' + @DatabaseName + '.dbo.CLIE' + @TableSuffix + ' cliente ON encabezado.CVE_CLPV = cliente.CLAVE INNER JOIN
	' + @DatabaseName + '.dbo.INVE' + @TableSuffix + ' inventario ON detalle.CVE_ART = inventario.CVE_ART INNER JOIN
	FELRD.dbo.Subsidiary sucursal ON sucursal.Id = documentos.SubsidiaryId INNER JOIN
	FELRD.dbo.Company empresa ON empresa.Id = documentos.CompanyId
	encabezado.FOLIO =  ' + @Number  + '  AND encabezado.SERIE = ''' + @Serial + ''' AND documentos.CompanyId = ' + @CompanyId  + ' AND documentos.SubsidiaryId = ' + @SubsidiaryId + ';
')
END
GO
/****** Object:  StoredProcedure [dbo].[FEL_GetPendings]    Script Date: 14/04/2025 20:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER PROCEDURE [dbo].[FEL_GetPendings] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN

	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		d.Id, 
		d.SAESerial,
		d.SAENumber,
		d.DocumentType,  
		e.Id CompanyId, 
		es.Id As [SubsidiaryId], 
		d.Status 
	FROM Document d INNER JOIN 
	Company e ON e.Id = d.CompanyId INNER JOIN 
	Certificador c ON c.Id = e.IdCertificador INNER JOIN
	Subsidiary es ON d.SubsidiaryId = es.Id And d.Id = es.CompanyId
	WHERE d.[Status] = 'PENDIENTE'
END
GO
