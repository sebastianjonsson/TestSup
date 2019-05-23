using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Logic.Models
{
    public class BookingSystemsViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Namnet måste vara minst 1 och max 50 tecken.", MinimumLength = 1)]
        [Display(Name = "Bokningssystem")]
        public string SystemName { get; set; }
        [Required]
        [Display(Name = "Beskrivning")]
        public string SystemDescription { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10}$", ErrorMessage = "Telefonnumret måste vara 10 siffror.")]
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(/\S*)?$", ErrorMessage = "Felaktig hemsida. Formatera: www.exempel.se, exempel.se")]
        [Display(Name = "Hemsida")]
        public string Website { get; set; }
        [Required(ErrorMessage = "Välj en giltig plats.")]
        [Display(Name = "Adress")]
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        [Required]
        [Display(Name = "Stad")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Kategori")]
        public CreateBookingSystemCategory CreateBookingSystemCategory { get; set; }

        public HomeCategory HomeCategory { get; set; }
        [Display(Name = "Logga")]
        public byte[] Picture { get; set; }
    }

}
public enum CreateBookingSystemCategory
{
    Verkstad,
    Behandling,
    Restaurang,
    Idrott
}

public enum HomeCategory
{
    Alla,
    Verkstad,
    Behandling,
    Restaurang,
    Idrott
}

