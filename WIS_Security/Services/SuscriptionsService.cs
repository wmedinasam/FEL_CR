using Newtonsoft.Json;
using System;
using System.Globalization;

namespace WIS_Security
{
    public static class SuscriptionsService
    {
        /// <summary>
        /// Returns the server Date in Date Time format
        /// </summary>
        /// <returns></returns>
        /// 

        public static ResponseModel<DateTime> GetServerDate()
        {
            ResponseModel<DateTime> responseDate = new ResponseModel<DateTime>();
            try
            {
                var date = DateTime.UtcNow; // Use UTC to avoid regional settings
                var formattedDate = date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);

                responseDate.Success = true;
                responseDate.Object = DateTime.ParseExact(formattedDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                responseDate.Success = false;
                responseDate.Message = ex.Message;
            }
            return responseDate;
        }


        /// <summary>
        /// Get the due date of the Json key value
        /// </summary>
        /// <returns>Due Date inf Date Time format</returns>
        public static DateTime GetDueDate()
        {
            string[] formatos = { "dd/MM/yyyy", "dd-MM-yyyy" };
            ConfigurationModel _configurationModel = new ConfigurationModel();
            HandleCfg handleCfg = new HandleCfg();
            var json = handleCfg.ReadCfg(_configurationModel.path);
            _configurationModel = JsonConvert.DeserializeObject<ConfigurationModel>(json);
            var dateString = _configurationModel.Key.FechaVencimiento;
            DateTime date = DateTime.ParseExact(dateString, formatos, CultureInfo.InvariantCulture, DateTimeStyles.None);
            return date;
        }

        /// <summary>
        /// Returns true if the licence expired
        /// </summary>
        /// <param name="serverDate"></param>
        /// <returns>true if the licence expired</returns>
        public static bool isSuscriptionExpired(DateTime serverDate)
        {
            var dueDate = GetDueDate();
            return serverDate >= dueDate;
        }

        /// <summary>
        /// Return the remaining days of the licence.
        /// </summary>
        /// <param name="serverDate"></param>
        /// <returns></returns>
        public static int remainingDays(DateTime serverDate)
        {
            var dueDate = GetDueDate();
            var result = dueDate - serverDate;
            return result.Days;
        }

        /// <summary>
        /// returns true if the licence type is Lifetime.
        /// </summary>
        /// <returns>returns true if the licence type is Lifetime.</returns>
        public static bool isLifetimeLicence()
        {
            ConfigurationModel _configurationModel = new ConfigurationModel();
            HandleCfg handleCfg = new HandleCfg();
            var json = handleCfg.ReadCfg(_configurationModel.path);
            _configurationModel = JsonConvert.DeserializeObject<ConfigurationModel>(json);
            return _configurationModel.Key.FechaVencimiento.ToLower() == "undefined";
        }
    }
}
