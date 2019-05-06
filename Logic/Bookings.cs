﻿using System;
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
        [Display(Name = "Namn")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Telefonnummer")]
        public string UserMobile { get; set; }
        [Display(Name = "Detaljer")]
        public string Subject { get; set; }
        [Display(Name = "Datum")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yy}")]
        public DateTime Date { get; set; }
        [Display(Name = "Starttid")]
        public string StartTime { get; set; }
        [Display(Name = "Sluttid")]
        public string Endtime { get; set; }

        //public int BookingSystemID { get; set; }
        public virtual BookingSystem BookingSystem { get; set; }
    }
}
