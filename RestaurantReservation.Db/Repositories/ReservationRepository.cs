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
        private readonly ICustomerRepository _customerRepository;

        public ReservationRepository(RestaurantReservationDbContext context, ICustomerRepository customerRepository) : base(context)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Reservation>> GetReservationsByCustomer(int customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer is null)
            {
               throw new NotFoundException<Customer>($"Customer with id {customerId} not found.");
            }

            return await _context.Reservations
                .Where(r => r.CustomerId == customerId)
                .ToListAsync();
        }
    }
}
