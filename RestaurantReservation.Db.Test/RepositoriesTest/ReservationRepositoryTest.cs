using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Test.RepositoriesTest;

public class ReservationRepositoryTest
{
    private readonly DbContextOptions<RestaurantReservationDbContext> _options;
    private readonly RestaurantReservationDbContext _context;
    private readonly ReservationRepository _repository;
    private readonly IFixture _fixture;

    public ReservationRepositoryTest()
    {
        _options = new DbContextOptionsBuilder<RestaurantReservationDbContext>()
            .UseInMemoryDatabase(databaseName: "_TestDatabase")
            .Options;

        _context = new RestaurantReservationDbContext(_options);
        _repository = new ReservationRepository(_context);
        _fixture = new Fixture();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public async Task AddReservation_ShouldAddReservationToDatabase()
    {
        // Arrange
        var reservation = _fixture.Create<Reservation>();

        await _repository.AddAsync(reservation);

        var addedReservation = await _context.Reservations.FindAsync(reservation.ReservationId);
        addedReservation.Should().NotBeNull();
        addedReservation.Should().BeEquivalentTo(reservation);
    }

    [Fact]
    public async Task DeleteReservation_ShouldRemoveReservationFromDatabase()
    {
        var reservation = _fixture.Create<Reservation>();
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();

        await _repository.DeleteAsync(reservation);

        var deletedReservation = await _context.Reservations.FindAsync(reservation.ReservationId);
        deletedReservation.Should().BeNull();
    }


    [Fact]
    public async Task GetReservationById_ShouldReturnReservation()
    {
        var reservation = _fixture.Create<Reservation>();
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();

        var result = await _repository.GetByIdAsync(reservation.ReservationId);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(reservation);
    }

    private List<Reservation> PrepareReservations(int customerId)
    {
        var reservations = new List<Reservation>
            {
                new Reservation { ReservationDate = DateTime.Now.Date, PartySize = 4, CustomerId = customerId },
                new Reservation { ReservationDate = DateTime.Now.Date, PartySize = 2, CustomerId = customerId },
                new Reservation { ReservationDate = DateTime.Now.Date, PartySize = 6, CustomerId = customerId },
                new Reservation { ReservationDate = DateTime.Now.Date, PartySize = 3, CustomerId = customerId },
                new Reservation { ReservationDate = DateTime.Now.Date, PartySize = 5, CustomerId = customerId }
            };

        return reservations;
    }

    [Fact]
    public async Task GetReservationsByCustomer_ShouldReturnReservationsForSpecifiedCustomer()
    {
        var customerId = 1;

        var reservations = PrepareReservations(customerId);

        await _context.Reservations.AddRangeAsync(reservations);
        await _context.SaveChangesAsync();

        var result = await _repository.GetReservationsByCustomer(customerId);

        result.Should().NotBeNullOrEmpty(); 
        result.Should().HaveCount(reservations.Count); 
        result.Should().BeEquivalentTo(reservations);
    }
}
