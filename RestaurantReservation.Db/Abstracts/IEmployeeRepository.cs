using RestaurantReservation.Db.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Abstracts
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<List<Employee>> ListManagers();

    }

}
