using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FELCR.Models
{
    public partial class SubsidiaryModel
    {
        public int Id { get; set; }

        public CompanyModel Company { get; set; }

        public string EstablishmentName { get; set; }

        public string EstablishmentCode { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string SubsidiaryFolder { get; set; }
    }
}
