using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Enums;

namespace RestaurantReservation.Db.Test.Helper;

public static class TestDataSeeder
{
    public static async Task SeedEmployees(RestaurantReservationDbContext context)
    {
        var employees = new[]
        {
        new Employee { FirstName = "Ella", LastName = "Fitzgerald", Position = EmployeePosition.Manager, RestaurantId = 1 },
        new Employee { FirstName = "Louis", LastName = "Armstrong", Position = EmployeePosition.Chef, RestaurantId = 1 },
        new Employee { FirstName = "Billie", LastName = "Holiday", Position = EmployeePosition.Waiter, RestaurantId = 1 },
        new Employee { FirstName = "Charlie", LastName = "Parker", Position = EmployeePosition.Manager, RestaurantId = 2 },
        new Employee { FirstName = "Dizzy", LastName = "Gillespie", Position = EmployeePosition.Cashier, RestaurantId = 2 }
    };

        await context.AddRangeAsync(employees);
        await context.SaveChangesAsync();
    }
}