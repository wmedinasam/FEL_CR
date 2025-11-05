using Newtonsoft.Json;
using ServiceCore.Infile.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using WIS_Security;

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
            string urlToken = url + "republica_dominicana/auth/login";

            var request = (HttpWebRequest)WebRequest.CreateHttp(urlToken);

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
                            return ($"Error: {urlToken}, {response.StatusCode}, {responseObject.descripcion}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return ($"Error: {urlToken}, {ex.Message} + {ex.StackTrace}");
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
            var urlSign = url + "republica_dominicana/api/v1/emision/ecf";

            var request = (HttpWebRequest)WebRequest.CreateHttp(urlSign);
            ResponseModel<RootObject> result = new ResponseModel<RootObject>();
            result.Success = false;
            // Autorización Bearer
            request.Headers.Add("Authorization", "Bearer " + token);

            // Body del request
            byte[] postDataBytes = Encoding.UTF8.GetBytes(xmlContent);

            request.Method = Method.POST.ToString();
            request.ContentType = string.Format($"application/{Model.ContentType.XML.ToString().ToLower()}");
            request.ContentLength = postDataBytes.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(postDataBytes, 0, postDataBytes.Length);
            }

            try
            {
                HttpWebResponse response = null;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    if (ex.Response is HttpWebResponse errorResponse)
                    {
                        response = errorResponse;
                    }
                    else
                    {
                        throw; // Si no hay respuesta, relanza la excepción
                    }
                }

                using (response)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string responseText = reader.ReadToEnd();
                        RootObject responseObject = JsonConvert.DeserializeObject<RootObject>(responseText);

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
                Console.WriteLine($"Error al abrir la URL: {url}: {ex.Message}");
            }
        }

    }
}
