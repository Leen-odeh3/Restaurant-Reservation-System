using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Extensions;
using RestaurantReservation.Db.ViewModels;

namespace RestaurantReservation.Db.Data
{
    public class RestaurantReservationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .AddJsonFile("C:\\Users\\hp\\Desktop\\C#\\RestaurantReservation\\appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            modelBuilder.Entity<ReservationDetails>().HasNoKey().ToView("ReservationsDetailsView");
            modelBuilder.Entity<EmployeeDetails>().HasNoKey().ToView("EmployeeDetailsView");
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<ReservationDetails> ReservationsDetailsView { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetailsView { get; set; }

    }
}
