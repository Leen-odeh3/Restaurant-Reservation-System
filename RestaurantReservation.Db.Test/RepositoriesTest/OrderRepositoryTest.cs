using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Test.Helper;

namespace RestaurantReservation.Db.Test.RepositoriesTest;
public class OrderRepositoryTest
{
    private readonly DbContextOptions<RestaurantReservationDbContext> _options;

    public OrderRepositoryTest()
    {
        _options = new DbContextOptionsBuilder<RestaurantReservationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
    }
    private async Task SeedOrders(RestaurantReservationDbContext context)
    {
        if (!context.Orders.Any())
        {
            var orders = OrderTestData.GetTestOrders();
            await context.Orders.AddRangeAsync(orders);
            await context.SaveChangesAsync();
        }
    }
    [Fact]
    public async Task RemoveOrder_RemovesOrderSuccessfully()
    {
        using (var context = new RestaurantReservationDbContext(_options))
        {
            await SeedOrders(context);
            var repository = new OrderRepository(context);

            var orderToRemove = await repository.GetByIdAsync(1);

            await repository.DeleteAsync(orderToRemove);
            var remainingOrders = await repository.GetAllAsync();

            Assert.DoesNotContain(orderToRemove, remainingOrders);
        }
    }

    [Fact]
    public async Task CalculateAverageOrderAmount_ReturnsCorrectAverage_WhenEmployeeHasOrders()
    {
        using (var context = new RestaurantReservationDbContext(_options))
        {
            // Arrange
            await SeedOrders(context);
            var repository = new OrderRepository(context);

            // Act
            var averageOrderAmount = await repository.CalculateAverageOrderAmount(1);

            // Assert
            Assert.Equal(50.00m, averageOrderAmount);
        }
    }

    [Fact]
    public async Task CalculateAverageOrderAmount_ReturnsZero_WhenEmployeeHasNoOrders()
    {
        using (var context = new RestaurantReservationDbContext(_options))
        {
            // Arrange
            await SeedOrders(context);
            var repository = new OrderRepository(context);

            // Act
            var averageOrderAmount = await repository.CalculateAverageOrderAmount(99);

            // Assert
            Assert.Equal(0, averageOrderAmount);
        }
    }
}
