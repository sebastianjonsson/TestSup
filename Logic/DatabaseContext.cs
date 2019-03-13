using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Logic
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("BookingSystemDatabase")
        { }
        public static DatabaseContext Create()
        {
            return new DatabaseContext();
            //hey
            /// Hej Tiadfgsdfgsdfgm
        }
        public DbSet<BookingSystem> Bus { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
