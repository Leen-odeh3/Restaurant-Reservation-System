using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Test.Helper;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Enums;
using Xunit;

namespace RestaurantReservation.Db.Test.RepositoriesTest
{
    public class EmployeeRepositoryTest
    {
        private readonly RestaurantReservationDbContext _options;
        private EmployeeRepository _repo;

        public EmployeeRepositoryTest()
        {
            _options = new RestaurantReservationDbContext(DatabaseConnectionTest.GetConnection());
            _repo = new EmployeeRepository(_options);
        }

        [Fact]
        public async Task GetAll_ReturnAllEmployee()
        {
            LoadEmployeeData(_options); 

            var res = await _repo.GetAllAsync(); 

            Assert.NotEmpty(res);
            Assert.Equal(5, res.Count());
        }

        private void LoadEmployeeData(RestaurantReservationDbContext option)
        {
            option.Employees.AddRange(
                 new Employee { Id = 1, FirstName = "Ella", LastName = "Fitzgerald", Position = EmployeePosition.Manager, RestaurantId = 1 },
                 new Employee { Id = 2, FirstName = "Louis", LastName = "Armstrong", Position = EmployeePosition.Chef, RestaurantId = 1 },
                 new Employee { Id = 3, FirstName = "Billie", LastName = "Holiday", Position = EmployeePosition.Waiter, RestaurantId = 1 },
                 new Employee { Id = 4, FirstName = "Charlie", LastName = "Parker", Position = EmployeePosition.Waiter, RestaurantId = 2 },
                 new Employee { Id = 5, FirstName = "Dizzy", LastName = "Gillespie", Position = EmployeePosition.Cashier, RestaurantId = 2 }
            );

            _options.SaveChanges(); 
        }
    }
}
