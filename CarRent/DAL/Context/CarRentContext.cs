using CarRent.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace CarRent.DAL.Context
{
    public class CarRentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-JI387RJ\\SQLEXPRESS;initial catalog=RentCarDB;integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarReservation>().HasOne(x => x.TakeCarLocation)
                .WithMany(y => y.TakeCarLocations)
                .HasForeignKey(z => z.TakeCarId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<CarReservation>().HasOne(x => x.DropCarLocation)
                .WithMany(y => y.DropCarLocations)
                .HasForeignKey(z => z.DropCarId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Car> Cars{ get; set; }
        public DbSet<Location> Locations{ get; set; }
        public DbSet<Brand> Brands{ get; set; }
        public DbSet<CarReservation> CarReservations{ get; set; }

    }
}
