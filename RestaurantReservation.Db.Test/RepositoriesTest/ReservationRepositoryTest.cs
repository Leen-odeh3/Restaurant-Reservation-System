using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Test.RepositoriesTest;

public class ReservationRepositoryTest : IDisposable
{
    private readonly DbContextOptions<RestaurantReservationDbContext> _options;
    private readonly RestaurantReservationDbContext _context;
    private readonly ReservationRepository _repository;
    private readonly IFixture _fixture;

    public ReservationRepositoryTest()
    {
        _options = new DbContextOptionsBuilder<RestaurantReservationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new RestaurantReservationDbContext(_options);
        _repository = new ReservationRepository(_context);
        _fixture = new Fixture();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    [Fact]
    public async Task GetReservationsByCustomer_ShouldReturnListOfReservations()
    {
        var customerId = 1;
        var reservations = _fixture.CreateMany<Reservation>(5).ToList();
        reservations.ForEach(reservation => reservation.CustomerId = customerId);
        await _context.Reservations.AddRangeAsync(reservations);
        await _context.SaveChangesAsync();

        var result = await _repository.GetReservationsByCustomer(customerId);

        result.Should().BeEquivalentTo(reservations);
    }

    [Fact]
    public async Task GetReservationsByCustomer_ShouldReturnEmptyList_WhenNoReservationsFound()
    {
        var customerId = 1;

        var result = await _repository.GetReservationsByCustomer(customerId);

        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetReservationsByCustomer_ShouldReturnReservationsOnlyForSpecifiedCustomer()
    {
        var customerId = 1;
        var otherCustomerId = 2;
        var reservations = _fixture.CreateMany<Reservation>(5).ToList();

        reservations.Take(3).ToList().ForEach(reservation => reservation.CustomerId = customerId);
        reservations.Skip(3).ToList().ForEach(reservation => reservation.CustomerId = otherCustomerId);
        await _context.Reservations.AddRangeAsync(reservations);
        await _context.SaveChangesAsync();

        var result = await _repository.GetReservationsByCustomer(customerId);

        result.Should().OnlyContain(r => r.CustomerId == customerId);
    }

    [Fact]
    public async Task GetReservationsByCustomer_ShouldThrowException_WhenCustomerIdIsInvalid()
    {
        var invalidCustomerId = -1;

        await Assert.ThrowsAsync<Exception>(async () => await _repository.GetReservationsByCustomer(invalidCustomerId));
    }
}
