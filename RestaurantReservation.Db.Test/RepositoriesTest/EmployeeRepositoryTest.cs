using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Enums;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Test.RepositoriesTest;

public class EmployeeRepositoryTest
{
    private readonly DbContextOptions<RestaurantReservationDbContext> _options;
    private readonly RestaurantReservationDbContext _context;
    private readonly EmployeeRepository _repository;
    private readonly IFixture _fixture;

    public EmployeeRepositoryTest()
    {
        _fixture = new Fixture();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        _options = new DbContextOptionsBuilder<RestaurantReservationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase_EmployeeRepository")
            .Options;

        var mockDbSet = new Mock<DbSet<Customer>>();

        _context = new RestaurantReservationDbContext(_options);
        _context.Customers = mockDbSet.Object;

        _repository = new EmployeeRepository(_context);
    }

    [Fact]
    public async Task GetEmployees_ShouldReturnOkResult_WithListOfEmployees()
    {
        var employees = _fixture.CreateMany<Employee>(10).ToList();
        await _context.Employees.AddRangeAsync(employees);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAllAsync();

        result.Should().BeEquivalentTo(employees);
    }

    [Fact]
    public async Task GetEmployeeById_ShouldReturnOkResult_WhenEmployeeFound()
    {
        var employee = _fixture.Create<Employee>();
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();

        var result = await _repository.GetByIdAsync(employee.Id);

        result.Should().BeEquivalentTo(employee);
    }

    [Fact]
    public async Task GetEmployeeById_ShouldReturnNull_WhenEmployeeNotFound()
    {
        var employeeId = 80;
        var result = await _repository.GetByIdAsync(employeeId);

        result.Should().BeNull();
    }

    [Fact]
    public async Task CreateEmployee_ShouldAddEmployee()
    {
        var employee = _fixture.Create<Employee>();

        await _repository.AddAsync(employee);

        _context.Employees.Should().Contain(employee);
    }

    [Fact]
    public async Task UpdateEmployee_ShouldModifyEmployee()
    {
        var name = "leen";
        var employee = _fixture.Create<Employee>();
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();

        employee.FirstName = name;

        await _repository.UpdateAsync(employee);

        var updatedEmployee = await _context.Employees.FindAsync(employee.Id);
        updatedEmployee.Should().NotBeNull();
        updatedEmployee.FirstName.Should().Be(name);
    }

    [Fact]
    public async Task ListManagers_ShouldReturnListOfManagers()
    {
        var managers = _fixture.Build<Employee>()
            .With(e => e.Position, EmployeePosition.Manager)
            .CreateMany(10);

        await _context.Employees.AddRangeAsync(managers);
        await _context.SaveChangesAsync();

        var result = await _repository.ListManagers();

        result.Should().BeEquivalentTo(managers);
    }

}

