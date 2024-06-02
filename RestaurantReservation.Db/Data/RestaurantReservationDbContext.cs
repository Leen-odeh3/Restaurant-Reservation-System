using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Db.Configuration;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Exceptions;
using RestaurantReservation.Db.Extensions;
using RestaurantReservation.Db.ViewModels;
using System.Linq;
using System.Reflection.Emit;

namespace RestaurantReservation.Db.Data;

public class RestaurantReservationDbContext : DbContext
{
    public RestaurantReservationDbContext(DbContextOptions options) : base(options)
    {
    }
    public RestaurantReservationDbContext()
    {
        
    }
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
    public DbSet<ReservationDetails> ReservationsDetailsView { get; set; }
    public DbSet<EmployeeDetails> EmployeeDetailsView { get; set; }

}
