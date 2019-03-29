using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestSup.Models
{
    public class BookingSystemsViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Verksamhet")]
        public string SystemName { get; set; }
        [Required]
        [Display(Name = "Beskrivning")]
        public string SystemDescription { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "telefonnumret måste vara i siffror.")]
        [Display(Name = "Telefonnummer")]
        public int PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Hemsida")]
        public string Website { get; set; }
        [Required]
        [Display(Name = "Adress")]
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        [Required]
        [Display(Name = "Stad")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Kategori")]
        public Category Category { get; set; }
        [Display(Name = "Verksamhetslogga")]
        public byte[] Picture { get; set; }
        public string File { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Bookings> Books { get; set; }
    }

}
public enum Category
{
    Verkstad,
    Skönhet,
    Restaurang,
    Idrott
}

