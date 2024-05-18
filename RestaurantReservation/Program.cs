using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;
using System;

namespace RestaurantReservation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var serviceProvider = new ServiceCollection()
               .AddInfrastructureDependencies()
               .BuildServiceProvider();
        }
    }
}
