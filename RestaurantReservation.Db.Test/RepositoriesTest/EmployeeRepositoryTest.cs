using AutoFixture;
using FluentAssertions;
using Moq;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Abstracts;
using RestaurantReservation.Db.Enums;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Data;

namespace RestaurantReservation.Db.Test.RepositoriesTest;
public class EmployeeRepositoryTest
{
    private readonly Mock<RestaurantReservationDbContext> _mockDbContext;
    private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;
    private readonly Fixture _fixture;
    private readonly EmployeeRepository _employeeRepository;

    public EmployeeRepositoryTest()
    {
        _mockEmployeeRepository = new Mock<IEmployeeRepository>();
        _fixture = new Fixture();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _mockDbContext = new Mock<RestaurantReservationDbContext>();
    }

     [Fact]
    public async Task GetEmployees_ShouldReturnOkResult_WithListOfEmployees()
    {
        // Arrange
        var employees = _fixture.CreateMany<Employee>(10).ToList();
        _mockEmployeeRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);

        // Act
        var result = await _mockEmployeeRepository.Object.GetAllAsync();

        // Assert
        var okResult = result.Should().BeOfType<List<Employee>>().Subject;
        okResult.Should().BeEquivalentTo(employees);
    }

    [Fact]
    public async Task GetEmployeeById_ShouldReturnOkResult_WhenEmployeeFound()
    {
        // Arrange
        var employee = _fixture.Create<Employee>();
        _mockEmployeeRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(employee);

        // Act
        var result = await _mockEmployeeRepository.Object.GetByIdAsync(employee.Id);

        // Assert
        result.Should().BeOfType<Employee>();
        result.Should().BeEquivalentTo(employee);
    }

    [Fact]
    public async Task GetEmployeeById_ShouldReturnNull_WhenEmployeeNotFound()
    {
        // Arrange
        _mockEmployeeRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Employee)null);

        // Act
        var result = await _mockEmployeeRepository.Object.GetByIdAsync(1);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task CreateEmployee_ShouldAddEmployee()
    {
        // Arrange
        var employee = _fixture.Create<Employee>();
        _mockEmployeeRepository.Setup(repo => repo.AddAsync(employee)).Returns(Task.CompletedTask);

        // Act
        await _mockEmployeeRepository.Object.AddAsync(employee);

        // Assert
        _mockEmployeeRepository.Verify(repo => repo.AddAsync(employee), Times.Once);
    }

    [Fact]
    public async Task UpdateEmployee_ShouldModifyEmployee()
    {
        // Arrange
        var employee = _fixture.Create<Employee>();
        _mockEmployeeRepository.Setup(repo => repo.UpdateAsync(employee)).Returns(Task.CompletedTask);

        // Act
        await _mockEmployeeRepository.Object.UpdateAsync(employee);

        // Assert
        _mockEmployeeRepository.Verify(repo => repo.UpdateAsync(employee), Times.Once);
    }

    [Fact]
    public async Task DeleteEmployee_ShouldRemoveEmployee()
    {
        // Arrange
        var employee = _fixture.Create<Employee>();
        _mockEmployeeRepository.Setup(repo => repo.DeleteAsync(employee)).Returns(Task.CompletedTask);

        // Act
        await _mockEmployeeRepository.Object.DeleteAsync(employee);

        // Assert
        _mockEmployeeRepository.Verify(repo => repo.DeleteAsync(employee), Times.Once);
    }

    [Fact]
    public async Task ListManagers_ShouldReturnListOfManagers()
    {
        // Arrange
        var managers = _fixture.CreateMany<Employee>(10)
            .Select(e => { e.Position = EmployeePosition.Manager; return e; })
            .ToList();

        _mockEmployeeRepository.Setup(repo => repo.ListManagers()).ReturnsAsync(managers);

        // Act
        var result = await _mockEmployeeRepository.Object.ListManagers();

        // Assert
        result.Should().BeEquivalentTo(managers);
    }


}
