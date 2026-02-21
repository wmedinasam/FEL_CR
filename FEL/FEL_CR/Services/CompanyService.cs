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
    public class CompanyService : IDefaultService<CompanyModel>
    {
        public DataSet Create(CompanyModel obj)
        {
            string query = string.Empty;
            query = string.Format($"Insert into dbo.[Company] ([IdCertificador], [Nit], [Address], [Municipality], [Province], [Phone], [DTEFolder], [DBSAE], [SuffixTable], [Name]) Values " +
                $"('{obj.Certificador.Id}', '{obj.Nit}' , '{obj.Address}', '{obj.Municipality}', '{obj.Province}', '{obj.Phone}' ,'{obj.DTEFolder}', '{obj.DBSAE}','{obj.SuffixTable}','{obj.Name}')" +
                $"; SELECT '' AS Message, 'True' AS Success;");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }

        public DataSet GetAll()
        {
            var query = string.Format("Select [Id], [IdCertificador], [Nit], [Address], [Municipality], [Province], [Phone], [DTEFolder], [DBSAE], [SuffixTable], [Name] From dbo.[Company];");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }

        public DataSet GetById(int Id)
        {
            var query = string.Format("Select [Id],[IdCertificador], [Nit], [Address], [Municipality], [Province], [Phone], [DTEFolder], [DBSAE], [SuffixTable], [Name] From dbo.[Company] " +
                $"Where Id = {Id};");
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }

        public DataSet Update(CompanyModel obj)
        {
            string query = string.Empty;
            query = string.Format($"Update dbo.[Company] Set" +
                $" IdCertificador = {obj.Certificador.Id}, Nit = '{obj.Nit}', Address = '{obj.Address}', Municipality='{obj.Municipality}', Province='{obj.Province}', Phone='{obj.Phone}', DTEFolder = '{obj.DTEFolder}', DBSAE = '{obj.DBSAE}', SuffixTable = '{obj.SuffixTable}', Name = '{obj.Name}'" +
                $" Where Id = {obj.Id};" +
                $"SELECT '' AS Message, 'True' AS Success;"); ;
            var ds = DaoActions.GetMSSqlDataFromQuery(query);
            return ds;
        }
    }
}
