using FELRD.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIS_Security;

namespace FELRD.Models
{
    public partial class TransactionModel
    {
        public ResponseModel<List<TransactionModel>> GetPendings()
        {
            ResponseModel<List<TransactionModel>> res = new ResponseModel<List<TransactionModel>>();
            List<TransactionModel> lst = new List<TransactionModel>();
            TransactionService transactionService = new TransactionService();
            CompanyModel company = new CompanyModel();
            SubsidiaryModel subsidiary = new SubsidiaryModel();
            bool success = true;
            string message = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt = transactionService.GetPendings().Tables[0];
                lst = dt.AsEnumerable().Select(fila => new TransactionModel
                {
                    Id = Convert.ToInt32(fila["Id"]),
                    SAESerial = fila["SAESerial"].ToString(),
                    SAENumber = fila["SAENumber"].ToString(),
                    DocumentType = fila["DocumentType"].ToString(),
                    Company = company.Get(Convert.ToInt32(fila["CompanyId"])).Object,
                    Subsidiary = subsidiary.Get(Convert.ToInt32(fila["SubsidiaryId"])).Object,
                    Status = fila["Status"].ToString()
                }).ToList<TransactionModel>();
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            res.Message = message;
            res.Success = success;
            res.Object = lst;
            return res;
        }

        public ResponseModel<List<TransactionModel>> GetProcessed()
        {
            ResponseModel<List<TransactionModel>> res = new ResponseModel<List<TransactionModel>>();
            List<TransactionModel> lst = new List<TransactionModel>();
            TransactionService transactionService = new TransactionService();
            CompanyModel company = new CompanyModel();
            SubsidiaryModel subsidiary = new SubsidiaryModel();
            bool success = true;
            string message = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt = transactionService.GetProcessed().Tables[0];
                lst = dt.AsEnumerable().Select(fila => new TransactionModel
                {
                    Id = Convert.ToInt32(fila["Id"]),
                    Company = company.Get(Convert.ToInt32(fila["CompanyId"])).Object,
                    Subsidiary = subsidiary.Get(Convert.ToInt32(fila["SubsidiaryId"])).Object,
                    Status = fila["Status"].ToString(),
                    Result = fila["Result"].ToString(),
                    SAEDocumentId = fila["SAEDocumentId"].ToString(),
                    SAESerial = fila["SAESerial"].ToString(),
                    SAENumber = fila["SAESerial"].ToString(),
                    SendDate = Convert.ToDateTime(fila["SendDate"]),
                    DocumentType = fila["DocumentType"].ToString(),
                    UUID = fila["UUID"].ToString(),
                    AnnulmentUUID = fila["AnnulmentUUID"].ToString(),
                    ControlNumber = fila["ControlNumber"].ToString(),
                    Sign = fila["Sign"].ToString(),
                }).ToList<TransactionModel>();
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            res.Message = message;
            res.Success = success;
            res.Object = lst;
            return res;
        }



        public ResponseModel<TransactionModel> GetById(int Id)
        {
            ResponseModel<TransactionModel> res = new ResponseModel<TransactionModel>();
            List<TransactionModel> lst = new List<TransactionModel>();
            TransactionService transactionService = new TransactionService();
            CompanyModel company = new CompanyModel();
            SubsidiaryModel subsidiary = new SubsidiaryModel();
            bool success = true;
            string message = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt = transactionService.GetById(Id).Tables[0];
                lst = dt.AsEnumerable().Select(fila => new TransactionModel
                {
                    Id = Convert.ToInt32(fila["Id"]),
                    Company = company.Get(Convert.ToInt32(fila["CompanyId"])).Object,
                    Subsidiary = subsidiary.Get(Convert.ToInt32(fila["SubsidiaryId"])).Object,
                    Status = fila["Status"].ToString(),
                    Result = fila["Result"].ToString(),
                    SAEDocumentId = fila["SAEDocumentId"].ToString(),
                    SAESerial = fila["SAESerial"].ToString(),
                    SAENumber = fila["SAESerial"].ToString(),
                    SendDate = Convert.ToDateTime(fila["SendDate"]),
                    DocumentType = fila["DocumentType"].ToString(),
                    UUID = fila["UUID"].ToString(),
                    AnnulmentUUID = fila["AnnulmentUUID"].ToString(),
                    ControlNumber = fila["ControlNumber"].ToString(),
                    Sign = fila["Sign"].ToString(),
                }).ToList<TransactionModel>();
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            res.Message = message;
            res.Success = success;
            res.Object = lst.FirstOrDefault();
            return res;
        }

