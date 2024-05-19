using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Data;
using System;
using System.Linq;

namespace RestaurantReservation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var dbContext = new RestaurantReservationDbContext())
            {
                var reservationsFromView = dbContext.ReservationsDetailsView.ToList();

                foreach (var reservation in reservationsFromView)
                {
                    Console.WriteLine($"Reservation ID: {reservation.ReservationId}");
                    Console.WriteLine($"Reservation Date: {reservation.ReservationDate}");
                }
            }

            var serviceProvider = new ServiceCollection()
               .AddInfrastructureDependencies()
               .BuildServiceProvider();
        }
    }
}
