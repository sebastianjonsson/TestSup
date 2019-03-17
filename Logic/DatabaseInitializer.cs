using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Logic
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var busi = new List<BookingSystem>()
            {
                new BookingSystem { SystemName = "Coop", SystemDescription = "Billigaste!!!"},
                new BookingSystem { SystemName = "Ica"},
                new BookingSystem { SystemName = "Willys"}
            };

            busi.ForEach(x => context.Bus.Add(x));
            context.SaveChanges();

        }
    }
}
