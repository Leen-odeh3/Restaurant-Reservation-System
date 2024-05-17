using RestaurantReservation.Db.Abstracts;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(RestaurantReservationDbContext context) : base(context)
        {
        }
    }
}
