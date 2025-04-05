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
    public partial class DashboardModel
    {
        public DashboardModel()
        {
        }

        DashboardService _dashboardService = new DashboardService();
        public ResponseModel<List<DashboardModel>> GetDashboard()
        {
            ResponseModel<List<DashboardModel>> res = new ResponseModel<List<DashboardModel>>();
            List<DashboardModel> lst = new List<DashboardModel>();
            bool success = true;
            string message = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt = _dashboardService.GetDashboard().Tables[0];
                lst = dt.AsEnumerable().Select(fila => new DashboardModel
                {
                    Users = fila["Users"].ToString(),
                    Documents = fila["Documents"].ToString(),
                }).ToList<DashboardModel>();
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
