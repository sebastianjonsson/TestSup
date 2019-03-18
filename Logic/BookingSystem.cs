using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Logic
{
    public class BookingSystem
    {
        public int Id { get; set; }
        public string SystemName { get; set; }
        public string SystemDescription { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public decimal LatitudeLongitude { get; set; }
        public string City { get; set; }
        public string Category { get; set; }
        
        public virtual ICollection<Bookings> Books { get; set; }
    }
}
