using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db.Abstracts;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IMenuItemRepository, MenuItemRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddTransient<ITableRepository, TableRepository>();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            return services;

        }
    }
}
