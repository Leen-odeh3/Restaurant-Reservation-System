using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Exceptions;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Test.RepositoriesTest;

public class OrderRepositoryTest
{
    private readonly DbContextOptions<RestaurantReservationDbContext> _options;
    private readonly RestaurantReservationDbContext _context;
    private readonly OrderRepository _repository;
    private readonly IFixture _fixture;
    private Order _order; 

    public OrderRepositoryTest()
    {
        _options = new DbContextOptionsBuilder<RestaurantReservationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _fixture = new Fixture();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        _order = _fixture.Create<Order>();

        _context = new RestaurantReservationDbContext(_options); 
        _repository = _fixture.Create<OrderRepository>();

    }

    [Fact]
    public async Task UpdateOrder_ShouldHandleNegativeTotalAmount()
    {
        var order = _fixture.Create<Order>();
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();

        order.TotalAmount = -10;

        await Assert.ThrowsAsync<NegativeTotalAmountException>(() => _repository.UpdateAsync(order));

        var updatedOrder = await _context.Orders.FindAsync(order.Id);
        updatedOrder.TotalAmount.Should().NotBe(order.TotalAmount);
    }


    [Fact]
    public async Task AddOrder_ShouldAddOrderToDatabase()
    {
        await _repository.AddAsync(_order);

        var addedOrder = await _context.Orders.FindAsync(_order.Id);
        addedOrder.Should().NotBeNull();
    }

    [Fact]
    public async Task UpdateOrder_ShouldUpdateOrderInDatabase()
    {
        // Arrange
        await _context.Orders.AddAsync(_order);
        await _context.SaveChangesAsync();

        _order.TotalAmount += 10;
        await _repository.UpdateAsync(_order);

        var updatedOrder = await _context.Orders.FindAsync(_order.Id);
        updatedOrder.TotalAmount.Should().Be(_order.TotalAmount);
    }

    [Fact]
    public async Task DeleteOrder_ShouldRemoveOrderFromDatabase()
    {
        await _context.Orders.AddAsync(_order);
        await _context.SaveChangesAsync();

        await _repository.DeleteAsync(_order);

        var deletedOrder = await _context.Orders.FindAsync(_order.Id);
        deletedOrder.Should().BeNull();
    }


    [Fact]
    public async Task ListOrdersAndMenuItems_ShouldThrowExceptionForInvalidReservationId()
    {
        // Arrange
        var invalidReservationId = -1; 

        await Assert.ThrowsAsync<NotFoundException<Reservation>>(async () =>
        {
            await _repository.ListOrdersAndMenuItems(invalidReservationId);
        });
    }

    [Fact]
    public async Task CalculateAverageOrderAmount_ShouldReturnZeroForInvalidEmployeeId()
    {
        var invalidEmployeeId = -1; 

        var result = await _repository.CalculateAverageOrderAmount(invalidEmployeeId);

        result.Should().Be(0); 
    }


    [Fact]
    public async Task ListOrdersAndMenuItems_ShouldReturnOrdersWithMenuItemsForValidReservationId()
    {
        // Arrange
        var reservation = _fixture.Create<Reservation>();
        reservation.Orders = _fixture.CreateMany<Order>(3).ToList();
        foreach (var order in reservation.Orders)
        {
            order.OrderItems = _fixture.CreateMany<OrderItem>(2).ToList();
            foreach (var orderItem in order.OrderItems)
            {
                orderItem.MenuItem = _fixture.Create<MenuItem>();
            }
        }
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ListOrdersAndMenuItems(reservation.ReservationId);

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(reservation.Orders.Count);

        foreach (var order in result)
        {
            order.OrderItems.Should().NotBeEmpty();
            foreach (var orderItem in order.OrderItems)
            {
                orderItem.MenuItem.Should().NotBeNull();
            }
        }
    }
  
}

