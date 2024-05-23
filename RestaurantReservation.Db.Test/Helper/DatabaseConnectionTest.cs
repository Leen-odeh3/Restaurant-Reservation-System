using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;

namespace RestaurantReservation.Db.Test.Helper;

public class DatabaseConnectionTest
{
    public static DbContextOptions<RestaurantReservationDbContext> GetConnection()
    {
        var builder = new DbContextOptionsBuilder<RestaurantReservationDbContext>();
        builder.UseSqlServer("Server=.;Database=RestaurantReservationCore;Trusted_Connection=True;MultipleActiveResultSets=true");
        return builder.Options;
    }

}
