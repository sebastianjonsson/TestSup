using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestSup.Repository;

namespace TestSup.Api
{
    public class ApiBookingController : ApiController
    {
        BookingRepository bookingRepository = new BookingRepository();
        // GET: api/ApiBooking
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ApiBooking/5
        [HttpGet]
        [Route("api/getBooking/{id}")]
        public async Task<IHttpActionResult> GetBookingAsync(int id)
        {
            var system = await bookingRepository.GetBooking(id);
            if (system == null)
            {
                return BadRequest();
            }
            return Ok(system);
        }

        // POST: api/ApiBooking
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ApiBooking/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiBooking/5
        public void Delete(int id)
        {
        }
    }
}
