using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FELRD.Models
{
    public partial class RoleModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool State { get; set; }

        public bool CanAccessMonitor { get; set; }
        public bool CanCancel { get; set; }
        public bool CanAccessDocuments { get; set; }
        public bool CanAccessCompanies { get; set; }
        public bool CanAccessUsers { get; set; }
        public bool CanAccessLogs { get; set; }
        public bool CanAccessConfigurations { get; set; }
        public bool CanSign { get; set; }
        public bool CanAccessRoles { get; set; }
        public bool CanAccessCertifiers { get; set; }
    }
}
