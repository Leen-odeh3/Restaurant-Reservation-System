using RestaurantReservation.Db.Abstracts;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(RestaurantReservationDbContext context) : base(context)
        {
        }
    }
}
