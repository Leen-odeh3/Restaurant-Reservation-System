using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Abstracts;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories;
public class EmployeeRepository : Repository<Employee>, IEmployeeRepository, IDisposable


namespace RestaurantReservation.Db.Repositories

{
    private readonly RestaurantReservationDbContext _context;

    public EmployeeRepository(RestaurantReservationDbContext context) : base(context)
    {

        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
        public EmployeeRepository(RestaurantReservationDbContext context) : base(context)
        {
        }
        public async Task<List<Employee>> ListManagers()
        {
            return await _context.Employees
                .Where(e => e.Position == EmployeePosition.Manager)
                .ToListAsync();

        }


    public async Task<List<Employee>> ListManagers()
    {
        return await _context.Employees
            .Where(e => e.Position == EmployeePosition.Manager)
            .ToListAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
