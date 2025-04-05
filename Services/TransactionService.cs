using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIS_Security.DAO;

namespace FELRD.Services
{
    public class TransactionService
    {
        public DataSet GetPendings()
        {
            DaoProcedure daoProcedure = new DaoProcedure();
            daoProcedure.ProcedureName = "FEL_GetPendings";
            var ds = DaoActions.GetMSSqlDataFromSp(daoProcedure);
            return ds;
        }

        public DataSet GetProcessed()
        {
            var query = string.Format($"SELECT [Id]\r\n      ,[CompanyId]\r\n      ,[SubsidiaryId]\r\n      ,[Status]\r\n      ,[Result]\r\n      ,[SAEDocumentId]\r\n      ,[SAENumber]\r\n      ,[SAESerial]\r\n      ,[SendDate]\r\n      ,[DocumentType]\r\n      ,[UUID]\r\n      ,[AnnulmentUUID]\r\n      ,[ControlNumber]\r\n      ,[Sign]  FROM [FELRD].[dbo].[Document] Order by [Id] Desc\r\n  ");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }

        public DataSet GetById(int Id)
        {
            var query = string.Format($"SELECT [Id]\r\n      ,[CompanyId]\r\n      ,[SubsidiaryId]\r\n      ,[Status]\r\n      ,[Result]\r\n      ,[SAEDocumentId]\r\n      ,[SAENumber]\r\n      ,[SAESerial]\r\n      ,[SendDate]\r\n      ,[DocumentType]\r\n      ,[UUID]\r\n      ,[AnnulmentUUID]\r\n      ,[ControlNumber]\r\n      ,[Sign]  FROM [FELRD].[dbo].[Document]\r\n WHERE Id = {Id} ");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }

        public DataSet ActionTransaction(
                               string Action,
                               int Id,
                               string Status,
                               string Result
                               )
        {
            string query = string.Empty;
            if (Action == "ChangeStatus")
            {
                query = string.Format("UPDATE [dbo].[Document] " +
                                    $"SET [Status] = '{Status}' " +
                                    $"WHERE [Id] = {Id} ");
            }
            if (Action.Equals("ChangeStatusResult") || Action.Equals("Cancelled"))
            {
                query = string.Format("UPDATE [dbo].[Document] " +
                                    $"SET [Status] = '{Status}' " +
                                    $", [Result] = '{Result.Replace("'", "")}' " +
                                    $"WHERE [Id] = {Id} ");
            }
            var ds = DaoActions.ExecuteMSSqlQuery(query);
            return ds;
        }

        public DataSet ActionTransaction(
                               string Action,
                               int Id,
                               string Status,
                               string Result,
                               string UUID,
                               string ControlNumber,
                               string Sign,
                               string ReceivedStamp
                               )
        {
            string query = string.Empty;
            if (Action == "Accepted")
            {
                query = string.Format("UPDATE [dbo].[Document] " +
                                    $"SET [Status] = '{Status}' " +
                                    $", [Result] = '{Result}' " +
                                    $", [UUID] = '{UUID}' " +
                                    $", [ControlNumber] = '{ControlNumber}' " +
                                    $", [Sign] = '{Sign}' " +
                                    $", [ReceivedStamp] = '{ReceivedStamp}' " +
                                    $"WHERE [Id] = {Id} ");
            }
            var ds = DaoActions.ExecuteMSSqlQuery(query);
            return ds;
        }
    }
}
