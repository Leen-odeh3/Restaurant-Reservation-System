using RestaurantReservation.Db.Data;

namespace RestaurantReservation.Db.Test.DbConnectionTest
{
    public class DbConnectionTest
    {
        [Fact]
        public void Check_Connection()
        {
            // Arrange
            using var context = new RestaurantReservationDbContext();

            // Act
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Assert
            Assert.NotNull(context);
            Assert.NotEmpty(context.Reservations);
            Assert.NotEmpty(context.Orders);
        }
    }
}
