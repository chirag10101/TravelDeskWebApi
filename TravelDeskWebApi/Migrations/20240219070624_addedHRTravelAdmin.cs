using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelDeskWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addedHRTravelAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 19, 12, 36, 23, 113, DateTimeKind.Local).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 19, 12, 36, 23, 113, DateTimeKind.Local).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 19, 12, 36, 23, 113, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 19, 12, 36, 23, 113, DateTimeKind.Local).AddTicks(6622));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "CreatedBy", "CreatedOn", "DepartmentId", "Email", "FirstName", "IsActive", "LastName", "ManagerId", "MobileNumber", "Password", "RoleId", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 5, "Kolkata", 1, new DateTime(2024, 2, 19, 12, 36, 23, 113, DateTimeKind.Local).AddTicks(6633), 1, "abhinav@gmail.com", "Abhinav", true, "Deep", 2, "9878687737", "QWJoaW5hdkAxMjM=", 4, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

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
    }
}
