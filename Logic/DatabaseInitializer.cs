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

            IList<BookingSystem> bookingSystem = new List<BookingSystem>();
            IList<Bookings> booking = new List<Bookings>();

            //Örebro
            bookingSystem.Add(new BookingSystem()
            {
                SystemName = "Nasses Cykelverkstad",
                SystemDescription ="Lagar cyklar",
                Email = "cykelverkstad@hej.se",
                PhoneNumber = "0701567598",
                Website = "cykelverkstad.se",
                Address = "Isgatan 5",
                Latitude = "59.266121",
                Longitude = "15.229120",
                City = "Örebro",
                Category = "Verkstad",
            });
            bookingSystem.Add(new BookingSystem()
            {
                SystemName = "Tottas Fritid AB",
                SystemDescription = "Lagar allt som går att laga",
                Email = "totta@hej.se",
                PhoneNumber = "0701554765",
                Website = "totta.se",
                Address = "Hjälmarvägen 26",
                Latitude = "59.261640",
                Longitude = "15.248280",
                City = "Örebro",
                Category = "Verkstad",
            });
            bookingSystem.Add(new BookingSystem()
            {
                SystemName = "Restaurang Monza",
                SystemDescription = "Pizza, kebab, sallad.",
                Email = "monza@hej.se",
                PhoneNumber = "0701328514",
                Website = "monza.se",
                Address = "Universitetsallén 24",
                Latitude = "59.264150",
                Longitude = "15.240100",
                City = "Örebro",
                Category = "Restaurang",
            });
            bookingSystem.Add(new BookingSystem()
            {
                SystemName = "Sörby Grill & Pizzeria",
                SystemDescription = "Grillad pizza mmm gott",
                Email = "sorbygrill@hej.se",
                PhoneNumber = "0701547218",
                Website = "sorby.se",
                Address = "Mejramvägen 113",
                Latitude = "59.255200",
                Longitude = "15.223530",
                City = "Örebro",
                Category = "Restaurang",
            });
            bookingSystem.Add(new BookingSystem()
            {
                SystemName = "Tybblelundshallen",
                SystemDescription = "Hyr din hall för aktiviteter här!",
                Email = "tybble@hej.se",
                PhoneNumber = "0701957863",
                Website = "gympa.se",
                Address = "Tybblelundsvägen 3",
                Latitude = "59.256481",
                Longitude = "15.260481",
                City = "Örebro",
                Category = "Idrott",
            });
            bookingSystem.Add(new BookingSystem()
            {
                SystemName = "Behrn Arena",
                SystemDescription = "Fotboll och amerikansk fotboll.",
                Email = "behrn@hej.se",
                PhoneNumber = "0701525254",
                Website = "behrn.se",
                Address = "Restalundsvägen 4-6",
                Latitude = "59.265530",
                Longitude = "15.225060",
                City = "Örebro",
                Category = "Idrott",
            });
            bookingSystem.Add(new BookingSystem()
            {
                SystemName = "Chia's Barbershop",
                SystemDescription = "Klippning halva pris jalla",
                Email = "chia@hej.se",
                PhoneNumber = "0701989898",
                Website = "chia.se",
                Address = "Storgatan 11",
                Latitude = "59.275790",
                Longitude = "15.215140",
                City = "Örebro",
                Category = "Behandling",
            });
            bookingSystem.Add(new BookingSystem()
            {
                SystemName = "SolTinis Fotvård",
                SystemDescription = "Jag älskar fötter",
                Email = "fotfot@hej.se",
                PhoneNumber = "0701323232",
                Website = "miasfotter.se",
                Address = "Köpmangatan 15B",
                Latitude = "59.270230",
                Longitude = "15.212027",
                City = "Örebro",
                Category = "Behandling",
            });
            //Stockholm
            bookingSystem.Add(new BookingSystem()
            {
                SystemName = "Bra Verkstad Stockholm AB",
                SystemDescription = "En bra verkstad bara",
                Email = "verkstad@hej.se",
                PhoneNumber = "0701567598",
                Website = "verkstad.se",
                Address = "Artillerigatan 33",
                Latitude = "59.336230",
                Longitude = "18.082920",
                City = "Stockholm",
                Category = "Verkstad",
            });
            bookingSystem.Add(new BookingSystem()
            {
                SystemName = "Stockholms Blåsinstrumentverkstad",
                SystemDescription = "Lagar dina trumpeter på nolltid!",
                Email = "blas@hej.se",
                PhoneNumber = "0701554765",
                Website = "blas.se",
                Address = "Bergsgatan 1",
                Latitude = "59.329670",
                Longitude = "18.045280",
                City = "Stockholm",
                Category = "Verkstad",
            });
            bookingSystem.Add(new BookingSystem()
            {
                SystemName = "Supper Stockholm",
                SystemDescription = "Supermat på supper",
                Email = "super@hej.se",
                PhoneNumber = "0701328514",
                Website = "super.se",
                Address = "Tegnérgatan 37",
                Latitude = "59.339000", 
                Longitude = "18.056780",
                City = "Stockholm",
                Category = "Restaurang",
            });
            bookingSystem.Add(new BookingSystem()
            {
                SystemName = "Nostrano",
                SystemDescription = "Italian food",
                Email = "food@hej.se",
                PhoneNumber = "0701547218",
                Website = "food.se",
                Address = "Timmermansgatan 13",
                Latitude = "59.318940",
                Longitude = "18.059680",
                City = "Stockholm",
                Category = "Restaurang",
            });
            bookingSystem.Add(new BookingSystem()
            {
                SystemName = "Konradsbergshallen",
                SystemDescription = "Innebandy?",
                Email = "konrdad@hej.se",
                PhoneNumber = "0701957863",
                Website = "konrad.se",
                Address = "Konradsbergsgatan 2B",
                Latitude = "59.328788",
                Longitude = "18.015113",
                City = "Stockholm",
                Category = "Idrott",
            });
            bookingSystem.Add(new BookingSystem()
            {
                SystemName = "Gärdeshallen",
                SystemDescription = "Badminton tennis och kul.",
                Email = "tennis@hej.se",
                PhoneNumber = "0701525254",
                Website = "tennis.se",
                Address = "Banérgatan 56",
                Latitude = "59.340520",
                Longitude = "18.097020",
                City = "Stockholm",
                Category = "Idrott",
            });
            bookingSystem.Add(new BookingSystem()
            {
                SystemName = "Björn Axén Norrlandsgatan 7",
                SystemDescription = "Klippning för eliten på Östermalm",
                Email = "klipp@hej.se",
                PhoneNumber = "0701989898",
                Website = "klipp.se",
                Address = "Norrlandsgatan 7",
                Latitude = "59.333890",
                Longitude = "18.071400",
                City = "Stockholm",
                Category = "Behandling",
            });
            bookingSystem.Add(new BookingSystem()
            {
                SystemName = "Hårgänget",
                SystemDescription = "Vi älskar hår",
                Email = "hair@hej.se",
                PhoneNumber = "0701323232",
                Website = "hair.se",
                Address = "Götgatan 31",
                Latitude = "59.316560",
                Longitude = "18.072180",
                City = "Stockholm",
                Category = "Behandling",
            });
            foreach (BookingSystem system in bookingSystem)
                context.DbBookingSystem.Add(system);
            base.Seed(context);
        }
    }
}
