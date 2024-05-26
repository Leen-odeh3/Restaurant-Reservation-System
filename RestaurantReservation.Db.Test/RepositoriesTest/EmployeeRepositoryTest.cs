using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Moq;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Enums;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Test.Helper;

namespace RestaurantReservation.Db.Test.RepositoriesTest;

public class EmployeeRepositoryTest
{
    private readonly IFixture _fixture;
    private readonly DbContextOptions<RestaurantReservationDbContext> _options;

    private readonly Mock<RestaurantReservationDbContext> _mockContext;

    public EmployeeRepositoryTest()
    {
        _fixture = new Fixture();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        _mockContext = _fixture.Freeze<Mock<RestaurantReservationDbContext>>();
        _options = new DbContextOptionsBuilder<RestaurantReservationDbContext>()
           .UseInMemoryDatabase(databaseName: "TestDatabase")
           .Options;
    }

    private async Task<EmployeeRepository> GetInitializedRepository()
    {
        var mockContext = _fixture.Freeze<Mock<RestaurantReservationDbContext>>();
        await TestDataSeeder.SeedEmployees(mockContext.Object);
        return new EmployeeRepository(mockContext.Object);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllEmployees_WhenDatabaseHasData()
    {
        var repository = await GetInitializedRepository();

        var employees = await repository.GetAllAsync();

        Assert.NotEmpty(employees);
        Assert.Equal(91, employees.Count);
    }

    [Fact]
    public async Task ListManagers_ReturnsListOfManagers_WhenDatabaseHasData()
    {
        var repository = await GetInitializedRepository();

        var managers = await repository.ListManagers();

        Assert.NotNull(managers);
        Assert.NotEmpty(managers);
        Assert.Equal(42, managers.Count);
        Assert.All(managers, m => Assert.Equal(EmployeePosition.Manager, m.Position));
    }
    [Fact]
    public async Task DeleteEmployee_ThrowsExceptionWhenEmployeeNotFound()
    {
        var repository = await GetInitializedRepository();
        var nonExistentEmployeeId = -1;

        var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            var nonExistentEmployee = await repository.GetByIdAsync(nonExistentEmployeeId);
            await repository.DeleteAsync(nonExistentEmployee);
        });

        Assert.Equal("entity", exception.ParamName);
    }


    [Fact]
    public async Task UpdateEmployee_ThrowsException_WhenEmployeeNotFound()
    {
        var repository = await GetInitializedRepository();

        await Assert.ThrowsAsync<Exception>(async () =>
        {
            var employeeToUpdate = await repository.GetByIdAsync(-1);

            if (employeeToUpdate is null)
            {
                throw new Exception("Employee to update not found");
            }
            employeeToUpdate.FirstName = "leen";
            employeeToUpdate.LastName = "odeh";
            await repository.UpdateAsync(employeeToUpdate);
        });
    }

    [Fact]
    public async Task AddEmployee_AddsNewEmployeeToDatabase()
    {
        var repository = await GetInitializedRepository();
        var newEmployee = _fixture.Build<Employee>()
            .Without(e => e.Id) 
            .Create();

        await repository.AddAsync(newEmployee);

        using (var context = new RestaurantReservationDbContext(_options))
        {
            var addedEmployee = await context.Employees.FindAsync(newEmployee.Id);
            Assert.NotNull(addedEmployee);
            Assert.Equal(newEmployee.FirstName, addedEmployee.FirstName);
            Assert.Equal(newEmployee.LastName, addedEmployee.LastName);
            Assert.Equal(newEmployee.Position, addedEmployee.Position);
        }
    }
}
