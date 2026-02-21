USE FELCR
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