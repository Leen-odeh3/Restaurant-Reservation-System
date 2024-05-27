using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;

namespace RestaurantReservation;
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
               .AddInfrastructureDependencies()
               .BuildServiceProvider();
        }
    }
