using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {

        protected override void Seed(DatabaseContext context)
        {

            IList<BookingSystem> bookingSys = new List<BookingSystem>();
            IList<Bookings> booking = new List<Bookings>();

            bookingSys.Add(new BookingSystem()
            {
                SystemName = "Cykelverkstad",
                SystemDescription ="Lagar cyklar",
                Email = "cykelverkstad@hej.se",
                PhoneNumber = 0701567598,
                Website = "cykelverkstad.se",
                Address = "cykelvägen 1",
                Latitude = "45",
                Longitude = "45",
                City = "Örebro",
                Category = "Verkstad",
            });
            bookingSys.Add(new BookingSystem()
            {
                SystemName = "Pelles frisör",
                SystemDescription = "Klipper alla möjliga hårlängder.",
                Email = "pellesfrissa@hej.se",
                PhoneNumber = 0701554765,
                Website = "pellesfrissa.se",
                Address = "frisörvägen 1",
                Latitude = "45",
                Longitude = "45",
                City = "Örebro",
                Category = "Frisör",
            });
            bookingSys.Add(new BookingSystem()
            {
                SystemName = "Hasses skrädderi",
                SystemDescription = "Tvättar och syr kläder.",
                Email = "hassesskradderi@hej.se",
                PhoneNumber = 0701328514,
                Website = "hassesskradderi.se",
                Address = "skräddarvägen 1",
                Latitude = "45",
                Longitude = "45",
                City = "Örebro",
                Category = "Skrädderi",
            });
            bookingSys.Add(new BookingSystem()
            {
                SystemName = "Kalles bilverkstad",
                SystemDescription = "Lagar bilar",
                Email = "kallesbilar@hej.se",
                PhoneNumber = 0701547218,
                Website = "kallesbilar.se",
                Address = "bilvägen 1",
                Latitude = "45",
                Longitude = "45",
                City = "Stockholm",
                Category = "Verkstad",
            });
            bookingSys.Add(new BookingSystem()
            {
                SystemName = "Snabbaste däckbytarna",
                SystemDescription = "Bildäckbyte",
                Email = "dackbyte@hej.se",
                PhoneNumber = 0701957863,
                Website = "dackbyte.se",
                Address = "däckvägen 1",
                Latitude = "45",
                Longitude = "45",
                City = "Stockholm",
                Category = "Verkstad",
            });
            bookingSys.Add(new BookingSystem()
            {
                SystemName = "Lisas frissa",
                SystemDescription = "Specialiserad på tjejklippning.",
                Email = "lisasdamfrissa@hej.se",
                PhoneNumber = 0701525254,
                Website = "lisasfrissa.se",
                Address = "frisörvägen 45",
                Latitude = "45",
                Longitude = "45",
                City = "Stockholm",
                Category = "Frisör",
            });
            bookingSys.Add(new BookingSystem()
            {
                SystemName = "Bengts allfix",
                SystemDescription = "Jag är en man som fixar allt mellan himmel och jord.",
                Email = "bengtsfix@hej.se",
                PhoneNumber = 0701989898,
                Website = "bengansfix.se",
                Address = "fixvägen 1",
                Latitude = "45",
                Longitude = "45",
                City = "Örebro",
                Category = "Verkstad",
            });
            bookingSys.Add(new BookingSystem()
            {
                SystemName = "Mias blomsterhörna",
                SystemDescription = "Blommor och bin.",
                Email = "miashörna@hej.se",
                PhoneNumber = 0701323232,
                Website = "miashorna.se",
                Address = "blomstervägen 1",
                Latitude = "45",
                Longitude = "45",
                City = "Västerås",
                Category = "Blomsterhandel",
            });
            bookingSys.Add(new BookingSystem()
            {
                SystemName = "Charlies växtnäring",
                SystemDescription = "Växter och blomjord",
                Email = "challesvaxt@hej.se",
                PhoneNumber = 0701717171,
                Website = "challesvaxt.se",
                Address = "växtvägen 1",
                Latitude = "45",
                Longitude = "45",
                City = "Västerås",
                Category = "Blomsterhandel",
            });
            bookingSys.Add(new BookingSystem()
            {
                SystemName = "Rosornas paradis",
                SystemDescription = "Rosor i överflöd.",
                Email = "rosor@hej.se",
                PhoneNumber = 0701464646,
                Website = "rosor.se",
                Address = "rosvägen 1",
                Latitude = "45",
                Longitude = "45",
                City = "Örebro",
                Category = "Blomsterhandel",
            });
            foreach (BookingSystem booksys in bookingSys)
                context.Bus.Add(booksys);
            base.Seed(context);
        }
    }
}
