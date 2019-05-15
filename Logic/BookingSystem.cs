using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Logic
{
    public class BookingSystem
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Bokningssystem")]
        public string SystemName { get; set; }
        [Required]
        [Display(Name = "Beskrivning")]
        public string SystemDescription { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Hemsida")]
        public string Website { get; set; }
        [Required]
        [Display(Name = "Adress")]
        public string Address { get; set; }
        [Required]
        public string Latitude { get; set; }
        [Required]
        public string Longitude { get; set; }
        [Required]
        [Display(Name = "Stad")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Kategori")]
        public string CreateBookingSystemCategory { get; set; }
        [Display(Name = "Logga")]
        public byte[] Picture { get; set; }
        public string File { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
    
