using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestSup.Controllers;
using Logic;
using System.Threading.Tasks;

namespace TestSup.Repository
{
    public class BookingRepository : BaseController
    {
        public async Task<Bookings> GetBooking(int id)
        {
            Bookings booking = db.DbBookings.Find(id);
            return (booking);
        }

        public async Task<IEnumerable<Bookings>> GetAllBookings()
        {
            IEnumerable<Bookings> bookings = db.DbBookings.ToList();
            return (bookings);
        }

        public async Task <IEnumerable<Bookings>> SortBookingsBySystemName()
        {
            var sort = db.DbBookings.OrderBy(x => x.BookingSystem.SystemName).ToList();
            return (sort);
        }

        public async Task<IEnumerable<Bookings>> SortBookingsByName()
        {
            var sort = db.DbBookings.OrderBy(x => x.UserName).ToList();
            return (sort);
        }
    }
}