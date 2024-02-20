using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelDeskWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addedUpdatedOn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "TravelRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 12, 21, 40, 594, DateTimeKind.Local).AddTicks(7221));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 12, 21, 40, 594, DateTimeKind.Local).AddTicks(7260));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 12, 21, 40, 594, DateTimeKind.Local).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 12, 21, 40, 594, DateTimeKind.Local).AddTicks(7271));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "TravelRequests");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 12, 20, 28, 338, DateTimeKind.Local).AddTicks(4965));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 12, 20, 28, 338, DateTimeKind.Local).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 12, 20, 28, 338, DateTimeKind.Local).AddTicks(4983));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 12, 20, 28, 338, DateTimeKind.Local).AddTicks(4990));
        }
    }
}
