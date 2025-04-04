using FELRD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIS_Security.DAO;

namespace FELRD.Services
{
    public class UserService : IDefaultService<UserModel>
    {
        public DataSet GetAll()
        {
            var query = string.Format("SELECT [Id] " +
                                            ",[IdRole] " +
                                            ",[UserName] " +
                                            ",[Password] " +
                                            ",[FullName] " +
                                            ",[State] " +
                                        "FROM [dbo].[User];");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }

        public DataSet GetByUserName(string userName)
        {
            var query = string.Format("SELECT [Id] " +
                                            ",[IdRole] " +
                                            ",[UserName] " +
                                            ",[Password] " +
                                            ",[FullName] " +
                                            ",[State] " +
                                        "FROM [dbo].[User] " +
                                        $"WHERE UserName = '{userName}'; ");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }
        public DataSet GetById(int id)
        {
            var query = string.Format("SELECT [Id] " +
                                           ",[IdRole] " +
                                            ",[UserName] " +
                                            ",[Password] " +
                                            ",[FullName] " +
                                            ",[State] " +
                                        "FROM [dbo].[User] " +
                                        $"WHERE Id = {id} ;");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }
        public DataSet Create(UserModel model)
        {
            string query = string.Empty;
            query = string.Format("INSERT INTO [dbo].[User] " +
                                "VALUES " +
                                        $"( {model.role.Id} " +
                                        $",'{model.UserName}' " +
                                        $",'{model.UserPassword}' " +
                                        $",'{model.FullName}' " +
                                        $",'{model.UserStatus}');");
            var ds = DaoActions.ExecuteMSSqlQuery(query);
            return ds;
        }

        public DataSet Update(UserModel model)
        {
            string query = string.Empty;
            query = string.Format("UPDATE [dbo].[User] " +
                                $"SET      [IdRole] = {model.role.Id} " +
                                        $",[UserName] = '{model.UserName}' " +
                                        $",[Password] = '{model.UserPassword}' " +
                                        $",[FullName] = '{model.FullName}' " +
                                        $",[State] = '{model.UserStatus}' " +
                                $"WHERE Id = {model.Id}; ");
            var ds = DaoActions.ExecuteMSSqlQuery(query);
            return ds;
        }
    }
}
