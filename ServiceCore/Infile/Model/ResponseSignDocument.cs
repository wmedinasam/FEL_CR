using Newtonsoft.Json;
using System;

namespace ServiceCore.Infile.Model
{

    public class RootObject
    {
        public DateTime fecha { get; set; }
        public bool resultado { get; set; }
        public string descripcion { get; set; }
        public string ambiente { get; set; }
        public string solicitud_id { get; set; }
        public string rnc_emisor { get; set; }
        public string rnc_comprador { get; set; }
        public string encf { get; set; }
        public string trackid { get; set; }
        public string codigo_seguridad { get; set; }
        public string secuencia_utilizada { get; set; }
        public int cantidad_errores { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Errores[] errores { get; set; }

        public object url_pdf { get; set; }
    }

    public class Errores
    {
        public string descripcion { get; set; }
    }
}

