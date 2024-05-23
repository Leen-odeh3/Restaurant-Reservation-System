using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Enums;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Test.Helper;
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
            // Act
            var employees = await _repo.GetAllAsync();

            // Assert
            Assert.NotNull(employees);
            Assert.Equal(5, employees.Count);
        }

       
    }
}
