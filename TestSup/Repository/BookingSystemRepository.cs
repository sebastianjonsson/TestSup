using Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestSup.Controllers;

namespace TestSup.Repository
{
    public class BookingSystemRepository : BaseController
    {
        public BookingSystem GetBookingSystem(int id)
        {
            BookingSystem bookingSystem = db.DbBookingSystem.Find(id);
            return (bookingSystem);
        }

        public List<BookingSystem> GetAllBookingSystem()
        {
            List<BookingSystem> bookingSystem = db.DbBookingSystem.ToList();
            return (bookingSystem);
        }
        public void AddBookingSystem(BookingSystem bookingSystem)
        {
            db.DbBookingSystem.Add(bookingSystem);
            db.SaveChanges();
        }

        public IEnumerable<BookingSystem> SearchBookingSystem(string searchString)
        {
            IEnumerable<BookingSystem> bookingSystem = db.DbBookingSystem.Where(s => s.SystemName.Contains(searchString)).ToList();
            return (bookingSystem);
        }

        public void EditBookingSystem(BookingSystem bookingSystem)
        {
            var bookingSystemToChange = db.DbBookingSystem.FirstOrDefault(u => u.Id == bookingSystem.Id);

            bookingSystemToChange.Address = bookingSystem.Address;
            bookingSystemToChange.Category = bookingSystem.Category;
            bookingSystemToChange.City = bookingSystem.City;
            bookingSystemToChange.Email = bookingSystem.Email;
            bookingSystemToChange.PhoneNumber = bookingSystem.PhoneNumber;
            bookingSystemToChange.Latitude = bookingSystem.Latitude;
            bookingSystemToChange.Longitude = bookingSystem.Longitude;
            bookingSystemToChange.SystemName = bookingSystem.SystemName;
            bookingSystemToChange.SystemDescription = bookingSystem.SystemDescription;
            bookingSystemToChange.Website = bookingSystem.Website;
            
            db.Entry(bookingSystemToChange).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteBookingSystem(BookingSystem bookingSystemModel)
        {
            var bookingSystem = db.DbBookingSystem.Find(bookingSystemModel.Id);

            db.DbBookingSystem.Remove(bookingSystem);
            db.SaveChanges();
        }
    }
}