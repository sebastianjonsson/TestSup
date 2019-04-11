using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestSup.Controllers;

namespace TestSup.Repository
{
    public class BookingSystemRepository : BaseController
    {
        public async Task<BookingSystem> GetBookingSystem(int id)
        {
            BookingSystem bookingSystem =  db.Bus.Find(id);
            return (bookingSystem);
        }
        //public async Task<BookingSystem> CreateBookingSystem(BookingSystem bookingSystem)
        //{
        //    db.Bus.Add(bookingSystem);
        //    db.SaveChanges();
        //    return (bookingSystem);
        //}

    }
}