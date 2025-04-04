using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WIS_Security
{
    public partial class ConfigurationModel
    {

        public ConfigurationModel() 
        {
            Key = new KeyModel();
            path = Directory.GetCurrentDirectory() + "\\Configuration.cfg";
        }

        public ResponseModel<ConfigurationModel> GetConfiguration()
        {
            ResponseModel<ConfigurationModel> response = new ResponseModel<ConfigurationModel>();
            ConfigurationModel item = new ConfigurationModel();
            HandleCfg config = new HandleCfg();
            bool success = true;
            string message = string.Empty;
            try
            {
                string dt;
                dt = config.ReadCfg(path);
                item = JsonConvert.DeserializeObject<ConfigurationModel>(dt);
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            response.Message = message;
            response.Success = success;
            response.Object = item;
            return response;
        }

        public ResponseModel<object> SaveConfiguration(ConfigurationModel model)
        {
            ResponseModel<object> res = new ResponseModel<object>();
            HandleCfg config = new HandleCfg();
            bool success = true;
            string message = string.Empty;
            try
            {
                var user = JsonConvert.SerializeObject(model);
                config.SaveCfg(user, path);
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            res.Message = message;
            res.Success = success;
            return res;
        }
    }
}
