using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WIS_Security.DAO
{
    public class DaoConnection
    {
        public static SqlConnection SqConnection()
        {
            HandleCfg config = new HandleCfg();
            var cn = Connection();
            try
            {
                cn.Open();
            }
            catch (Exception ex)
            {
                config.SaveLog("Base de datos", "[Codigo 001] " + "[Error de conectividad en base de datos.] " + "[" + ex.Message + "]");
                throw new Exception("Error al conectarse con la base de datos.", ex);
            }

            return cn;
        }

        /// <summary>
        /// Conectar a la DB, el nombre de la DB debe ser el mismo nombre del sistema enviado en la Key
        /// </summary>
        /// <returns></returns>
        private static SqlConnection Connection()
        {
            ConfigurationModel _configurationModel = new ConfigurationModel();
            HandleCfg config = new HandleCfg();
            var response = _configurationModel.GetConfiguration();
            Console.Write(response);
            var json = config.ReadCfg(_configurationModel.path);
            _configurationModel = JsonConvert.DeserializeObject<ConfigurationModel>(json);
            string connection = string.Empty;
            connection = $"Server={_configurationModel.Key.Instancia.DesencriptarDatos()};Database=FELSV; User Id={_configurationModel.User}; Password={_configurationModel.Password}; Timeout=5;";
            return new SqlConnection(connection);
        }

        public string System()
        {
            ConfigurationModel _configurationModel = new ConfigurationModel();
            HandleCfg config = new HandleCfg();
            var json = config.ReadCfg(_configurationModel.path);
            _configurationModel = JsonConvert.DeserializeObject<ConfigurationModel>(json);
            return _configurationModel.Key.Sistema;
        }

        public static ResponseModel<object> TestConnection(string user, string password, string instance)
        {
            ResponseModel<object> response = new ResponseModel<object>();
            SqlConnection cn = new SqlConnection("Server=" + instance.DesencriptarDatos() + "; Database=FELSV; User Id=" + user + "; Password=" + password + "");
            try
            {
                cn.Open();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error al obtener la conexion:  " + ex.Message;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return response;
        }
    }
}
