using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Infile.Model
{
    /// <summary>
    /// Enumerador para prevenir dejar escrito el método del request
    /// </summary>
    public enum Method
    {
        POST,
        GET,
        PUT,
        DELETE
    }

    /// <summary>
    /// Enumerador para prevenir dejar escrito el tipo de contenido del request
    /// </summary>
    public enum ContentType
    {
        XML,
        JSON
    }

    public partial class Root
    {
        public DateTime fecha { get; set; }
        public bool resultado { get; set; }
        public string descripcion { get; set; }
        public string ambiente { get; set; }
        public string token { get; set; }
    }

    public class RequestToken
    {
        public string rnc { get; set; }
        public string llave { get; set; }
    }
}
