using Xunit;
using RestaurantReservation.Db.Abstracts;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantReservation.Db.Enums;
using RestaurantReservation.Db.Data;

namespace RestaurantReservation.Db.Test.RepositoriesTest
{
    public class EmployeeRepositoryTest
    {
        private readonly DbContextOptions<RestaurantReservationDbContext> _options;

        public EmployeeRepositoryTest()
        {
            // Set up DbContextOptions for in-memory database
            _options = new DbContextOptionsBuilder<RestaurantReservationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task ListManagers_ReturnsListOfManagers()
        {
            // Arrange
            using (var context = new RestaurantReservationDbContext(_options))
            {
                // Add test data
                var employeeData = new List<Employee>
                {
                    new Employee { Id = 1, FirstName = "John", LastName = "Doe", Position = EmployeePosition.Manager },
                    new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", Position = EmployeePosition.Waiter },
                    new Employee { Id = 3, FirstName = "Mike", LastName = "Johnson", Position = EmployeePosition.Manager }
                };
                context.AddRange(employeeData);
                await context.SaveChangesAsync();
            }

            using (var context = new RestaurantReservationDbContext(_options))
            {
                // Act
                var repository = new EmployeeRepository(context);
                var managers = await repository.ListManagers();

                // Assert
                Assert.NotNull(managers);
                Assert.Equal(2, managers.Count); // We added 2 managers in the test data
            }
        }
    }
}
