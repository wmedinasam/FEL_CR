using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIS_Security.DAO;

namespace FELRD.Services
{
    public class SaeFelService
    {
        public DataSet GetSaeFelData(int pCompanyId, int pSubsidiaryId, string pNumber, string pSerial, string pDocumentType, string pDataBase, string pSuffix)
        {
            DaoProcedure daoProcedure = new DaoProcedure();
            daoProcedure.ProcedureName = "cusp_FEL_WIS";
            daoProcedure.Parameter.Add(new DaoParameter { Name = "@pCompanyId", Value = pCompanyId, Type = System.Data.DbType.String, Out = false });
            daoProcedure.Parameter.Add(new DaoParameter { Name = "@pSubsidiaryId", Value = pSubsidiaryId, Type = System.Data.DbType.String, Out = false });
            daoProcedure.Parameter.Add(new DaoParameter { Name = "@pNumber", Value = pNumber, Type = System.Data.DbType.String, Out = false });
            daoProcedure.Parameter.Add(new DaoParameter { Name = "@pSerial", Value = pSerial, Type = System.Data.DbType.String, Out = false });
            daoProcedure.Parameter.Add(new DaoParameter { Name = "@pDocumentType", Value = pDocumentType, Type = System.Data.DbType.String, Out = false });
            daoProcedure.Parameter.Add(new DaoParameter { Name = "@pDataBase", Value = pDataBase, Type = System.Data.DbType.String, Out = false });
            daoProcedure.Parameter.Add(new DaoParameter { Name = "@pSuffix", Value = pSuffix, Type = System.Data.DbType.String, Out = false });
            var ds = DaoActions.GetMSSqlDataFromSp(daoProcedure);
            return ds;
        }

        public DataSet GetSaeCancelData(int Id)
        {
            DaoProcedure daoProcedure = new DaoProcedure();
            daoProcedure.ProcedureName = "cusp_WIS_FEL_Annulment_Get";
            daoProcedure.Parameter.Add(new DaoParameter { Name = "@Id", Value = Id, Type = System.Data.DbType.Int32, Out = false });
            var ds = DaoActions.GetMSSqlDataFromSp(daoProcedure);
            return ds;
        }
    }
}
