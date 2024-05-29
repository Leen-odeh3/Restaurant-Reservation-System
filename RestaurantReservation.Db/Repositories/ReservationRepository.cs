using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Abstracts;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(RestaurantReservationDbContext context) : base(context)
        {
        }

        public async Task<List<Reservation>> GetReservationsByCustomer(int customerId)
        {

            return await _context.Reservations
                .Where(r => r.CustomerId == customerId)
                .ToListAsync();
        }
    }
}
