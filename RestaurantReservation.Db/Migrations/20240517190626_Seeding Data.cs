using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantReservation.Db.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "John.doe@example.com", "John", "Doe", "123-456-7890" },
                    { 2, "Jane.doe@example.com", "Jane", "Doe", "987-654-3210" },
                    { 3, "Alice.smith@example.com", "Alice", "Smith", "555-123-4567" },
                    { 4, "Bob.smith@example.com", "Bob", "Smith", "555-987-6543" },
                    { 5, "Charlie.brown@example.com", "Charlie", "Brown", "555-555-5555" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "1234 Culinary Blvd, Foodie Town", "Gourmet Hub", "9:00 AM - 11:00 PM", "555-1234" },
                    { 2, "5678 Pasta Lane, Little Italy", "The Italian Corner", "11:00 AM - 10:00 PM", "555-5678" },
                    { 3, "135 Sushi St, Downtown", "Sushi Sushi", "12:00 PM - 10:00 PM", "555-1357" },
                    { 4, "2468 Curry Ave, Spice City", "Curry Leaf", "10:00 AM - 9:00 PM", "555-2468" },
                    { 5, "7890 Burger Blvd, Greasy Corner", "The Burger Joint", "10:00 AM - 12:00 AM", "555-7890" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "Position", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Ella", "Fitzgerald", "Manager", 1 },
                    { 2, "Louis", "Armstrong", "Chef", 1 },
                    { 3, "Billie", "Holiday", "Waiter", 1 },
                    { 5, "Dizzy", "Gillespie", "Waiter", 2 },
                    { 4, "Charlie", "Parker", "Cashier", 2 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 5, "Creamy pasta with pancetta, parmesan cheese, and a touch of egg.", "Pasta Carbonara", 11.00m, 3 },
                    { 4, "Classic pizza with fresh mozzarella, tomatoes, and basil.", "Margherita Pizza", 12.00m, 2 },
                    { 3, "Crisp romaine lettuce with grilled chicken breast, shaved parmesan, and croutons.", "Chicken Caesar Salad", 7.75m, 2 },
                    { 2, "A delicious and hearty vegetarian burger loaded with fresh vegetables.", "Veggie Burger", 9.50m, 1 },
                    { 1, "A juicy beef patty with lettuce, tomato, and our special sauce.", "Classic Burger", 8.99m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 9, 4, 5 },
                    { 3, 6, 2 },
                    { 4, 4, 2 },
                    { 5, 8, 3 },
                    { 6, 4, 3 },
                    { 7, 4, 4 },
                    { 8, 2, 4 },
                    { 2, 2, 1 },
                    { 10, 6, 5 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "PartySize", "ReservationDate", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 4, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Local), 1, 1 },
                    { 2, 2, 2, new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Local), 1, 2 },
                    { 3, 3, 6, new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Local), 2, 3 },
                    { 4, 4, 3, new DateTime(2024, 5, 23, 0, 0, 0, 0, DateTimeKind.Local), 2, 4 },
                    { 5, 5, 5, new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Local), 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "EmployeeId", "OrderDate", "ReservationId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2024, 5, 16, 22, 6, 25, 437, DateTimeKind.Local).AddTicks(284), 1, 45m },
                    { 2, 3, new DateTime(2024, 5, 15, 22, 6, 25, 439, DateTimeKind.Local).AddTicks(9734), 2, 30m },
                    { 3, 3, new DateTime(2024, 5, 14, 22, 6, 25, 439, DateTimeKind.Local).AddTicks(9758), 3, 60m },
                    { 4, 5, new DateTime(2024, 5, 13, 22, 6, 25, 439, DateTimeKind.Local).AddTicks(9761), 4, 22m },
                    { 5, 3, new DateTime(2024, 5, 12, 22, 6, 25, 439, DateTimeKind.Local).AddTicks(9781), 5, 80m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "MenuItemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 1, 1 },
                    { 3, 3, 2, 3 },
                    { 4, 4, 2, 1 },
                    { 5, 5, 3, 1 },
                    { 6, 1, 3, 2 },
                    { 7, 2, 4, 4 },
                    { 8, 3, 4, 2 },
                    { 9, 4, 5, 3 },
                    { 10, 5, 5, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
