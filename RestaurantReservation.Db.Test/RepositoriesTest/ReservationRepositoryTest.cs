using AutoFixture;
using FluentAssertions;
using Moq;
using RestaurantReservation.Db.Abstracts;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Test.RepositoriesTest;

public class ReservationRepositoryTest
{
    private readonly Mock<RestaurantReservationDbContext> _mockDbContext;
    private readonly Mock<IReservationRepository> _mockReservationRepository;
    private readonly Fixture _fixture;

    public ReservationRepositoryTest()
    {
        _mockReservationRepository = new Mock<IReservationRepository>();
        _fixture = new Fixture();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public async Task GetReservationsByCustomer_ShouldReturnListOfReservations()
    {
        // Arrange
        var customerId = 1;
        var reservations = _fixture.CreateMany<Reservation>(5).ToList();
        reservations.ForEach(reservation => reservation.CustomerId = customerId);
        _mockReservationRepository.Setup(repo => repo.GetReservationsByCustomer(customerId)).ReturnsAsync(reservations);

        // Act
        var result = await _mockReservationRepository.Object.GetReservationsByCustomer(customerId);

        // Assert
        result.Should().BeEquivalentTo(reservations);
    }

    [Fact]
    public async Task GetReservationsByCustomer_ShouldReturnEmptyList_WhenNoReservationsFound()
    {
        // Arrange
        var customerId = 1;
        _mockReservationRepository.Setup(repo => repo.GetReservationsByCustomer(customerId)).ReturnsAsync(new List<Reservation>());

        // Act
        var result = await _mockReservationRepository.Object.GetReservationsByCustomer(customerId);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetReservationsByCustomer_ShouldReturnReservationsOnlyForSpecifiedCustomer()
    {
        // Arrange
        var customerId = 1;
        var otherCustomerId = 2;
        var reservations = _fixture.CreateMany<Reservation>(5).ToList();
     
        reservations.Take(3).ToList().ForEach(reservation => reservation.CustomerId = customerId);
        reservations.Skip(3).ToList().ForEach(reservation => reservation.CustomerId = otherCustomerId);
        _mockReservationRepository.Setup(repo => repo.GetReservationsByCustomer(customerId))
            .ReturnsAsync(reservations.Where(r => r.CustomerId == customerId).ToList());

        // Act
        var result = await _mockReservationRepository.Object.GetReservationsByCustomer(customerId);

        // Assert
        result.Should().OnlyContain(r => r.CustomerId == customerId);
    }

    [Fact]
    public async Task GetReservationsByCustomer_ShouldThrowException_WhenCustomerIdIsInvalid()
    {
        // Arrange
        var invalidCustomerId = -1;
        _mockReservationRepository.Setup(repo => repo.GetReservationsByCustomer(invalidCustomerId)).ThrowsAsync(new Exception("Invalid customer ID"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(async () => await _mockReservationRepository.Object.GetReservationsByCustomer(invalidCustomerId));
    }
}

