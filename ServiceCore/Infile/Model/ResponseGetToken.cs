using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Infile.Model
{
    public partial class Root
    {
        public DateTime fecha { get; set; }
        public bool resultado { get; set; }
        public string descripcion { get; set; }
        public string ambiente { get; set; }
        public string token { get; set; }
    }
}
