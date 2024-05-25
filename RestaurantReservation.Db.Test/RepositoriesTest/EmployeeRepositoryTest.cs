using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Enums;
using RestaurantReservation.Db.Test.Helper;

namespace RestaurantReservation.Db.Test.RepositoriesTest;
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

    private async Task<EmployeeRepository> GetInitializedRepository(RestaurantReservationDbContext context)
    {
        await TestDataSeeder.SeedEmployees(context);
        return new EmployeeRepository(context);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllEmployees_WhenDatabaseHasData()
    {
        // Arrange
        using (var context = new RestaurantReservationDbContext(_options))
        using (var repository = await GetInitializedRepository(context))
        {
            // Act
            var employees = await repository.GetAllAsync();

            // Assert
            Assert.NotEmpty(employees);
            Assert.Equal(10, employees.Count);
        }
    }

    [Fact]
    public async Task ListManagers_ReturnsListOfManagers_WhenDatabaseHasData()
    {
        // Arrange
        using (var context = new RestaurantReservationDbContext(_options))
        using (var repository = await GetInitializedRepository(context))
        {
            // Act
            var managers = await repository.ListManagers();

            // Assert
            Assert.NotNull(managers);
            Assert.NotEmpty(managers);
            Assert.Equal(6, managers.Count);
            Assert.All(managers, m => Assert.Equal(EmployeePosition.Manager, m.Position));
        }
    }

    [Fact]
    public async Task DeleteEmployee_RemovesEmployeeFromDatabase()
    {
        // Arrange
        using (var context = new RestaurantReservationDbContext(_options))
        using (var repository = await GetInitializedRepository(context))
        {
            var employeeToDelete = await repository.GetByIdAsync(1);

            // Act
            await repository.DeleteAsync(employeeToDelete);

            // Assert
            var remainingEmployees = await repository.GetAllAsync();
            Assert.DoesNotContain(remainingEmployees, e => e.Id == 1);
        }
    }

    [Fact]
    public async Task UpdateEmployee_UpdatesEmployeeInDatabase()
    {
        // Arrange
        using (var context = new RestaurantReservationDbContext(_options))
        {
            var repository = new EmployeeRepository(context);
            await TestDataSeeder.SeedEmployees(context);

            var employeeToUpdate = await repository.GetByIdAsync(1);
            employeeToUpdate.FirstName = "leen";
            employeeToUpdate.LastName = "odeh";

            // Act
            await repository.UpdateAsync(employeeToUpdate);

            // Assert
            var updatedEmployee = await repository.GetByIdAsync(1);
            Assert.NotNull(updatedEmployee);
            Assert.Equal("leen", updatedEmployee.FirstName);
            Assert.Equal("odeh", updatedEmployee.LastName);
        }
    }

}
