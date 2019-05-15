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
        [Display(Name = "Bokningssystem")]
        public string SystemName { get; set; }
        [Display(Name = "Beskrivning")]
        public string SystemDescription { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Hemsida")]
        public string Website { get; set; }
        [Display(Name = "Adress")]
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
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
    
