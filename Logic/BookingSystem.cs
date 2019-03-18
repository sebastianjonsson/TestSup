﻿using System;
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
        [Display(Name = "Verksamhet")]
        public string SystemName { get; set; }
        [Display(Name = "Beskrivning")]
        public string SystemDescription { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Telefonnummer")]
        public int PhoneNumber { get; set; }
        [Display(Name = "Hemsida")]
        public string Website { get; set; }
        [Display(Name = "Adress")]
        public string Address { get; set; }
        public decimal LatitudeLongitude { get; set; }
        [Display(Name = "Stad")]
        public string City { get; set; }
        [Display(Name = "Kategori")]
        public string Category { get; set; }
        
        public virtual ICollection<Bookings> Books { get; set; }
    }
}
