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
        //Hämtar ett bokningsystem.
        public BookingSystem GetBookingSystem(int id)
        {
            BookingSystem bookingSystem = db.DbBookingSystem.Find(id);
            return (bookingSystem);
        }

        //Hämtar alla bokningssystem.
        public List<BookingSystem> GetAllBookingSystem()
        {
            List<BookingSystem> bookingSystem = db.DbBookingSystem.ToList();
            return (bookingSystem);
        }

        //Lägger till ett bokningssystem.
        public void AddBookingSystem(BookingSystem bookingSystem)
        {
            db.DbBookingSystem.Add(bookingSystem);
            db.SaveChanges();
        }

        //Hämtar bokningssystem man söker efter.
        public IEnumerable<BookingSystem> SearchBookingSystem(string searchString)
        {
            IEnumerable<BookingSystem> bookingSystem = db.DbBookingSystem.Where(s => s.SystemName.Contains(searchString)).ToList();
            return (bookingSystem);
        }

        //Ändrar ett bokningsystem.
        public void EditBookingSystem(BookingSystem bookingSystem)
        {
            var bookingSystemToChange = db.DbBookingSystem.FirstOrDefault(u => u.Id == bookingSystem.Id);

            bookingSystemToChange.Address = bookingSystem.Address;
            bookingSystemToChange.CreateBookingSystemCategory = bookingSystem.CreateBookingSystemCategory;
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

        //Tar bort ett bokningssystem.
        public void DeleteBookingSystem(BookingSystem bookingSystemModel)
        {
            var bookingSystem = db.DbBookingSystem.Find(bookingSystemModel.Id);

            db.DbBookingSystem.Remove(bookingSystem);
            db.SaveChanges();
        }

        //Sorterar bokningsystemen i bokstavsordning utifrån systemnamnen.
        public IEnumerable<BookingSystem> SortBookingSystemByName()
        {
            var sort = db.DbBookingSystem.OrderBy(x => x.SystemName).ToList();
            return (sort);
        }

        //Sorterar bokningsystemen i bokstavsordning utifrån stad.
        public IEnumerable<BookingSystem> SortBookingSystemByCity()
        {
            var sort = db.DbBookingSystem.OrderBy(x => x.City).ToList();
            return (sort);
        }

        //Sorterar bokningsystemen i bokstavsordning utifrån kategori.
        public IEnumerable<BookingSystem> SortBookingSystemByCategory()
        {
            var sort = db.DbBookingSystem.OrderBy(x => x.CreateBookingSystemCategory).ToList();
            return (sort);
        }
    }
}