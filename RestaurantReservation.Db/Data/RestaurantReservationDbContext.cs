using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Db.Configuration;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Extensions;

namespace RestaurantReservation.Db.Data
{
    public class RestaurantReservationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .AddJsonFile("\\appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            new EmployeeConfiguration().Configure(modelBuilder.Entity<Employee>());
            new OrderConfiguration().Configure(modelBuilder.Entity<Order>());
            new OrderItemConfiguration().Configure(modelBuilder.Entity<OrderItem>());
            new TableConfiguration().Configure(modelBuilder.Entity<Table>());
            new ReservationConfiguration().Configure(modelBuilder.Entity<Reservation>());
            new RestaurantConfiguration().Configure(modelBuilder.Entity<Restaurant>());
            new MenuItemConfiguration().Configure(modelBuilder.Entity<MenuItem>());
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
    }
}
