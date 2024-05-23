using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Test.Helper;

namespace RestaurantReservation.Db.Test.DbConnectionTest;
public class DbConnectionTest
{
    [Fact]
    public void check_Connection()
    {
        RestaurantReservationDbContext context = new RestaurantReservationDbContext(DatabaseConnectionTest.GetConnection());
        
        if (context is not null) { 

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        Assert.NotNull(context);
        Assert.NotEmpty(context.Reservations);
        Assert.NotEmpty(context.Orders);
    }
}
