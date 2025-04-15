using System;

namespace FELRD.Views.Pages

{
    class CompanyValidations : ObservableObject
    {
        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d{3}-\d{3}-\d{4}$"))
                {
                    _phone = value;
                }
                else
                {
                    throw new FormatException("El formato del teléfono debe ser ###-###-####");
                }
            }
        }
    }
}
