using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIS_Security
{
    public partial class ConfigurationModel
    {
        public string User { get; set; }

        public string Password { get; set; }
        public string MasterPassword { get; set; }

        public string BdSae { get; set; }

        public string FechaUltimaConsulta { get; set; }

        public string FechaProxConsulta { get; set; }

        public bool ConsultaExitosa { get; set; }

        public int SyncTime { get; set; }

        public KeyModel Key { get; set; }

        public string path { get; set; }
    }
}
