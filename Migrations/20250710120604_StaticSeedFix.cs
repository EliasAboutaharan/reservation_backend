using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reservation_backend.Migrations
{
    /// <inheritdoc />
    public partial class StaticSeedFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "QRCodeTokens",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Expiration", "Uuid" },
                values: new object[] { new DateTime(2025, 7, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.UpdateData(
                table: "QRCodeTokens",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Expiration", "Uuid" },
                values: new object[] { new DateTime(2025, 7, 10, 13, 0, 0, 0, DateTimeKind.Unspecified), "22222222-2222-2222-2222-222222222222" });

            migrationBuilder.UpdateData(
                table: "QRCodeTokens",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Expiration", "Uuid" },
                values: new object[] { new DateTime(2025, 7, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "33333333-3333-3333-3333-333333333333" });

            migrationBuilder.UpdateData(
                table: "QRCodeTokens",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Expiration", "Uuid" },
                values: new object[] { new DateTime(2025, 7, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), "44444444-4444-4444-4444-444444444444" });

            migrationBuilder.UpdateData(
                table: "QRCodeTokens",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Expiration", "Uuid" },
                values: new object[] { new DateTime(2025, 7, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), "55555555-5555-5555-5555-555555555555" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "QRCodeTokens",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Expiration", "Uuid" },
                values: new object[] { new DateTime(2025, 7, 10, 18, 4, 17, 482, DateTimeKind.Local).AddTicks(6642), "06fa41e9-d7c0-444a-875d-af8a68827324" });

            migrationBuilder.UpdateData(
                table: "QRCodeTokens",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Expiration", "Uuid" },
                values: new object[] { new DateTime(2025, 7, 10, 19, 4, 17, 485, DateTimeKind.Local).AddTicks(41), "46609920-7fd2-4433-842d-8998c64b2068" });

            migrationBuilder.UpdateData(
                table: "QRCodeTokens",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Expiration", "Uuid" },
                values: new object[] { new DateTime(2025, 7, 10, 13, 4, 17, 485, DateTimeKind.Local).AddTicks(85), "76506013-fad6-450e-a7b3-8b3cc552f150" });

            migrationBuilder.UpdateData(
                table: "QRCodeTokens",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Expiration", "Uuid" },
                values: new object[] { new DateTime(2025, 7, 10, 16, 4, 17, 485, DateTimeKind.Local).AddTicks(90), "e1878767-d27f-47a9-95b8-32e0a1ae70b0" });

            migrationBuilder.UpdateData(
                table: "QRCodeTokens",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Expiration", "Uuid" },
                values: new object[] { new DateTime(2025, 7, 10, 17, 4, 17, 485, DateTimeKind.Local).AddTicks(185), "038cde52-06ce-4dd5-99d3-0bb7d1db64c1" });
        }
    }
}
