using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelDeskWebApi.Migrations
{
    /// <inheritdoc />
    public partial class changedRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "TravelRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 17, 21, 15, 151, DateTimeKind.Local).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 17, 21, 15, 151, DateTimeKind.Local).AddTicks(4640));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 17, 21, 15, 151, DateTimeKind.Local).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 17, 21, 15, 151, DateTimeKind.Local).AddTicks(4649));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "TravelRequests");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 11, 59, 19, 390, DateTimeKind.Local).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 11, 59, 19, 390, DateTimeKind.Local).AddTicks(4724));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 11, 59, 19, 390, DateTimeKind.Local).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 15, 11, 59, 19, 390, DateTimeKind.Local).AddTicks(4732));
        }
    }
}
