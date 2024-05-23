
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;

namespace RestaurantReservation.Db.Test.Helper;

public class DatabaseConnectionTest
{
    public static DbContextOptions<RestaurantReservationDbContext> GetConnection()
    {
        DbContextOptions<RestaurantReservationDbContext> _dbOptions;

        var builder = new DbContextOptionsBuilder<RestaurantReservationDbContext>();
        var conn = new SqliteConnection("DataSource=:memory:");

        conn.Open();
        _dbOptions= builder.UseSqlite(conn).Options;

        return _dbOptions;
    }
}
