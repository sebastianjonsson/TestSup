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
        }
        public DbSet<BookingSystem> DbBookingSystem { get; set; }
        public DbSet<Bookings> DbBookings { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Bookings>()
            .HasOptional<BookingSystem>(s => s.BookingSys)
            .WithMany()
            .WillCascadeOnDelete(true);
            
        }
    }
}
