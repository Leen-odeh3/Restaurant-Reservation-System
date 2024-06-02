using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantReservation.Db.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 5, 18, 11, 49, 15, 12, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 5, 17, 11, 49, 15, 13, DateTimeKind.Local).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 5, 16, 11, 49, 15, 13, DateTimeKind.Local).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 5, 15, 11, 49, 15, 13, DateTimeKind.Local).AddTicks(5098));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 5, 14, 11, 49, 15, 13, DateTimeKind.Local).AddTicks(5100));

            migrationBuilder.Sql(@"
                CREATE PROCEDURE dbo.FindCustomersWithPartySizeGreaterThan
                @partySize INT 
                AS
                SELECT  Customers.*
                FROM Reservations
                INNER JOIN Customers 
                ON Reservations.CustomerId = Customers.CustomerId
                WHERE Reservations.PartySize > @partySize");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 5, 18, 11, 47, 6, 429, DateTimeKind.Local).AddTicks(2162));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 5, 17, 11, 47, 6, 431, DateTimeKind.Local).AddTicks(3467));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 5, 16, 11, 47, 6, 431, DateTimeKind.Local).AddTicks(3517));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 5, 15, 11, 47, 6, 431, DateTimeKind.Local).AddTicks(3522));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 5, 14, 11, 47, 6, 431, DateTimeKind.Local).AddTicks(3526));
           
            migrationBuilder.Sql("DROP PROCEDURE dbo.FindCustomersWithPartySizeGreaterThan");

        }
    }
}
