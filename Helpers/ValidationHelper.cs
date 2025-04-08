using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace FELRD.Helpers
{
    internal class ValidationHelper
    {
        public static bool HasValidationErrors(IEnumerable<Control> controls)
        {
            bool hasError = false;

            foreach (var control in controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        textBox.BorderBrush = Brushes.Red;
                        hasError = true;
                    }
                    else
                    {
                        textBox.BorderBrush = Brushes.Gray;
                    }
                }
                else if (control is PasswordBox passwordBox)
                {
                    if (string.IsNullOrWhiteSpace(passwordBox.Password))
                    {
                        passwordBox.BorderBrush = Brushes.Red;
                        hasError = true;
                    }
                    else
                    {
                        passwordBox.BorderBrush = Brushes.Gray;
                    }
                }
                else if (control is ComboBox comboBox)
                {
                    if (comboBox.SelectedItem == null)
                    {
                        comboBox.BorderBrush = Brushes.Red;
                        hasError = true;
                    }
                    else
                    {
                        comboBox.BorderBrush = Brushes.Gray;
                    }
                }
            }

            return hasError;
        }

        public static bool IsPasswordComplex(PasswordBox passwordBox)
        {
            string password = passwordBox.Password;

            bool isComplex = password.Length >= 6 &&
                             password.Any(char.IsUpper) &&
                             password.Any(char.IsDigit) &&
                             password.Any(ch => !char.IsLetterOrDigit(ch));

            passwordBox.BorderBrush = isComplex ? Brushes.Gray : Brushes.Red;
            return isComplex;
        }

        public static bool ArePasswordsMatching(PasswordBox passwordBox1, PasswordBox passwordBox2)
        {
            bool match = passwordBox1.Password == passwordBox2.Password;
            passwordBox1.BorderBrush = match ? Brushes.Gray : Brushes.Red;
            passwordBox2.BorderBrush = match ? Brushes.Gray : Brushes.Red;
            return match;
        }
    }
}
