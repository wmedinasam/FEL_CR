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
    public partial class RoleModel
    {
        /// <summary>
        /// Obtener todos los Roles
        /// </summary>
        /// <returns></returns>
        public ResponseModel<List<RoleModel>> Get()
        {
            ResponseModel<List<RoleModel>> response = new ResponseModel<List<RoleModel>>();
            List<RoleModel> lst = new List<RoleModel>();
            RoleService _RoleService = new RoleService();
            bool success = true;
            string message = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt = _RoleService.GetAll().Tables[0];
                lst = dt.AsEnumerable().Select(fila => new RoleModel
                {
                    Id = Int32.Parse(fila["Id"].ToString()),
                    Name = fila["Name"].ToString(),
                    State = Convert.ToBoolean(fila["State"].ToString()),
                    CanAccessMonitor = Convert.ToBoolean(fila["CanAccessMonitor"].ToString()),
                    CanCancel = Convert.ToBoolean(fila["CanCancel"].ToString()),
                    CanAccessDocuments = Convert.ToBoolean(fila["CanAccessDocuments"].ToString()),
                    CanAccessCompanies = Convert.ToBoolean(fila["CanAccessCompanies"].ToString()),
                    CanAccessUsers = Convert.ToBoolean(fila["CanAccessUsers"].ToString()),
                    CanAccessLogs = Convert.ToBoolean(fila["CanAccessLogs"].ToString()),
                    CanAccessConfigurations = Convert.ToBoolean(fila["CanAccessConfigurations"].ToString()),
                    CanSign = Convert.ToBoolean(fila["CanSign"].ToString()),
                    CanAccessRoles = Convert.ToBoolean(fila["CanAccessRoles"].ToString()),
                    CanAccessCertifiers = Convert.ToBoolean(fila["CanAccessCertifiers"].ToString())
                }).ToList<RoleModel>();
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
        /// Obtiene un Role por su Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ResponseModel<RoleModel> Get(int Id)
        {
            ResponseModel<RoleModel> response = new ResponseModel<RoleModel>();
            List<RoleModel> lst = new List<RoleModel>();
            bool success = true;
            string message = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                RoleService _RoleService = new RoleService();
                dt = _RoleService.GetById(Id).Tables[0];
                lst = dt.AsEnumerable().Select(fila => new RoleModel
                {
                    Id = Int32.Parse(fila["Id"].ToString()),
                    Name = fila["Name"].ToString(),
                    State = Convert.ToBoolean(fila["State"].ToString()),
                    CanAccessMonitor = Convert.ToBoolean(fila["CanAccessMonitor"].ToString()),
                    CanCancel = Convert.ToBoolean(fila["CanCancel"].ToString()),
                    CanAccessDocuments = Convert.ToBoolean(fila["CanAccessDocuments"].ToString()),
                    CanAccessCompanies = Convert.ToBoolean(fila["CanAccessCompanies"].ToString()),
                    CanAccessUsers = Convert.ToBoolean(fila["CanAccessUsers"].ToString()),
                    CanAccessLogs = Convert.ToBoolean(fila["CanAccessLogs"].ToString()),
                    CanAccessConfigurations = Convert.ToBoolean(fila["CanAccessConfigurations"].ToString()),
                    CanSign = Convert.ToBoolean(fila["CanSign"].ToString()),
                    CanAccessRoles = Convert.ToBoolean(fila["CanAccessRoles"].ToString()),
                    CanAccessCertifiers = Convert.ToBoolean(fila["CanAccessCertifiers"].ToString())
                }).ToList<RoleModel>();
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
        /// Inserta o actualiza un nuevo Role
        /// </summary>
        /// <param name="action">Add, Update</param>
        /// <param name="Role"></param>
        /// <returns></returns>
        public ResponseModel<RoleModel> Action(string action, RoleModel Role)
        {
            ResponseModel<RoleModel> response = new ResponseModel<RoleModel>();
            try
            {
                DataTable dt = new DataTable();
                RoleService _RoleService = new RoleService();
                if (action == Convert.ToString(Actions.Add))
                    dt = _RoleService.Create(Role).Tables[0];
                else if (action == Convert.ToString(Actions.Update))
                    dt = _RoleService.Update(Role).Tables[0];

                var lst = dt.AsEnumerable().Select(fila => new ResponseModel<RoleModel>
                {
                    Message = fila["Message"].ToString(),
                    Success = Convert.ToBoolean(fila["Success"])
                }).ToList<ResponseModel<RoleModel>>();
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
