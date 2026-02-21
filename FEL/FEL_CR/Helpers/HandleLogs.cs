using FELCR.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FELCR.Helpers
{
    public class HandleLogs
    {
        public static string GetLogPath()
        {
            var path = ConfigurationManager.AppSettings["LogDirectory"];
            return path;
        }

        public static string GetJsonPath()
        {
            var path = ConfigurationManager.AppSettings["JsonDirectory"];
            return path;
        }

        public static string GetXMLPath()
        {
            var path = ConfigurationManager.AppSettings["XMLDirectory"];
            if (string.IsNullOrWhiteSpace(path))
            {
                path = AppDomain.CurrentDomain.BaseDirectory;
            }
            return path;
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMdd");
        }

        public static void SaveLog(string type, string description, string consulta)
        {
            String timeStamp = GetTimestamp(DateTime.Now);
            LogModel logModel = new LogModel();
            logModel.Date = DateTime.Now.ToString();
            logModel.Type = type;
            logModel.Description = description;
            logModel.Consulta = consulta;
            string path = GetLogPath();
            var fullPath = $"{path}\\Logs";
            // validar existencia del path            
            if (!Directory.Exists(fullPath))
            {
                DirectoryInfo di = Directory.CreateDirectory(fullPath);
            }
            using (StreamWriter sw = File.AppendText(fullPath + @"\Log" + timeStamp + ".log"))
            {
                sw.WriteLine(JsonSerializer.Serialize(logModel));
            }
        }

        public static void SaveLog(string type, string description)
        {
            String timeStamp = GetTimestamp(DateTime.Now);
            LogModel logModel = new LogModel();
            logModel.Date = DateTime.Now.ToString();
            logModel.Type = type;
            logModel.Description = description;
            string path = GetLogPath();
            var fullPath = $"{path}\\Logs";
            // validar existencia del path            
            if (!Directory.Exists(fullPath))
            {
                DirectoryInfo di = Directory.CreateDirectory(fullPath);
            }
            using (StreamWriter sw = File.AppendText(path + @"\Logs\Log" + timeStamp + ".log"))
            {
                sw.WriteLine(JsonSerializer.Serialize(logModel));
            }
        }

        public static void SaveJson(string document, string output)
        {
            string path = GetJsonPath();
            var fullPath = $"{path}\\Json";
            // validar existencia del path            
            if (!Directory.Exists(fullPath))
            {
                DirectoryInfo di = Directory.CreateDirectory(fullPath);
            }
            using (StreamWriter writetext = new StreamWriter(fullPath + @"\" + document + ".json"))
            {
                writetext.WriteLine(output);
            }
        }

        public static void SaveXML(string document, string output)
        {
            string path = GetXMLPath();
            var fullPath = System.IO.Path.Combine(path, "XML");
            // validar existencia del path
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            var filePath = System.IO.Path.Combine(fullPath, document + ".xml");

            // Si el archivo existe, eliminarlo para conservar sólo el nuevo
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Escribir el nuevo contenido (crea el archivo si no existe)
            File.WriteAllText(filePath, output, Encoding.UTF8);
        }

        public static string ReadLog(string path)
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
    }
}
