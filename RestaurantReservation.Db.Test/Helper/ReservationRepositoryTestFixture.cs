using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Test.Helper;

public class ReservationRepositoryTestFixture : IDisposable
{
    public ReservationRepository Repository { get; set; }
    public RestaurantReservationDbContext Context { get; set; }

    public ReservationRepositoryTestFixture()
    {
        var options = new DbContextOptionsBuilder<RestaurantReservationDbContext>()
            .UseInMemoryDatabase(databaseName: "test_database")
            .Options;

        Context = new RestaurantReservationDbContext(options);
        Repository = new ReservationRepository(Context);
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}