        public ResponseModel<object> ActionTransaction(string action, TransactionModel model)
        {
            ResponseModel<object> res = new ResponseModel<object>();
            TransactionService transactionService = new TransactionService();
            try
            {
                DataTable dt = new DataTable();
                if (action == "Accepted")
                {
                    dt = transactionService.ActionTransaction(action,
                                    model.Id,
                                    model.Status,
                                    model.Result,
                                    model.UUID,
                                    model.ControlNumber,
                                    model.Sign,
                                    model.ReceivedStamp).Tables[0];
                }
                else
                {
                    dt = transactionService.ActionTransaction(action,
                                    model.Id,
                                    model.Status,
                                    model.Result).Tables[0];
                }
                var lst = dt.AsEnumerable().Select(fila => new ResponseModel<object>
                {
                    Message = fila["Message"].ToString(),
                    Success = Convert.ToBoolean(fila["Success"])
                }).ToList<ResponseModel<object>>();
                res = lst.FirstOrDefault();
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public ResponseModel<List<TransactionModel>> GetDocumentsByNumber(int documentNumber)
        {
            ResponseModel<List<TransactionModel>> res = new ResponseModel<List<TransactionModel>>();
            List<TransactionModel> lst = new List<TransactionModel>();
            DocumentService documentService = new DocumentService();
            CompanyModel company = new CompanyModel();
            SubsidiaryModel subsidiary = new SubsidiaryModel();
            bool success = true;
            string message = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt = documentService.GetDocumentsByNumber(documentNumber).Tables[0];
                lst = dt.AsEnumerable().Select(fila => new TransactionModel
                {
                    Id = Convert.ToInt32(fila["Id"]),
                    Company = company.Get(Convert.ToInt32(fila["CompanyId"])).Object,
                    Subsidiary = subsidiary.Get(Convert.ToInt32(fila["SubsidiaryId"])).Object,
                    Status = fila["Status"].ToString(),
                    Result = fila["Result"].ToString(),
                    SAEDocumentId = fila["SAEDocumentId"].ToString(),
                    SAENumber = fila["SAESerial"].ToString(),
                    SAESerial = fila["SAESerial"].ToString(),
                    SendDate = Convert.ToDateTime(fila["SendDate"]),
                    DocumentType = fila["DocumentType"].ToString(),
                    UUID = fila["UUID"].ToString(),
                    AnnulmentUUID = fila["AnnulmentUUID"].ToString(),
                    ControlNumber = fila["ControlNumber"].ToString(),
                    Sign = fila["Sign"].ToString(),
                    ReceivedStamp = fila["ReceivedStamp"].ToString(),
                }).ToList<TransactionModel>();
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            res.Message = message;
            res.Success = success;
            res.Object = lst;
            return res;
        }

        public ResponseModel<List<TransactionModel>> GetDocumentsByDates(string dateInit, string dateEnd)
        {
            ResponseModel<List<TransactionModel>> res = new ResponseModel<List<TransactionModel>>();
            List<TransactionModel> lst = new List<TransactionModel>();
            DocumentService documentService = new DocumentService();
            CompanyModel company = new CompanyModel();
            SubsidiaryModel subsidiary = new SubsidiaryModel();
            bool success = true;
            string message = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt = documentService.GetDocumentsByDates(dateInit, dateEnd).Tables[0];
                lst = dt.AsEnumerable().Select(fila => new TransactionModel
                {
                    Id = Convert.ToInt32(fila["Id"]),
                    Company = company.Get(Convert.ToInt32(fila["CompanyId"])).Object,
                    Subsidiary = subsidiary.Get(Convert.ToInt32(fila["SubsidiaryId"])).Object,
                    Status = fila["Status"].ToString(),
                    Result = fila["Result"].ToString(),
                    SAEDocumentId = fila["SAEDocumentId"].ToString(),
                    SAENumber = fila["SAESerial"].ToString(),
                    SAESerial = fila["SAESerial"].ToString(),
                    SendDate = Convert.ToDateTime(fila["SendDate"]),
                    DocumentType = fila["DocumentType"].ToString(),
                    UUID = fila["UUID"].ToString(),
                    AnnulmentUUID = fila["AnnulmentUUID"].ToString(),
                    ControlNumber = fila["ControlNumber"].ToString(),
                    Sign = fila["Sign"].ToString(),
                    ReceivedStamp = fila["ReceivedStamp"].ToString(),
                }).ToList<TransactionModel>();
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            res.Message = message;
            res.Success = success;
            res.Object = lst;
            return res;
        }
    }
}
