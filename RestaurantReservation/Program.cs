using Microsoft.EntityFrameworkCore;
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
            using (var dbContext = new RestaurantReservationDbContext())
            {
                var reservationsFromView = dbContext.ReservationsDetailsView.ToList();

                foreach (var reservation in reservationsFromView)
                {
                    Console.WriteLine($"Reservation ID: {reservation.ReservationId}");
                    Console.WriteLine($"Reservation Date: {reservation.ReservationDate}");
                }

                Console.WriteLine("\n**************************************\n");
                var employeesWithRestaurantDetails = dbContext.EmployeeDetailsView.ToList();

                foreach (var employee in employeesWithRestaurantDetails)
                {
                    Console.WriteLine($"Employee ID: {employee.EmployeeId}");
                    Console.WriteLine($"Employee Name: {employee.EmployeeFirstName} {employee.EmployeeLastName}");
                    Console.WriteLine($"Position: {employee.Position}");
                    Console.WriteLine($"Restaurant ID: {employee.RestaurantId}");
                    Console.WriteLine($"Restaurant Name: {employee.RestaurantName}");
                    Console.WriteLine($"Restaurant Address: {employee.RestaurantAddress}");
                    Console.WriteLine($"Restaurant Phone Number: {employee.RestaurantPhoneNumber}");
                    Console.WriteLine($"Restaurant Opening Hours: {employee.RestaurantOpeningHours}");
                    Console.WriteLine();
                }
            }

            /*   using (var dbContext = new RestaurantReservationDbContext())
               {
                   var restaurantId = 3; 
                   decimal totalRevenue = dbContext.CalculateRestaurantTotalRevenue(restaurantId);

                   Console.WriteLine($"Total revenue for restaurant with ID {restaurantId}: {totalRevenue:C}");
               }
            */

         /*   using (var dbContext = new RestaurantReservationDbContext())
            {
                int partySizeThreshold = 5; 
                var customers = dbContext.Customers.FromSqlRaw("EXECUTE FindCustomersWithPartySizeGreaterThan {0}", partySizeThreshold).ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}");
                }
            }
         */

            var serviceProvider = new ServiceCollection()
               .AddInfrastructureDependencies()
               .BuildServiceProvider();
        }
    }
}
