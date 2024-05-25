using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Test.Helper;
public static class OrderTestData
{
    public static List<Order> GetTestOrders()
    {
        var orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    OrderDate = DateTime.Parse("2024-05-01"),
                    TotalAmount = 50.00m,
                    EmployeeId = 1,
                    ReservationId = 1,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Id = 1,
                            MenuItemId = 1,
                            Quantity = 2
                        },
                        new OrderItem
                        {
                            Id = 2,
                            MenuItemId = 2,
                            Quantity = 1
                        }
                    }
                },
                new Order
                {
                    Id = 2,
                    OrderDate = DateTime.Parse("2024-05-02"),
                    TotalAmount = 40.00m,
                    EmployeeId = 2,
                    ReservationId = 1,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Id = 3,
                            MenuItemId = 3,
                            Quantity = 3
                        },
                        new OrderItem
                        {
                            Id = 4,
                            MenuItemId = 4,
                            Quantity = 1
                        }
                    }
                }
            };

        return orders;
    }
}