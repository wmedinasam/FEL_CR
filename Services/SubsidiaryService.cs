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
    public class SubsidiaryService : IDefaultService<SubsidiaryModel>
    {
        public DataSet Create(SubsidiaryModel obj)
        {
            string query = string.Empty;
            query = string.Format($"Insert into dbo.[Subsidiary] ([EstablishmentName], [CompanyId], [EstablishmentCode], [PostalCode], [Country], [SubsidiaryFolder]) Values " +
                $"('{obj.EstablishmentName}', '{obj.Company.Id}','{obj.EstablishmentCode}', '{obj.PostalCode}','{obj.Country}','{obj.SubsidiaryFolder}')" +
                $"; SELECT '' AS Message, 'True' AS Success;");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }

        public DataSet GetAll()
        {
            var query = string.Format("Select [Id], [EstablishmentName], [CompanyId], [EstablishmentCode], [PostalCode], [Country], [SubsidiaryFolder] From dbo.[Subsidiary];");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }

        public DataSet GetById(int Id)
        {
            var query = string.Format("Select [Id],[EstablishmentName], [CompanyId], [EstablishmentCode], [PostalCode], [Country], [SubsidiaryFolder] From dbo.[Subsidiary] " +
                $"Where Id = {Id};");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }

        public DataSet Update(SubsidiaryModel obj)
        {
            string query = string.Empty;
            query = string.Format($"Update dbo.[Subsidiary] Set" +
                $" [EstablishmentName] = '{obj.EstablishmentName}', [CompanyId] = '{obj.Company.Id}', [EstablishmentCode] = '{obj.EstablishmentCode}', [PostalCode] = '{obj.PostalCode}' , [Country] = '{obj.Country}', [SubsidiaryFolder] = '{obj.SubsidiaryFolder}'" +
                $" Where Id = {obj.Id};" +
                $"SELECT '' AS Message, 'True' AS Success;"); ;
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }
    }
}
