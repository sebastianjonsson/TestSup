using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Logic;

namespace Logic.Models
{
    public class BookingViewModel
    {
        [Required]
        [Display(Name = "Namn")]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Telefonnummer")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "telefonnumret måste vara i siffror.")]
        public string UserMobile { get; set; }
        [Required]
        [Display(Name = "Detaljer")]
        public string Subject { get; set; }
        [Display(Name = "Datum")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Starttid")]
        public string StartTime { get; set; }
        [Required]
        [Display(Name = "Sluttid")]
        public string Endtime { get; set; }
        public int BookingSystem { get; set; }
    }
}
