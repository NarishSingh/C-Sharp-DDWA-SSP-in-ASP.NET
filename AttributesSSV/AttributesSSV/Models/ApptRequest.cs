using System;
using System.ComponentModel.DataAnnotations;
using AttributesSSV.Attributes;

namespace AttributesSSV.Models
{
    public class ApptRequest
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string ClientName { get; set; }
        
        [Required(ErrorMessage = "You must enter a dates")]
        [FutureDate(ErrorMessage = "Cannot book an appointment in the past")]
        [NoWeekend(ErrorMessage = "Must book on weekday (Mon - Fri)")]
        public DateTime Date { get; set; }
        
        [MustBeTrue(ErrorMessage = "You must accepts terms and conditions to book")]
        public bool TermsAccepted { get; set; }
    }
}