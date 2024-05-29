using RestaurantReservation.Db.Abstracts;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{ 
    public class TableRepository : Repository<Table>, ITableRepository
    {
        public TableRepository(RestaurantReservationDbContext context) : base(context)
        {
        }
    }
}
