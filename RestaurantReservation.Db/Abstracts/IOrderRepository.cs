using RestaurantReservation.Db.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Abstracts;
public interface IOrderRepository : IRepository<Order>
{

    Task<List<Order>> ListOrdersAndMenuItems(int reservationId);
    Task<List<MenuItem>> ListOrderedMenuItems(int reservationId);
    Task<decimal> CalculateAverageOrderAmount(int employeeId);
    public interface IOrderRepository : IRepository<Order>
    {

        Task<List<Order>> ListOrdersAndMenuItems(int reservationId);
        Task<List<MenuItem>> ListOrderedMenuItems(int reservationId);
        Task<decimal> CalculateAverageOrderAmount(int employeeId);
    }

}
