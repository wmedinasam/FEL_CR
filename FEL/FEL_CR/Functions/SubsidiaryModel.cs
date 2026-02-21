using FELCR.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIS_Security;
using static FELCR.Models.Helpers;

namespace FELCR.Models
{
    public partial class SubsidiaryModel
    {
        public ResponseModel<List<SubsidiaryModel>> Get()
        {
            ResponseModel<List<SubsidiaryModel>> response = new ResponseModel<List<SubsidiaryModel>>();
            List<SubsidiaryModel> lst = new List<SubsidiaryModel>();
            CompanyModel companyModel = new CompanyModel();
            SubsidiaryService _SubsidiaryService = new SubsidiaryService();
            bool success = true;
            string message = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt = _SubsidiaryService.GetAll().Tables[0];
                lst = dt.AsEnumerable().Select(fila => new SubsidiaryModel
                {
                    Id = Int32.Parse(fila["Id"].ToString()),
                    EstablishmentName = fila["EstablishmentName"].ToString(),
                    Company = companyModel.Get(Int32.Parse(fila["CompanyId"].ToString())).Object,
                    EstablishmentCode = fila["EstablishmentCode"].ToString(),
                    PostalCode = fila["PostalCode"].ToString(),
                    Country = fila["Country"].ToString(),
                    SubsidiaryFolder = fila["SubsidiaryFolder"].ToString(),
                }).ToList<SubsidiaryModel>();
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

        public ResponseModel<SubsidiaryModel> Get(int Id)
        {
            ResponseModel<SubsidiaryModel> response = new ResponseModel<SubsidiaryModel>();
            List<SubsidiaryModel> lst = new List<SubsidiaryModel>();
            CompanyModel companyModel = new CompanyModel();
            SubsidiaryService _SubsidiaryService = new SubsidiaryService();
            bool success = true;
            string message = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt = _SubsidiaryService.GetById(Id).Tables[0];
                lst = dt.AsEnumerable().Select(fila => new SubsidiaryModel
                {
                    Id = Int32.Parse(fila["Id"].ToString()),
                    EstablishmentName = fila["EstablishmentName"].ToString(),
                    Company = companyModel.Get(Int32.Parse(fila["CompanyId"].ToString())).Object,
                    EstablishmentCode = fila["EstablishmentCode"].ToString(),
                    PostalCode = fila["PostalCode"].ToString(),
                    Country = fila["Country"].ToString(),
                    SubsidiaryFolder = fila["SubsidiaryFolder"].ToString(),
                }).ToList<SubsidiaryModel>();
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
        public ResponseModel<SubsidiaryModel> Action(string action, SubsidiaryModel Company)
        {
            ResponseModel<SubsidiaryModel> response = new ResponseModel<SubsidiaryModel>();
            try
            {
                DataTable dt = new DataTable();
                SubsidiaryService _SubsidiaryService = new SubsidiaryService();
                if (action == Convert.ToString(Actions.Add))
                    dt = _SubsidiaryService.Create(Company).Tables[0];
                else if (action == Convert.ToString(Actions.Update))
                    dt = _SubsidiaryService.Update(Company).Tables[0];

                var lst = dt.AsEnumerable().Select(fila => new ResponseModel<SubsidiaryModel>
                {
                    Message = fila["Message"].ToString(),
                    Success = Convert.ToBoolean(fila["Success"])
                }).ToList<ResponseModel<SubsidiaryModel>>();
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
