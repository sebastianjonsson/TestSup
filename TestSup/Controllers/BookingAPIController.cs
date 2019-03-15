using Logic;
using System;
using System.Linq;
using TestSup.Models;
using System.Web.Http;

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
