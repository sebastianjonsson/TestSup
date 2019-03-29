using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Logic;

namespace TestSup.Models
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Namn")]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Telefonnummer")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "telefonnumret måste vara i siffror.")]
        public int UserMobile { get; set; }
        [Required]
        [Display(Name = "Detaljer")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Starttid")]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "Sluttid")]
        public DateTime Endtime { get; set; }
        public int BookingSys { get; set; }
    }
}
