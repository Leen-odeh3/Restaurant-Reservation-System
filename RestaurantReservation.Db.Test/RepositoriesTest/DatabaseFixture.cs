
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;

namespace RestaurantReservation.Db.Test.RepositoriesTest;
public class DatabaseFixture : IDisposable
{
    public DatabaseFixture()
    {
        Options = new DbContextOptionsBuilder<RestaurantReservationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new RestaurantReservationDbContext(Options))
        {
            context.Database.EnsureCreated();
        }
    }

    public DbContextOptions<RestaurantReservationDbContext> Options { get; }

    public void Dispose()
    {
        using (var context = new RestaurantReservationDbContext(Options))
        {
            context.Database.EnsureDeleted();
        }
    }
}