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
        public string UserName { get; set; }
        public string Email { get; set; }
        public int UserMobile { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Endtime { get; set; }
        public Bookings BookingSys { get; set; }
    }
}
