using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantReservation.Db.Migrations
{
    public partial class CreateViewModel0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 5, 17, 16, 45, 10, 281, DateTimeKind.Local).AddTicks(3690));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 5, 16, 16, 45, 10, 284, DateTimeKind.Local).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 5, 15, 16, 45, 10, 284, DateTimeKind.Local).AddTicks(6751));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 5, 14, 16, 45, 10, 284, DateTimeKind.Local).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 5, 13, 16, 45, 10, 284, DateTimeKind.Local).AddTicks(6758));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 5, 17, 16, 36, 52, 133, DateTimeKind.Local).AddTicks(4241));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 5, 16, 16, 36, 52, 137, DateTimeKind.Local).AddTicks(3900));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 5, 15, 16, 36, 52, 137, DateTimeKind.Local).AddTicks(4002));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 5, 14, 16, 36, 52, 137, DateTimeKind.Local).AddTicks(4016));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 5, 13, 16, 36, 52, 137, DateTimeKind.Local).AddTicks(4022));
        }
    }
}
