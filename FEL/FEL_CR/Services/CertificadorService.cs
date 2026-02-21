using FELCR.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIS_Security.DAO;

namespace FELCR.Services
{
    public class CertificadorService : IDefaultService<CertificadorModel>
    {
        public DataSet Create(CertificadorModel obj)
        {
            string query = string.Empty;
            query = string.Format($"Insert into dbo.[Certificador] ([Name], [EndPoint], [PrintEndPoint] , [CommercialName], [Nit], [UsuarioWS], [PasswordWS], [Key] , [SecurityKey]) Values " +
                $"('{obj.Name}', '{obj.EndPoint}', '{obj.CommercialName}','{obj.Nit}'," +
                $"'{obj.UsuarioWS}','{obj.PasswordWS}', '{obj.SecurityKey}'); SELECT '' AS Message, 'True' AS Success;");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }
        public DataSet GetAll()
        {
            var query = string.Format("Select [Id],[Name], [EndPoint], [PrintEndPoint], [CommercialName], [Nit], [UsuarioWS], [PasswordWS], [Key], [SecurityKey] From dbo.[Certificador];");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }
        public DataSet GetById(int Id)
        {
            var query = string.Format("Select [Id], [Name], [EndPoint], [PrintEndPoint], [CommercialName], [Nit], [UsuarioWS], [PasswordWS], [Key], [SecurityKey] From dbo.[Certificador] " +
            $"Where Id = {Id} ;");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }

        public DataSet Update(CertificadorModel obj)
        {
            string query = string.Empty;
            query = string.Format($"Update dbo.[Certificador] Set " +
                $"Name = '{obj.Name}', EndPoint = '{obj.EndPoint}', PrintEndPoint = '{obj.PrintEndPoint}', " +
                $"CommercialName= '{obj.CommercialName}',Nit = '{obj.Nit}'," +
                $"UsuarioWS= '{obj.UsuarioWS}',PasswordWS='{obj.PasswordWS}', [Key]='{obj.Key}', SecurityKey ='{obj.SecurityKey}' Where Id = {obj.Id}; SELECT '' AS Message, 'True' AS Success;");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }
    }
}
