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
    public class CertificadorService : IDefaultService<CertificadorModel>
    {
        public DataSet Create(CertificadorModel obj)
        {
            string query = string.Empty;
            query = string.Format($"Insert into dbo.[Certificador] ([Name], [EndPointToken], [EndPointRegDoc], [EndPointFirma], [EndPointVerDoc], [EndPointAnularDoc], [EndPointEnvioContingencia], [CommercialName], [Nit], [UsuarioWS], [PasswordWS]) Values " +
                $"('{obj.Name}', '{obj.EndPointToken}', '{obj.EndPointRegDoc}','{obj.EndPointFirma}', '{obj.EndPointVerDoc}','{obj.EndPointAnularDoc}','{obj.EndPointEnvioContingencia}','{obj.CommercialName}','{obj.Nit}'," +
                $"'{obj.UsuarioWS}','{obj.PasswordWS}'); SELECT '' AS Message, 'True' AS Success;");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }
        public DataSet GetAll()
        {
            var query = string.Format("Select [Id],[Name], [EndPointToken], [EndPointRegDoc], [EndPointFirma], [EndPointVerDoc], [EndPointAnularDoc], [EndPointEnvioContingencia], [CommercialName], [Nit], [UsuarioWS], [PasswordWS] From dbo.[Certificador];");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }
        public DataSet GetById(int Id)
        {
            var query = string.Format("Select [Id], [Name], [EndPointToken], [EndPointRegDoc], [EndPointFirma], [EndPointVerDoc], [EndPointAnularDoc], [EndPointEnvioContingencia], [CommercialName], [Nit], [UsuarioWS], [PasswordWS] From dbo.[Certificador] " +
            $"Where Id = {Id} ;");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }

        public DataSet Update(CertificadorModel obj)
        {
            string query = string.Empty;
            query = string.Format($"Update dbo.[Certificador] Set " +
                $"Name = '{obj.Name}', EndPointToken = '{obj.EndPointToken}',EndPointRegDoc= '{obj.EndPointRegDoc}'," +
                $"EndPointFirma= '{obj.EndPointFirma}', EndPointVerDoc = '{obj.EndPointVerDoc}', EndPointAnularDoc ='{obj.EndPointAnularDoc}'," +
                $"EndPointEnvioContingencia = '{obj.EndPointEnvioContingencia}', CommercialName= '{obj.CommercialName}',Nit = '{obj.Nit}'," +
                $"UsuarioWS= '{obj.UsuarioWS}',PasswordWS='{obj.PasswordWS}' Where Id = {obj.Id}; SELECT '' AS Message, 'True' AS Success;");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }
    }
}
