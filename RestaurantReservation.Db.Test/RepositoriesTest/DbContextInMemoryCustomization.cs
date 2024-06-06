using AutoFixture;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;


namespace RestaurantReservation.Db.Test.RepositoriesTest;

public class DbContextInMemoryCustomization : ICustomization
{
    private readonly string _databaseName;
    public DbContextInMemoryCustomization(string databaseName) => this._databaseName = databaseName;
    public void Customize(IFixture fixture) =>
        fixture.Register(() =>
            new RestaurantReservationDbContext(new DbContextOptionsBuilder<RestaurantReservationDbContext>()
                .UseInMemoryDatabase(databaseName: this._databaseName)
                .Options));
}
