using System.Data;
using WIS_Security;

namespace DTECore
{
    public interface IDocumentStrategy
    {
        ResponseModel<ECF> MakeDocument(DataTable datos);
        string SerializeDocument(ECF documento);
    }
}
