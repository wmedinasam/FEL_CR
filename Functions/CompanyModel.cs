using FELRD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FELRD.Models.Helpers;
using WIS_Security;
using FELRD.Services;

namespace FELRD.Models
{
    public partial class CompanyModel
    {
        /// <summary>
        /// Obtener todos los Companies
        /// </summary>
        /// <returns></returns>
        public ResponseModel<List<CompanyModel>> Get()
        {
            ResponseModel<List<CompanyModel>> response = new ResponseModel<List<CompanyModel>>();
            List<CompanyModel> lst = new List<CompanyModel>();
            CertificadorModel certificador = new CertificadorModel();
            CompanyService _CompanyService = new CompanyService();
            bool success = true;
            string message = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt = _CompanyService.GetAll().Tables[0];
                lst = dt.AsEnumerable().Select(fila => new CompanyModel
                {
                    Id = Int32.Parse(fila["Id"].ToString()),
                    Certificador = certificador.Get(Int32.Parse(fila["IdCertificador"].ToString())).Object,
                    Address = fila["Address"].ToString(),
                    Municipality = fila["Municipality"].ToString(),
                    Province = fila["Province"].ToString(),
                    Phone = fila["Phone"].ToString(),
                    DTEFolder = fila["DTEFolder"].ToString(),
                    DBSAE = fila["DBSAE"].ToString(),
                    SuffixTable = fila["SuffixTable"].ToString(),
                    Nit = fila["Nit"].ToString(),
                    Name = fila["Name"].ToString()
                }).ToList<CompanyModel>();
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            response.Message = message;
            response.Success = success;
            response.Object = lst;
            return response;
        }

        /// <summary>
        /// Obtiene un Company por su Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ResponseModel<CompanyModel> Get(int Id)
        {
            ResponseModel<CompanyModel> response = new ResponseModel<CompanyModel>();
            List<CompanyModel> lst = new List<CompanyModel>();
            CertificadorModel certificador = new CertificadorModel();
            bool success = true;
            string message = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                CompanyService _CompanyService = new CompanyService();
                dt = _CompanyService.GetById(Id).Tables[0];
                lst = dt.AsEnumerable().Select(fila => new CompanyModel
                {
                    Id = Int32.Parse(fila["Id"].ToString()),
                    Certificador = certificador.Get(Int32.Parse(fila["IdCertificador"].ToString())).Object,
                    Address = fila["Address"].ToString(),
                    Municipality = fila["Municipality"].ToString(),
                    Province = fila["Province"].ToString(),
                    Phone = fila["Phone"].ToString(),
                    DTEFolder = fila["DTEFolder"].ToString(),
                    DBSAE = fila["DBSAE"].ToString(),
                    SuffixTable = fila["SuffixTable"].ToString(),
                    Nit = fila["Nit"].ToString(),
                    Name = fila["Name"].ToString()
                }).ToList<CompanyModel>();
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            response.Message = message;
            response.Success = success;
            response.Object = lst.FirstOrDefault();
            return response;
        }

        /// <summary>
        /// Inserta o actualiza un nuevo Company
        /// </summary>
        /// <param name="action">Add, Update</param>
        /// <param name="Company"></param>
        /// <returns></returns>
        public ResponseModel<CompanyModel> Action(string action, CompanyModel Company)
        {
            ResponseModel<CompanyModel> response = new ResponseModel<CompanyModel>();
            try
            {
                DataTable dt = new DataTable();
                CompanyService _CompanyService = new CompanyService();
                if (action == Convert.ToString(Actions.Add))
                    dt = _CompanyService.Create(Company).Tables[0];
                else if (action == Convert.ToString(Actions.Update))
                    dt = _CompanyService.Update(Company).Tables[0];

                var lst = dt.AsEnumerable().Select(fila => new ResponseModel<CompanyModel>
                {
                    Message = fila["Message"].ToString(),
                    Success = Convert.ToBoolean(fila["Success"])
                }).ToList<ResponseModel<CompanyModel>>();
                response = lst.FirstOrDefault();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
