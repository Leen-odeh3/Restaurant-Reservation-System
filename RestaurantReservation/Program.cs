using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;

namespace RestaurantReservation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
               .AddInfrastructureDependencies()
               .BuildServiceProvider();
        }
    }
}
