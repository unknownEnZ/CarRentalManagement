using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalManagement.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", null, "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "8c51a19d-3fd6-4188-9c6d-5db43172f214", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEDXWaRgWxYlZf/tqoRafQp9VKHwRPKBo5bqED8BWUauFfoL5zwgOR4Ts/azLKMRAEQ==", null, false, "7291139d-262c-44a4-82a2-a632a1f423ac", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 12, 3, 15, 52, 4, 398, DateTimeKind.Local).AddTicks(5256), new DateTime(2023, 12, 3, 15, 52, 4, 398, DateTimeKind.Local).AddTicks(5275), "Black", "System" },
                    { 2, "System", new DateTime(2023, 12, 3, 15, 52, 4, 398, DateTimeKind.Local).AddTicks(5280), new DateTime(2023, 12, 3, 15, 52, 4, 398, DateTimeKind.Local).AddTicks(5281), "Blue", "System" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 12, 3, 15, 52, 4, 398, DateTimeKind.Local).AddTicks(6020), new DateTime(2023, 12, 3, 15, 52, 4, 398, DateTimeKind.Local).AddTicks(6023), "BMW", "System" },
                    { 2, "System", new DateTime(2023, 12, 3, 15, 52, 4, 398, DateTimeKind.Local).AddTicks(6027), new DateTime(2023, 12, 3, 15, 52, 4, 398, DateTimeKind.Local).AddTicks(6028), "Toyota", "System" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 12, 3, 15, 52, 4, 398, DateTimeKind.Local).AddTicks(7133), new DateTime(2023, 12, 3, 15, 52, 4, 398, DateTimeKind.Local).AddTicks(7135), "3 Series", "System" },
                    { 2, "System", new DateTime(2023, 12, 3, 15, 52, 4, 398, DateTimeKind.Local).AddTicks(7138), new DateTime(2023, 12, 3, 15, 52, 4, 398, DateTimeKind.Local).AddTicks(7139), "X5", "System" },
                    { 3, "System", new DateTime(2023, 12, 3, 15, 52, 4, 398, DateTimeKind.Local).AddTicks(7142), new DateTime(2023, 12, 3, 15, 52, 4, 398, DateTimeKind.Local).AddTicks(7143), "Prius", "System" },
                    { 4, "System", new DateTime(2023, 12, 3, 15, 52, 4, 398, DateTimeKind.Local).AddTicks(7145), new DateTime(2023, 12, 3, 15, 52, 4, 398, DateTimeKind.Local).AddTicks(7146), "RAV4", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");
        }
    }
}
