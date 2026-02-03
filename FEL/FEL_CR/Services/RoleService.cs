using FEL_CR.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIS_Security.DAO;

namespace FEL_CR.Services
{
    public class RoleService : IDefaultService<RoleModel>
    {
        public DataSet Create(RoleModel role)
        {
            string query = string.Empty;
            query = string.Format($"Insert into dbo.[Role] ([Name], [State], [CanAccessMonitor], [CanCancel], [CanAccessDocuments],[CanAccessCompanies],[CanAccessUsers],[CanAccessLogs],[CanAccessConfigurations],[CanSign],[CanAccessRoles], [CanAccessCertifiers]) Values ('{role.Name}', '{role.State}', '{role.CanAccessMonitor}','{role.CanCancel}', '{role.CanAccessDocuments}','{role.CanAccessCompanies}','{role.CanAccessUsers}','{role.CanAccessLogs}','{role.CanAccessConfigurations}','{role.CanSign}','{role.CanAccessRoles}','{role.CanAccessCertifiers}'); SELECT '' AS Message, 'True' AS Success;");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }

        public DataSet GetAll()
        {
            var query = string.Format("Select [Id], [Name], [State], [CanAccessMonitor], [CanCancel], [CanAccessDocuments],[CanAccessCompanies],[CanAccessUsers],[CanAccessLogs],[CanAccessConfigurations],[CanSign],[CanAccessRoles],[CanAccessCertifiers] " +
                                        " From dbo.[Role]");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }

        public DataSet Update(RoleModel role)
        {
            string query = string.Empty;
            query = string.Format($"Update dbo.[Role] Set Name = '{role.Name}', State= '{role.State}', CanAccessMonitor='{role.CanAccessMonitor}', CanCancel='{role.CanCancel}',CanAccessDocuments= '{role.CanAccessDocuments}',CanAccessCompanies = '{role.CanAccessCompanies}',CanAccessUsers = '{role.CanAccessUsers}', CanAccessLogs = '{role.CanAccessLogs}', CanAccessConfigurations = '{role.CanAccessConfigurations}',CanSign = '{role.CanSign}', CanAccessRoles = '{role.CanAccessRoles}',CanAccessCertifiers= '{role.CanAccessCertifiers}' Where Id = {role.Id}; SELECT '' AS Message, 'True' AS Success;");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }

        public DataSet GetById(int Id)
        {
            var query = string.Format("Select [Id], [Name], [State], [CanAccessMonitor], [CanCancel], [CanAccessDocuments],[CanAccessCompanies],[CanAccessUsers],[CanAccessLogs],[CanAccessConfigurations],[CanSign],[CanAccessRoles],[CanAccessCertifiers] " +
                                        $" From dbo.[Role] Where Id= {Id}");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }

    }
}
