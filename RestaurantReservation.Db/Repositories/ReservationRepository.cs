using RestaurantReservation.Db.Abstracts;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(RestaurantReservationDbContext context) : base(context)
        {
        }
    }
}
