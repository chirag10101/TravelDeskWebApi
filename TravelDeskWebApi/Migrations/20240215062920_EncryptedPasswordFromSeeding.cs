using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelDeskWebApi.Migrations
{
    /// <inheritdoc />
    public partial class EncryptedPasswordFromSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2024, 2, 15, 11, 59, 19, 390, DateTimeKind.Local).AddTicks(4717), "Q2hpcmFnQDEyMw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2024, 2, 15, 11, 59, 19, 390, DateTimeKind.Local).AddTicks(4724), "QW5pbWVzaCExMjM=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2024, 2, 15, 11, 59, 19, 390, DateTimeKind.Local).AddTicks(4728), "U2F1cmF2ITEyMzQ=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2024, 2, 15, 11, 59, 19, 390, DateTimeKind.Local).AddTicks(4732), "UHJpeWFAMTIz" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2024, 2, 14, 18, 0, 9, 829, DateTimeKind.Local).AddTicks(3312), "Chirag@123" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2024, 2, 14, 18, 0, 9, 829, DateTimeKind.Local).AddTicks(3320), "Animesh!123" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2024, 2, 14, 18, 0, 9, 829, DateTimeKind.Local).AddTicks(3325), "Saurav!1234" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Password" },
                values: new object[] { new DateTime(2024, 2, 14, 18, 0, 9, 829, DateTimeKind.Local).AddTicks(3330), "Priya@123" });
        }
    }
}
