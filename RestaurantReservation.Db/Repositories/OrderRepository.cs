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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(RestaurantReservationDbContext context) : base(context)
        {
        }
        public async Task<List<Order>> ListOrdersAndMenuItems(int reservationId)
        {
            var reservation = await _context.Reservations
                .Include(r => r.Orders)
                    .ThenInclude(o => o.OrderItems)
                        .ThenInclude(oi => oi.MenuItem)
                .FirstOrDefaultAsync(r => r.ReservationId == reservationId);

            if (reservation is null)
            {
                throw new NotFoundException<Reservation>($"Reservation with id {reservationId} not found.");
            }

            var ordersWithMenuItems = reservation.Orders.ToList();

            return ordersWithMenuItems;
        }

        public async Task<List<MenuItem>> ListOrderedMenuItems(int reservationId)
        {
            var reservation = await _context.Reservations
                .Include(r => r.Orders)
                    .ThenInclude(o => o.OrderItems)
                        .ThenInclude(oi => oi.MenuItem)
                .FirstOrDefaultAsync(r => r.ReservationId == reservationId);

            if (reservation is null)
            {
                throw new NotFoundException<Reservation>($"Reservation with id {reservationId} not found.");
            }

            var orderedMenuItems = reservation.Orders
                .SelectMany(o => o.OrderItems)
                .Select(oi => oi.MenuItem)
                .Distinct()
                .ToList();

            return orderedMenuItems;
        }


        public async Task<decimal> CalculateAverageOrderAmount(int employeeId)
        {
            var orders = await _context.Orders
                .Where(o => o.EmployeeId == employeeId)
                .ToListAsync();

            decimal totalOrderAmount = orders.Sum(o => o.TotalAmount);

            decimal averageOrderAmount = orders.Count > 0 ? totalOrderAmount / orders.Count : 0;

            return averageOrderAmount;
        }

    }
}
