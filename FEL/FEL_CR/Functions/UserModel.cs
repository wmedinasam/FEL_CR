using FEL_CR.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIS_Security;

namespace FEL_CR.Models
{
    public partial class UserModel
    {
        public UserModel()
        {
            role = new RoleModel();
        }

        UserService _UserService = new UserService();

        public ResponseModel<List<UserModel>> GetUsers()
        {
            ResponseModel<List<UserModel>> res = new ResponseModel<List<UserModel>>();
            List<UserModel> lst = new List<UserModel>();
            RoleModel role = new RoleModel();
            bool success = true;
            string message = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt = _UserService.GetAll().Tables[0];
                lst = dt.AsEnumerable().Select(fila => new UserModel
                {
                    Id = Int32.Parse(fila["Id"].ToString()),
                    UserName = fila["UserName"].ToString(),
                    UserPassword = fila["Password"].ToString(),
                    UserStatus = Convert.ToBoolean(fila["State"].ToString()),
                    FullName = fila["FullName"].ToString(),
                    role = role.Get(Int32.Parse(fila["IdRole"].ToString())).Object,
                }).ToList<UserModel>();
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

        public ResponseModel<UserModel> GetUserByUserName(string UserFirstName)
        {
            ResponseModel<UserModel> res = new ResponseModel<UserModel>();
            try
            {
                DataTable dt = new DataTable();
                RoleModel role = new RoleModel();
                dt = _UserService.GetByUserName(UserFirstName).Tables[0];
                var lst = dt.AsEnumerable().Select(fila => new UserModel
                {
                    Id = Int32.Parse(fila["Id"].ToString()),
                    UserName = fila["UserName"].ToString(),
                    UserPassword = fila["Password"].ToString(),
                    UserStatus = Convert.ToBoolean(fila["State"].ToString()),
                    FullName = fila["FullName"].ToString(),
                    role = role.Get(Int32.Parse(fila["IdRole"].ToString())).Object,
                }).ToList<UserModel>();
                res.Object = lst.FirstOrDefault();
                res.Success = true;
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }
        public ResponseModel<object> Create(UserModel model)
        {
            ResponseModel<object> res = new ResponseModel<object>();
            try
            {
                DataTable dt = new DataTable();
                dt = _UserService.Create(model).Tables[0];

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
        public ResponseModel<object> Update(UserModel model)
        {
            ResponseModel<object> res = new ResponseModel<object>();
            try
            {
                DataTable dt = new DataTable();
                dt = _UserService.Update(model).Tables[0];

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
    }
}
