using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantReservation.Db.Migrations
{
    public partial class UpdateColumnTablesReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reservations",
                newName: "ReservationId");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 5, 18, 9, 41, 58, 973, DateTimeKind.Local).AddTicks(3180));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 5, 17, 9, 41, 58, 975, DateTimeKind.Local).AddTicks(2856));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 5, 16, 9, 41, 58, 975, DateTimeKind.Local).AddTicks(2898));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 5, 15, 9, 41, 58, 975, DateTimeKind.Local).AddTicks(2904));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 5, 14, 9, 41, 58, 975, DateTimeKind.Local).AddTicks(2906));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Reservations",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 5, 18, 9, 38, 44, 73, DateTimeKind.Local).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 5, 17, 9, 38, 44, 77, DateTimeKind.Local).AddTicks(1337));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 5, 16, 9, 38, 44, 77, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 5, 15, 9, 38, 44, 77, DateTimeKind.Local).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 5, 14, 9, 38, 44, 77, DateTimeKind.Local).AddTicks(1374));
        }
    }
}
