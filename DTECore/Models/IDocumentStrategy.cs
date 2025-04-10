using System.Data;
using WIS_Security;

namespace DTECore
{
    public interface IDocumentStrategy
    {
        ResponseModel<ECF> MakeDocument(DataTable datos);       
    }
}
