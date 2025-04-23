using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FELRD.Models
{
    public partial class TransactionModel
    {
        public int Id { get; set; }
        public CompanyModel Company { get; set; }
        public SubsidiaryModel Subsidiary { get; set; }
        public string SAEDocumentId { get; set; }
        public string SAESerial { get; set; }
        public string SAENumber { get; set; }
        public string Status { get; set; }
        public string Result { get; set; }
        public DateTime SendDate { get; set; }
        public string DocumentType { get; set; }
        public string UUID { get; set; }
        public string AnnulmentUUID { get; set; }
        public string ControlNumber { get; set; }
        public string Sign { get; set; }
        public string ReceivedStamp { get; set; }
        public string url_pdf { get; set; }
    }
}
