using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TestSup.Repository
{
    public class BookingSystemRepository
    {
        protected DatabaseContext db = new DatabaseContext();

        public async Task<BookingSystem> GetBookingSystem(int id)
        {
            BookingSystem bookingSystem =  db.Bus.Find(id);
            return (bookingSystem);
        }


    }
}