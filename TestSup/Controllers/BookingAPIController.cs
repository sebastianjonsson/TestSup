using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestSup.Models;

namespace TestSup.Controllers
{
    public class BookingAPIController : ApiController
    {
        [HttpPost, ActionName("newBooking")]
        public void newBooking([FromBody] BookingViewModel model)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    db.Book.Add(new Bookings()
                    {
                        UserName = model.UserName,
                        //StartTime = model.StartTime,
                        //Endtime = model.Endtime,
                        BookingSys = db.Book.Single(x => x.Id == model.BookingSys)
                    });

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
}
