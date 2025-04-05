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

        public string Prefix { get; set; }

        public string DTEFolder { get; set; }

        public string DBSAE { get; set; }

        public string SuffixTable { get; set; }
    }
}
