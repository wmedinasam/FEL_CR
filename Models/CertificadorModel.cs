using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FELRD.Models
{
    public partial class CertificadorModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EndPointToken { get; set; }

        public string EndPointRegDoc { get; set; }

        public string EndPointFirma { get; set; }

        public string EndPointVerDoc { get; set; }

        public string EndPointAnularDoc { get; set; }

        public string EndPointEnvioContingencia { get; set; }

        public string CommercialName { get; set; }

        public string Nit { get; set; }

        public string UsuarioWS { get; set; }

        public string PasswordWS { get; set; }
    }
}
