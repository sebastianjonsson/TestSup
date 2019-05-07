using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestSup.Controllers;
using Logic;
using System.Threading.Tasks;
using System.Data.Entity;
using TestSup.Models;

namespace TestSup.Repository
{
    public class BookingRepository : BaseController
    {
        public Bookings GetBooking(int id)
        {
            Bookings booking = db.DbBookings.Find(id);
            return (booking);
        }

        public List<Bookings> GetAllBookings()
        {
            List<Bookings> bookings = db.DbBookings.ToList();
            return (bookings);
        }

        public List<Bookings> GetAllCreateBookings(string startTime, int id, DateTime date)
        {
            List<Bookings> bookings = db.DbBookings.Where(x => x.StartTime == startTime && x.BookingSystem.Id == id && x.Date == date).ToList();
            return (bookings);
        }

        public IEnumerable<Bookings> SortBookingsBySystemName()
        {
            var sort = db.DbBookings.OrderBy(x => x.BookingSystem.SystemName).ToList();
            return (sort);
        }

        public IEnumerable<Bookings> SortBookingsByName()
        {
            var sort = db.DbBookings.OrderBy(x => x.UserName).ToList();
            return (sort);
        }

        public IEnumerable<Bookings> SearchBooking(string searchString)
        {
            IEnumerable<Bookings> bookings = db.DbBookings.Where(s => s.BookingSystem.SystemName.Contains(searchString) || s.UserName.Contains(searchString)).ToList();
            return (bookings);
        }

        public void AddBooking(BookingViewModel booking)
        {
            using (var db = new DatabaseContext())
            {
                var system = db.DbBookingSystem.Single(x => x.Id == booking.BookingSystem);

                db.DbBookings.Add(new Bookings()
                {
                    UserName = booking.UserName,
                    Email = booking.Email,
                    UserMobile = booking.UserMobile.ToString(),
                    Subject = booking.Subject,
                    StartTime = booking.StartTime,
                    Endtime = booking.Endtime,
                    BookingSystem = system,
                    Date = booking.Date
                });
                db.SaveChanges();
            }
         }

        public void EditBooking(Bookings booking)
        {
            db.Entry(booking).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteBooking(Bookings bookingModel)
        {
            var booking = db.DbBookings.Find(bookingModel.Id);

            db.DbBookings.Remove(booking);
            db.SaveChanges();
        }
    }
}