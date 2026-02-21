using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIS_Security.DAO;

namespace FELCR.Services
{
    public class DocumentService
    {
        public DataSet GetDocumentsByNumber(string documentNumber)
        {
            var query = string.Format($"SELECT [Id]\r\n" +
                                        $",[CompanyId]\r\n" +
                                        $",[SubsidiaryId]\r\n" +
                                        $",[Status]\r\n" +
                                        $",[Result]\r\n" +
                                        $",[SAEDocumentId]\r\n" +
                                        $",[SAENumber]\r\n" +
                                        $",[SAESerial]\r\n" +
                                        $",[SendDate]\r\n" +
                                        $",[DocumentType]\r\n" +
                                        $",[UUID]\r\n" +
                                        $",[AnnulmentUUID]\r\n" +
                                        $",[ControlNumber]\r\n" +
                                        $",[Sign]\r\n" +
                                        $",[ReceivedStamp]" +
                                        $",[url_pdf]" +
                                        $"FROM [FELRD].[dbo].[Document]\r\n WHERE [SAEDocumentId] LIKE '%{documentNumber}%' ");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }

        public DataSet GetDocumentsByDates(string dateInitial, string dateFinal)
        {
            var query = string.Format($"SELECT [Id]\r\n" +
                                        $",[CompanyId]\r\n" +
                                        $",[SubsidiaryId]\r\n" +
                                        $",[Status]\r\n" +
                                        $",[Result]\r\n" +
                                        $",[SAEDocumentId]\r\n" +
                                        $",[SAENumber]\r\n" +
                                        $",[SAESerial]\r\n" +
                                        $",[SendDate]\r\n" +
                                        $",[DocumentType]\r\n" +
                                        $",[UUID]\r\n" +
                                        $",[AnnulmentUUID]\r\n" +
                                        $",[ControlNumber]\r\n" +
                                        $",[Sign]\r\n" +
                                        $",[ReceivedStamp]" +
                                        $",[url_pdf]" +
                                        $"FROM [FELRD].[dbo].[Document]\r\n WHERE TRY_CAST([SendDate] AS DATE) BETWEEN CAST('{dateInitial}' AS DATE) AND CAST('{dateFinal}' AS DATE)");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }
    }
}
