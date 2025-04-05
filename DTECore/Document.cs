using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WIS_Security;

namespace DTECore
{
    public class Document
    {
        public ResponseModel<ECF> MakeDocument(DataTable datos)
        {

            ECF documento = new ECF();
            ResponseModel<ECF> response = new ResponseModel<ECF>();


            return response;
        }

        public string SerializeDocument(ECF documento)
        {
            //return JsonConvert.SerializeObject(documento);
            return "";
        }
    }
}
