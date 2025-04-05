using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIS_Security.DAO;

namespace FELRD.Services
{
    public class SettingService
    {
        public DataSet GetSettings()
        {
            var query = string.Format("SELECT [id] " +
                                            ",[key] " +
                                            ",[value] " +
                                            ",[description] " +
                                        "FROM [dbo].[Setting]");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }
        public DataSet ActionSetting(
                               string action,
                               string id,
                               string key,
                               string value,
                               string description
                               )
        {
            string query = string.Empty;
            if (action == "Insert")
            {
                query = string.Format("INSERT INTO [dbo].[Setting] " +
                                            "([key] " +
                                            ",[value] " +
                                            ",[description]) " +
                                    "VALUES " +
                                            $"('{key}' " +
                                            $",'{value}' " +
                                            $",'{description}')");
            }
            else
            {
                query = string.Format("UPDATE [dbo].[Setting] " +
                                      $"SET [key] = '{key}' " +
                                      $",[value] = '{value}' " +
                                      $",[description] = '{description}' " +
                                      $"WHERE [id] = '{id}' ");
            }

            var ds = DaoActions.ExecuteMSSqlQuery(query);
            return ds;
        }
    }
}
