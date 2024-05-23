using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Enums;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Test.RepositoriesTest
{
    public class EmployeeRepositoryTest
    {
        private readonly DbContextOptions<RestaurantReservationDbContext> _options;

        public EmployeeRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<RestaurantReservationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Collection("Database Collection")]
        public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
        {
        }

        [Fact]
        public async Task GetAll_ReturnAllEmployees()
        {
            // Arrange
            using (var context = new RestaurantReservationDbContext(_options))
            {
                var repository = new EmployeeRepository(context);
                await LoadEmployeeData(context);

                // Act
                var employees = await repository.GetAllAsync();

                // Assert
                Assert.NotEmpty(employees);
                Assert.Equal(5, employees.Count);
            }
        }

        [Fact]
        public async Task GetListManagers_FromEmployee_ReturnsListOfManagers()
        {
            // Arrange
            using (var context = new RestaurantReservationDbContext(_options))
            {
                var repository = new EmployeeRepository(context);
                await LoadEmployeeData(context); // Using the same data

                // Act
                var managers = await repository.ListManagers();

                // Assert
                Assert.NotNull(managers);
                Assert.NotEmpty(managers);
                Assert.Equal(4, managers.Count);
                Assert.All(managers, m => Assert.Equal(EmployeePosition.Manager, m.Position));
            }
        }

        private async Task LoadEmployeeData(RestaurantReservationDbContext context)
        {
            var employees = new[]
            {
                new Employee { FirstName = "Ella", LastName = "Fitzgerald", Position = EmployeePosition.Manager, RestaurantId = 1 },
                new Employee { FirstName = "Louis", LastName = "Armstrong", Position = EmployeePosition.Chef, RestaurantId = 1 },
                new Employee { FirstName = "Billie", LastName = "Holiday", Position = EmployeePosition.Waiter, RestaurantId = 1 },
                new Employee { FirstName = "Charlie", LastName = "Parker", Position = EmployeePosition.Manager, RestaurantId = 2 },
                new Employee { FirstName = "Dizzy", LastName = "Gillespie", Position = EmployeePosition.Cashier, RestaurantId = 2 }
            };

            await context.AddRangeAsync(employees);
            await context.SaveChangesAsync();
        }
    }

    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            Options = new DbContextOptionsBuilder<RestaurantReservationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new RestaurantReservationDbContext(Options))
            {
                context.Database.EnsureCreated();
            }
        }

        public DbContextOptions<RestaurantReservationDbContext> Options { get; }

        public void Dispose()
        {
            using (var context = new RestaurantReservationDbContext(Options))
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
