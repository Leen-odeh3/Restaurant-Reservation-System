using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantReservation.Db.Migrations
{
    public partial class CreateMethods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 5, 18, 10, 58, 15, 341, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 5, 17, 10, 58, 15, 342, DateTimeKind.Local).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 5, 16, 10, 58, 15, 342, DateTimeKind.Local).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 5, 15, 10, 58, 15, 342, DateTimeKind.Local).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 5, 14, 10, 58, 15, 342, DateTimeKind.Local).AddTicks(8696));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 5, 18, 10, 0, 25, 896, DateTimeKind.Local).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 5, 17, 10, 0, 25, 898, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 5, 16, 10, 0, 25, 898, DateTimeKind.Local).AddTicks(1316));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 5, 15, 10, 0, 25, 898, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 5, 14, 10, 0, 25, 898, DateTimeKind.Local).AddTicks(1322));
        }
    }
}
