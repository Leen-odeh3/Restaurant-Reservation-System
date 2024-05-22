using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Abstracts;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RestaurantReservation.Db.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RestaurantReservationDbContext context) : base(context)
        {
        }
        public async Task<List<Employee>> ListManagers()
        {
            return await _context.Employees
                .Where(e => e.Position == "Manager")
                .ToListAsync();

        }

    }
}
