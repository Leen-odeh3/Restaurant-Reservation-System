using RestaurantReservation.Db.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Abstracts;
public interface IReservationRepository : IRepository<Reservation>
{
    Task<List<Reservation>> GetReservationsByCustomer(int customerId);
}
