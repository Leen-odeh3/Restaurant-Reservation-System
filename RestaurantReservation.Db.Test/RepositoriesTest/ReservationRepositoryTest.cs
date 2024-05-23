using Microsoft.EntityFrameworkCore;
using Moq;
using RestaurantReservation.Db.Abstracts;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Exceptions;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Test.Helper;

namespace RestaurantReservation.Db.Test.RepositoriesTest;
public class ReservationRepositoryTest
{
    [Fact]
    public async Task GetReservationsByCustomer_NonExistingCustomer_ThrowsNotFoundException()
    {
        // Arrange
        var customerId = 1;
        var mockContext = new Mock<RestaurantReservationDbContext>();
        var mockCustomerRepository = new Mock<ICustomerRepository>();
        mockCustomerRepository.Setup(c => c.GetByIdAsync(customerId))
            .ReturnsAsync((Customer)null);

        var repository = new ReservationRepository(mockContext.Object, mockCustomerRepository.Object);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException<Customer>>(async () =>
        {
            await repository.GetReservationsByCustomer(customerId);
        });
    }


}
