using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FELCR
{
    class RegistrationVM : ObservableObject
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El Usuario no puede estar vacío!");
                }
                OnPropertyChanged(ref _username, value);

            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {

                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Password no puede estar vacía.");
                }
                OnPropertyChanged(ref _password, value);

            }
        }


        public class NoEmptyValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                return string.IsNullOrWhiteSpace((value ?? "").ToString())
                    ? new ValidationResult(false, "Field is required.")
                    : ValidationResult.ValidResult;
            }
        }

    }
}
