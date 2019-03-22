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

            bookingSys.Add(new BookingSystem()
            {
                SystemName = "Cykelverkstad",
                SystemDescription ="Lagar cyklar",
                Email = "cykelverkstad@hej.se",
                PhoneNumber = 0701567598,
                Website = "cykelverkstad.se",
                Address = "cykelvägen 1",
                LatitudeLongitude = 45,
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
                LatitudeLongitude = 87,
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
                LatitudeLongitude = 96,
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
                LatitudeLongitude = 12,
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
                LatitudeLongitude = 26,
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
                LatitudeLongitude = 97,
                City = "Stockholm",
                Category = "Frisör",
            });
            foreach (BookingSystem booksys in bookingSys)
                context.Bus.Add(booksys);
            base.Seed(context);
        }
    }
}
