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

        public string EndPoint { get; set; }
        
        public string PrintEndPoint { get; set; }

        public string CommercialName { get; set; }

        public string Nit { get; set; }

        public string UsuarioWS { get; set; }

        public string PasswordWS { get; set; }

        public string Key { get; set; }

        public string SecurityKey { get; set; }
    }
}
