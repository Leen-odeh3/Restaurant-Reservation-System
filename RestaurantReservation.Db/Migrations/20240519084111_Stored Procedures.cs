using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantReservation.Db.Migrations
{
    public partial class StoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 5, 18, 11, 41, 9, 869, DateTimeKind.Local).AddTicks(5512));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 5, 17, 11, 41, 9, 872, DateTimeKind.Local).AddTicks(9734));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 5, 16, 11, 41, 9, 872, DateTimeKind.Local).AddTicks(9766));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 5, 15, 11, 41, 9, 872, DateTimeKind.Local).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 5, 14, 11, 41, 9, 872, DateTimeKind.Local).AddTicks(9772));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
