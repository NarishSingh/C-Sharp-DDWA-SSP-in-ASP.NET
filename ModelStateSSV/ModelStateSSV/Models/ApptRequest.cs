using System;

namespace ModelStateSSV.Models
{
    public class ApptRequest
    {
        public string ClientName { get; set; }
        public DateTime Date { get; set; }
        public bool TermsAccepted { get; set; }
    }
}