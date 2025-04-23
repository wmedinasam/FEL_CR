using Newtonsoft.Json;
using ServiceCore.Infile.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WIS_Security;
using static System.Net.WebRequestMethods;

namespace ServiceCore.Infile.Service
{
    public class InfileService
    {
        /// <summary>
        /// Método para obtener el token de autenticación
        /// </summary>
        /// <param name="url"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="key"></param>
        /// <param name="requestToken"></param>
        /// <returns></returns>
        public string GetToken(string url, string username, string password, string key, RequestToken requestToken = null)
        {
            var request = (HttpWebRequest)WebRequest.CreateHttp(url);

            // Autenticación básica           
            string encodedCredentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            request.Headers.Add("Authorization", "Basic " + encodedCredentials);

            // Header adicional
            request.Headers.Add("Security-Key", key);

            // Body del request
            var postData = requestToken;
            string postDataString = JsonConvert.SerializeObject(postData);
            byte[] postDataBytes = Encoding.UTF8.GetBytes(postDataString);

            request.Method = Method.POST.ToString();
            request.ContentType = string.Format($"application/{Model.ContentType.JSON.ToString().ToLower()}");
            request.ContentLength = postDataBytes.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(postDataBytes, 0, postDataBytes.Length);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (response)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string responseText = reader.ReadToEnd();
                        Root responseObject = JsonConvert.DeserializeObject<Root>(responseText);
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            return responseObject.token;
                        }
                        else
                        {
                            return ($"Error: {response.StatusCode}, {responseObject.descripcion}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return ($"Error: {ex.Message} + {ex.StackTrace}");
            }
        }


        /// <summary>
        /// Envio de XML a firma
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="xmlContent"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ResponseModel<RootObject> SendXmlDocument(string url, string token, string xmlContent)
        {
            var request = (HttpWebRequest)WebRequest.CreateHttp(url);
            ResponseModel<RootObject> result = new ResponseModel<RootObject>();
            // Autorización Bearer
            request.Headers.Add("Authorization", "Bearer " + token);

            // Body del request
            byte[] postDataBytes = Encoding.UTF8.GetBytes(xmlContent);

            request.Method = Method.POST.ToString();
            request.ContentType = string.Format($"application/{Model.ContentType.JSON.ToString().ToLower()}");
            request.ContentLength = postDataBytes.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(postDataBytes, 0, postDataBytes.Length);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (response)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string responseText = reader.ReadToEnd();
                        RootObject responseObject = JsonConvert.DeserializeObject<RootObject>(responseText);
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            // validar cantidad de errores de estructura
                            if (responseObject.cantidad_errores > 0)
                            {
                                result.Success = false;
                                result.Object = responseObject;
                                foreach (var error in responseObject.errores)
                                {
                                    result.Message += error.descripcion + ", ";
                                }
                                return result;
                            }

                            result.Success = true;
                            result.Object = responseObject;
                            return result;
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = ($"Error: {response.StatusCode}, {responseObject.descripcion}");
                            return result;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ($"Error: {ex.Message} + {ex.StackTrace}");
                return result;
            }
        }

        /// <summary>
        /// Método para construir una URL y abrirla en el navegador
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="rnc"></param>
        /// <param name="encf"></param>
        /// <param name="codigoSeguridad"></param>
        public static void GetDocumentPdfInBrowser(string baseUrl, string rnc, string encf, string codigoSeguridad)
        {
            string formato = "pdf";
            string operacion = "ecf";

            string url = $"{baseUrl}?rnc={rnc}&encf={encf}&codigo_seguridad={codigoSeguridad}&formato={formato}&operacion={operacion}";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al abrir la URL: {ex.Message}");
            }
        }

        public static void GetDocumentPdfInBrowser(string url)
        {
            
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al abrir la URL: {ex.Message}");
            }
        }

    }
}
