using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Test.Helper;

namespace RestaurantReservation.Db.Test.RepositoriesTest;
public class ReservationRepositoryTest : IClassFixture<ReservationRepositoryTestFixture>
{
    private readonly ReservationRepositoryTestFixture _fixture;

    public ReservationRepositoryTest(ReservationRepositoryTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetByIdAsync_ExistingReservationId_ShouldReturnReservation()
    {
        var existingReservationId = 1;
        var reservation = new Reservation { ReservationId = existingReservationId, ReservationDate = DateTime.Now, PartySize = 2 };
        await _fixture.Context.Reservations.AddAsync(reservation);
        await _fixture.Context.SaveChangesAsync();

        var result = await _fixture.Repository.GetByIdAsync(existingReservationId);

        Assert.NotNull(result);
        Assert.Equal(existingReservationId, result.ReservationId);
    }

    [Fact]
    public async Task GetAllAsync_NoReservationsInDatabase_ShouldReturnEmptyList()
    {
        var result = await _fixture.Repository.GetAllAsync();

        Assert.Empty(result);
    }

    [Fact]
    public async Task GetReservationsByCustomer_ValidCustomerId_ShouldReturnReservations()
    {
        var customerId = 1;
        var reservations = new List<Reservation>
    {
        new Reservation { ReservationId = 1, ReservationDate = DateTime.Now, PartySize = 2, CustomerId = customerId },
        new Reservation { ReservationId = 2, ReservationDate = DateTime.Now, PartySize = 4, CustomerId = customerId },
        new Reservation { ReservationId = 3, ReservationDate = DateTime.Now, PartySize = 3, CustomerId = customerId + 1 }
    };
        await _fixture.Context.Reservations.AddRangeAsync(reservations);
        await _fixture.Context.SaveChangesAsync();

        var result = await _fixture.Repository.GetReservationsByCustomer(customerId);

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.All(result, r => Assert.Equal(customerId, r.CustomerId));
    }

    [Fact]
    public async Task AddReservation_WithNullEntity_ShouldThrowException()
    {
        Reservation reservation = null;
        await Assert.ThrowsAsync<ArgumentNullException>(() => _fixture.Repository.AddAsync(reservation));
    }
}
