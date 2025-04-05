using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIS_Security.DAO;

namespace FELRD.Services
{
    public class DashboardService
    {
        public DataSet GetDashboard()
        {
            var query = string.Format("SELECT D.Documents, U.Users FROM " +
                                        "(SELECT count(*) Documents " +
                                        "FROM [dbo].[Document]) D, " +
                                        "(SELECT count(*) Users " +
                                        "FROM [dbo].[User]) U");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }
    }
}
