using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace FormTest.Models
{
    public class ContactModel
    {
        [Required]
        [Display(Name = "Vorname:")]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Nachname:")]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Adresse:")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Nachricht:")]
        public string Message { get; set; }

    }
}