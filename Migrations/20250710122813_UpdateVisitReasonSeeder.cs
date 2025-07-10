using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reservation_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVisitReasonSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 2,
                column: "VisitReason",
                value: "Coworking");

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 3,
                column: "VisitReason",
                value: "Coworking");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 2,
                column: "VisitReason",
                value: "Livraison");

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 3,
                column: "VisitReason",
                value: "Autre");
        }
    }
}
