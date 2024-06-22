using MimeKit.Cryptography;
using Org.BouncyCastle.Asn1.Mozilla;

namespace Application.Common.ReportModels
{
    public class ReportResult
    {
        public double Summa {  get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Message {  get; set; } = string.Empty;
    }
}
