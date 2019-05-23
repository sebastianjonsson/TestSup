using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Logic
{
    public class Bookings
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Namn")]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Telefonnummer")]
        public string UserMobile { get; set; }
        [Required]
        [Display(Name = "Detaljer")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Datum")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yy}")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Starttid")]
        public string StartTime { get; set; }
        [Required]
        [Display(Name = "Sluttid")]
        public string Endtime { get; set; }
        public virtual BookingSystem BookingSystem { get; set; }
    }
}
