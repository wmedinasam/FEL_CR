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
    public partial class CertificadorModel
    {

        /// <summary>
        /// Obtener todos los certificadores
        /// </summary>
        /// <returns></returns>
        public ResponseModel<List<CertificadorModel>> Get()
        {
            ResponseModel<List<CertificadorModel>> response = new ResponseModel<List<CertificadorModel>>();
            List<CertificadorModel> lst = new List<CertificadorModel>();
            CertificadorService _certificadorService = new CertificadorService();
            bool success = true;
            string message = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt = _certificadorService.GetAll().Tables[0];
                lst = dt.AsEnumerable().Select(fila => new CertificadorModel
                {
                    Id = Int32.Parse(fila["Id"].ToString()),
                    Name = fila["Name"].ToString(),
                    EndPoint = fila["EndPoint"].ToString(),
                    PrintEndPoint = fila["PrintEndPoint"].ToString(),
                    CommercialName = fila["CommercialName"].ToString(),
                    Nit = fila["Nit"].ToString(),
                    UsuarioWS = fila["UsuarioWS"].ToString(),
                    PasswordWS = fila["PasswordWS"].ToString(),
                    SecurityKey = fila["SecurityKey"].ToString(),
                    Key = fila["Key"].ToString(),
                }).ToList<CertificadorModel>();
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
        /// Obtiene un certificador por su Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ResponseModel<CertificadorModel> Get(int Id)
        {
            ResponseModel<CertificadorModel> response = new ResponseModel<CertificadorModel>();
            List<CertificadorModel> lst = new List<CertificadorModel>();
            bool success = true;
            string message = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                CertificadorService _certificadorService = new CertificadorService();
                dt = _certificadorService.GetById(Id).Tables[0];
                lst = dt.AsEnumerable().Select(fila => new CertificadorModel
                {
                    Id = Int32.Parse(fila["Id"].ToString()),
                    Name = fila["Name"].ToString(),
                    EndPoint = fila["EndPoint"].ToString(),
                    PrintEndPoint = fila["PrintEndPoint"].ToString(),
                    CommercialName = fila["CommercialName"].ToString(),
                    Nit = fila["Nit"].ToString(),
                    UsuarioWS = fila["UsuarioWS"].ToString(),
                    PasswordWS = fila["PasswordWS"].ToString(),
                    SecurityKey = fila["SecurityKey"].ToString(),
                    Key = fila["Key"].ToString(),
                }).ToList<CertificadorModel>();
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
        /// Inserta o actualiza un nuevo certificador
        /// </summary>
        /// <param name="action">Add, Update</param>
        /// <param name="certificador"></param>
        /// <returns></returns>
        public ResponseModel<CertificadorModel> Action(string action, CertificadorModel certificador)
        {
            ResponseModel<CertificadorModel> response = new ResponseModel<CertificadorModel>();
            try
            {
                DataTable dt = new DataTable();
                CertificadorService _certificadorService = new CertificadorService();
                if (action == Convert.ToString(Actions.Add))
                    dt = _certificadorService.Create(certificador).Tables[0];
                else if (action == Convert.ToString(Actions.Update))
                    dt = _certificadorService.Update(certificador).Tables[0];

                var lst = dt.AsEnumerable().Select(fila => new ResponseModel<CertificadorModel>
                {
                    Message = fila["Message"].ToString(),
                    Success = Convert.ToBoolean(fila["Success"])
                }).ToList<ResponseModel<CertificadorModel>>();
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
