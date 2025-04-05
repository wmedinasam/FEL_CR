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
    public class SaeFelModel
    {
        public ResponseModel<DataTable> GetSaeFelData(int idEmpresa, int idEstablecimiento, string numero, string serie, string tipoDoc, string db, string tableSufix)
        {
            ResponseModel<DataTable> res = new ResponseModel<DataTable>();
            DataTable dt = new DataTable();
            SaeFelService saeFelService = new SaeFelService();
            bool success = true;
            string message = string.Empty;
            try
            {
                dt = saeFelService.GetSaeFelData(idEmpresa, idEstablecimiento, numero, serie, tipoDoc, db, tableSufix).Tables[0];
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            res.Message = message;
            res.Success = success;
            res.Object = dt;
            return res;
        }

        public ResponseModel<DataTable> GetSaeCancelData(int Id)
        {
            ResponseModel<DataTable> res = new ResponseModel<DataTable>();
            DataTable dt = new DataTable();
            SaeFelService saeFelService = new SaeFelService();
            bool success = true;
            string message = string.Empty;
            try
            {
                dt = saeFelService.GetSaeCancelData(Id).Tables[0];
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            res.Message = message;
            res.Success = success;
            res.Object = dt;
            return res;
        }
    }
}
