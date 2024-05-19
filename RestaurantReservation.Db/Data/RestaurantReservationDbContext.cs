using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Exceptions;
using RestaurantReservation.Db.Extensions;
using RestaurantReservation.Db.ViewModels;
using System.Linq;

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
            modelBuilder
           .HasDbFunction(typeof(RestaurantReservationDbContext)
               .GetMethod(nameof(CalculateRestaurantTotalRevenue), new[] { typeof(int) })!)
           .HasName("CalculateTotalRevenue");
        }

        public decimal CalculateRestaurantTotalRevenue(int restaurantId)
        {
            var restaurant = Restaurants
                .Include(r => r.Reservations)!
                .ThenInclude(r => r.Orders)!
                .ThenInclude(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .FirstOrDefault(r => r.RestaurantId == restaurantId);

            if (restaurant is null)
            {
                throw new NotFoundException<Restaurant>($"Restaurant with id {restaurantId} not found.");
            }

            var totalRevenue = restaurant.Reservations!
                .SelectMany(r => r.Orders!)
                .SelectMany(o => o.OrderItems)
                .Sum(m => m.MenuItem.Price * m.Quantity);

            return totalRevenue;
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
