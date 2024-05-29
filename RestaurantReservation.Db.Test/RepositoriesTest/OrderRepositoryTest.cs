using AutoFixture;
using FluentAssertions;
using Moq;
using RestaurantReservation.Db.Abstracts;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Exceptions;

namespace RestaurantReservation.Db.Test.RepositoriesTest;

public class OrderRepositoryTest
{
    private readonly Mock<RestaurantReservationDbContext> _mockDbContext;
    private readonly Mock<IOrderRepository> _mockOrderRepository;
    private readonly IFixture _fixture;

    public OrderRepositoryTest()
    {
        _mockOrderRepository = new Mock<IOrderRepository>();
        _fixture = new Fixture();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public async Task ListOrdersAndMenuItems_ShouldReturnListOfOrdersWithMenuItems()
    {
        // Arrange
        var reservationId = 1;
        var orders = _fixture.CreateMany<Order>(5).ToList();
        var orderItems = _fixture.CreateMany<OrderItem>(10).ToList();
        orders.ForEach(order => order.OrderItems = orderItems);
        _mockOrderRepository.Setup(repo => repo.ListOrdersAndMenuItems(reservationId)).ReturnsAsync(orders);

        // Act
        var result = await _mockOrderRepository.Object.ListOrdersAndMenuItems(reservationId);

        // Assert
        result.Should().BeEquivalentTo(orders);
    }

    [Fact]
    public async Task ListOrderedMenuItems_ShouldReturnListOfMenuItems()
    {
        // Arrange
        var reservationId = 1;
        var menuItems = _fixture.CreateMany<MenuItem>(10).ToList();
        _mockOrderRepository.Setup(repo => repo.ListOrderedMenuItems(reservationId)).ReturnsAsync(menuItems);

        // Act
        var result = await _mockOrderRepository.Object.ListOrderedMenuItems(reservationId);

        // Assert
        result.Should().BeEquivalentTo(menuItems);
    }

    [Fact]
    public async Task CalculateAverageOrderAmount_ShouldReturnAverageOrderAmount()
    {
        // Arrange
        var employeeId = 1;
        var orders = _fixture.CreateMany<Order>(5).ToList();
        orders.ForEach(order => order.TotalAmount = _fixture.Create<decimal>());
        _mockOrderRepository.Setup(repo => repo.CalculateAverageOrderAmount(employeeId)).ReturnsAsync(orders.Select(o => o.TotalAmount).Average());

        // Act
        var result = await _mockOrderRepository.Object.CalculateAverageOrderAmount(employeeId);

        // Assert
        result.Should().Be(orders.Select(o => o.TotalAmount).Average());
    }

    [Fact]
    public async Task ListOrdersAndMenuItems_ShouldThrowNotFoundException_WhenReservationNotFound()
    {
        // Arrange
        var reservationId = 1;
        _mockOrderRepository.Setup(repo => repo.ListOrdersAndMenuItems(reservationId)).ThrowsAsync(new NotFoundException<Reservation>("Reservation not found."));

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException<Reservation>>(async () => await _mockOrderRepository.Object.ListOrdersAndMenuItems(reservationId));
    }

    [Fact]
    public async Task CalculateAverageOrderAmount_ShouldReturnZero_WhenNoOrdersFound()
    {
        // Arrange
        var employeeId = 1;
        _mockOrderRepository.Setup(repo => repo.CalculateAverageOrderAmount(employeeId)).ReturnsAsync(0);

        // Act
        var result = await _mockOrderRepository.Object.CalculateAverageOrderAmount(employeeId);

        // Assert
        result.Should().Be(0);
    }
}
