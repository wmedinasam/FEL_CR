using FELRD.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WIS_Security;

namespace FELRD.Models
{
    public partial class SettingModel
    {
        SettingService settingService = new SettingService();
        HandleCfg handleCfg = new HandleCfg();

        private string createEmailBody(string userName, string title, string message)
        {

            string body = string.Empty;
            try
            {

                using (StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + "/HtmlTemplate.html"))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{UserName}", userName);
                body = body.Replace("{Title}", title);
                body = body.Replace("{message}", message);

            }
            catch (Exception ex)
            {
                handleCfg.SaveLog("Debug", "Error al enviar correo: [Message] " + ex.Message + " [StackTrace] " + ex.StackTrace);
            }
            return body;
        }

        private void SendHtmlFormattedEmail(string subject, string body)
        {
            try
            {
                var response = GetSettings();
                using (MailMessage mailMessage = new MailMessage())
                {
                    var from = response.Object.Where(x => x.Key == "mail_from").FirstOrDefault().Value.DesencriptarDatos();
                    var to = response.Object.Where(x => x.Key == "mail_to").FirstOrDefault().Value.DesencriptarDatos().Split('|');
                    var password = response.Object.Where(x => x.Key == "mail_password").FirstOrDefault().Value.DesencriptarDatos();
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress(from);

                    if (to.Count() > 1)
                    {
                        mail.CC.Add(to[1]);
                    }
                    else
                    {
                        mail.To.Add(to[0]);
                    }

                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(from, password);
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }
            }
            catch (Exception ex)
            {
                handleCfg.SaveLog("Debug", "Error al enviar correo: [Message] " + ex.Message + " [StackTrace] " + ex.StackTrace);
            }

        }

        public bool isSuscriptionAboutToExpired(DateTime serverDate)
        {
            var dueDate = SuscriptionsService.GetDueDate();
            var result = dueDate - serverDate;
            var notificationDay = GetSettings().Object.Where(x => x.Key == "notification_days").FirstOrDefault().Value.DesencriptarDatos();
            return result.Days <= Convert.ToInt32(notificationDay);
        }

        public bool isNotificationSent(DateTime serverDate)
        {
            var last_notification_day = GetSettings().Object.Where(x => x.Key == "last_notification_day").FirstOrDefault().Value.DesencriptarDatos();
            var last_notification_dayDate = Convert.ToDateTime(last_notification_day);
            return serverDate.Date == last_notification_dayDate.Date;
        }

        public void SendEmail()
        {
            var response = GetSettings();
            var customer = response.Object.Where(x => x.Key == "mail_customer_name").FirstOrDefault().Value.DesencriptarDatos();
            var title = response.Object.Where(x => x.Key == "mail_title").FirstOrDefault().Value.DesencriptarDatos();
            var message = response.Object.Where(x => x.Key == "mail_message").FirstOrDefault().Value.DesencriptarDatos();
            var subject = response.Object.Where(x => x.Key == "mail_subject").FirstOrDefault().Value.DesencriptarDatos();
            string body = this.createEmailBody(customer, title, message);
            if (body != string.Empty)
            {
                this.SendHtmlFormattedEmail(subject, body);
            }
            else
            {
                handleCfg.SaveLog("Debug", "Error al enviar correo: [Message] No se cargo la plantilla de correo correctamente");
            }
        }

        public void ChangeNotificationSent(DateTime serverDate)
        {
            SettingModel model = new SettingModel();
            model.Value = serverDate.Date.ToString().EncriptarDatos();
            var response = model.ActionSetting("NotificationDay", model);
        }


        public ResponseModel<List<SettingModel>> GetSettings()
        {
            ResponseModel<List<SettingModel>> res = new ResponseModel<List<SettingModel>>();
            List<SettingModel> lst = new List<SettingModel>();
            bool success = true;
            string message = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt = settingService.GetSettings().Tables[0];
                lst = dt.AsEnumerable().Select(fila => new SettingModel
                {
                    Id = fila["id"].ToString(),
                    Key = fila["key"].ToString(),
                    Value = fila["value"].ToString(),
                    Description = fila["description"].ToString()
                }).ToList<SettingModel>();
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

        public ResponseModel<object> ActionSetting(string action, SettingModel model)
        {
            ResponseModel<object> res = new ResponseModel<object>();
            try
            {
                DataTable dt = new DataTable();
                dt = settingService.ActionSetting(
                                    action,
                                    model.Id,
                                    model.Key,
                                    model.Value,
                                    model.Description).Tables[0];

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
