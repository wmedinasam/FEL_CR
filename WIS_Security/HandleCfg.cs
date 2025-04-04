using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIS_Security
{
    public class HandleCfg
    {
        public  string GetLogPath()
        {
            var path = ConfigurationManager.AppSettings["LogDirectory"];
            return path;
        }

        public  string GetPDFPath()
        {
            var path = ConfigurationManager.AppSettings["RutaPDF"];
            return path;
        }

        public  ResponseModel<object> SaveCfg(string text, string path)
        {
            ResponseModel<object> response = new ResponseModel<object>();
            try
            {
                StreamWriter sw = new StreamWriter(path, false);
                sw.WriteLine(text.EncriptarDatos());
                sw.Close();
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public string ReadCfg(string path)
        {
            string line = string.Empty;
            try
            {
                StreamReader sr = new StreamReader(path);
                line = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return line.DesencriptarDatos();
        }

        public  bool CfgExists(string path)
        {
            return File.Exists(path);
        }

        public  String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMdd");
        }

        public  void SaveLog(string type, string description, string consulta)
        {
            String timeStamp = GetTimestamp(DateTime.Now);
            LogModel logModel = new LogModel();
            logModel.Date = DateTime.Now.ToString();
            logModel.Type = type;
            logModel.Description = description;
            logModel.Consulta = consulta;
            string path = GetLogPath();
            using (StreamWriter sw = File.AppendText(path + @"\Logs\Log" + timeStamp + ".log"))
            {
                sw.WriteLine(JsonConvert.SerializeObject(logModel));
            }
        }
        public  void SaveLog(string type, string description)
        {
            String timeStamp = GetTimestamp(DateTime.Now);
            LogModel logModel = new LogModel();
            logModel.Date = DateTime.Now.ToString();
            logModel.Type = type;
            logModel.Description = description;
            string path = GetLogPath();
            using (StreamWriter sw = File.AppendText(path + @"\Logs\Log" + timeStamp + ".log"))
            {
                sw.WriteLine(JsonConvert.SerializeObject(logModel));
            }
        }
        public  string ReadLog(string path)
        {
            string line = string.Empty;
            try
            {
                if (File.Exists(path))
                {
                    StreamReader sr = new StreamReader(path);
                    line = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return line;
        }

        public  ResponseModel<object> SaveXml(string xml, string path, string name)
        {
            ResponseModel<object> response = new ResponseModel<object>();
            try
            {
                StreamWriter sw = new StreamWriter(path + name, false);
                sw.WriteLine(xml);
                sw.Close();
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public  ResponseModel<object> SavePdf(string pdf, string path, string name)
        {
            ResponseModel<object> response = new ResponseModel<object>();
            try
            {
                string pathDocName = System.IO.Path.Combine($"{path}\\{name}.pdf");
                File.WriteAllBytes(pathDocName, Convert.FromBase64String(pdf));
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
