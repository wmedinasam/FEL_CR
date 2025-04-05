using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using WIS_Security;

namespace DTECore
{
    public class Document
    {
        private IDocumentStrategy _documentStrategy;

        public Document(IDocumentStrategy documentStrategy)
        {
            _documentStrategy = documentStrategy;
        }

        public ResponseModel<ECF> MakeDocument(DataTable datos)
        {
            return _documentStrategy.MakeDocument(datos);
        }

        public string SerializeDocument(ECF documento)
        {
            return _documentStrategy.SerializeDocument(documento);
        }
    }
}
