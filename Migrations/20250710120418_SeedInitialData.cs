using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace reservation_backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QRCodeTokens",
                columns: new[] { "Id", "Expiration", "IsUsed", "Uuid" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 10, 18, 4, 17, 482, DateTimeKind.Local).AddTicks(6642), false, "06fa41e9-d7c0-444a-875d-af8a68827324" },
                    { 2, new DateTime(2025, 7, 10, 19, 4, 17, 485, DateTimeKind.Local).AddTicks(41), false, "46609920-7fd2-4433-842d-8998c64b2068" },
                    { 3, new DateTime(2025, 7, 10, 13, 4, 17, 485, DateTimeKind.Local).AddTicks(85), true, "76506013-fad6-450e-a7b3-8b3cc552f150" },
                    { 4, new DateTime(2025, 7, 10, 16, 4, 17, 485, DateTimeKind.Local).AddTicks(90), false, "e1878767-d27f-47a9-95b8-32e0a1ae70b0" },
                    { 5, new DateTime(2025, 7, 10, 17, 4, 17, 485, DateTimeKind.Local).AddTicks(185), false, "038cde52-06ce-4dd5-99d3-0bb7d1db64c1" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "Email", "Name", "Role" },
                values: new object[,]
                {
                    { 1, "alice@entreprise.com", "Alice Accueil", "Agent d'accueil" },
                    { 2, "bob@entreprise.com", "Bob Collaborateur", "Personnel" },
                    { 3, "charlie@entreprise.com", "Charlie IT", "Administrateur" }
                });

            migrationBuilder.InsertData(
                table: "Visitors",
                columns: new[] { "Id", "ContactStaffId", "Email", "FirstName", "LastName", "Phone", "Status", "VisitReason" },
                values: new object[,]
                {
                    { 1, 1, "alexandre@example.com", "Alexandre", "Lejunior", "0123456789", "Enregistré", "Rendez-vous" },
                    { 2, 2, "elodie@example.com", "Élodie", "Martin", "0987654321", "Enregistré", "Livraison" },
                    { 3, 1, "paul@example.com", "Paul", "Dupont", "0147852369", "Enregistré", "Autre" },
                    { 4, 3, "sophie@example.com", "Sophie", "Durand", "0172638495", "Enregistré", "Rendez-vous" },
                    { 5, 2, "julien@example.com", "Julien", "Moreau", "0192837465", "Enregistré", "Rendez-vous" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "StaffId", "Time", "VisitorId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1 },
                    { 2, new DateTime(2025, 7, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 2, null, 2 },
                    { 3, new DateTime(2025, 7, 11, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 3 },
                    { 4, new DateTime(2025, 7, 12, 16, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 4 },
                    { 5, new DateTime(2025, 7, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "QRCodeTokens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QRCodeTokens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QRCodeTokens",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QRCodeTokens",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QRCodeTokens",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
