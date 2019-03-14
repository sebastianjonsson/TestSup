using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSup.Models
{
    public class BookingViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int UserMobile { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Endtime { get; set; }
        public int BookingSys { get; set; }
    }
}
