using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FELRD.Models
{
    public partial class CompanyModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CertificadorModel Certificador { get; set; }

        public string Nit { get; set; }

        public string Address { get; set; }

        public string Municipality { get; set; }

        public string Province { get; set; }

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

        public string DTEFolder { get; set; }

        public string DBSAE { get; set; }

        public string SuffixTable { get; set; }
    }
}
