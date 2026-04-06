using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace customer_wellness_project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    MinimumThreshold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "MinimumThreshold", "Name", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "Medication", 10, "Insulin Humalog", 2 },
                    { 2, "Diagnostics", 50, "Nitrate Strips", 12 },
                    { 3, "PPE", 20, "Surgical Masks", 4 },
                    { 4, "PPE", 50, "Nitrile Gloves", 150 },
                    { 5, "Medication", 15, "Saline Solution", 8 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CreatedAt", "Description", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), "Lab results for Patient #8829 failed to upload to portal", "Resolved", "Lab results upload failure" },
                    { 2, new DateTime(2026, 3, 30, 14, 0, 0, 0, DateTimeKind.Unspecified), "Ventilator unit #3 requires scheduled maintenance", "Urgent", "Emergency room equipment maintenance" },
                    { 3, new DateTime(2026, 3, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), "Physical count doesn't match system for insulin stock", "Open", "Pharmacy inventory discrepancy" },
                    { 4, new DateTime(2026, 3, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), "Multiple patients reporting login failures on mobile", "Open", "Patient portal access issue" },
                    { 5, new DateTime(2026, 3, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), "Ward B monitors showing inconsistent readings", "Open", "Blood pressure monitor calibration" },
                    { 6, new DateTime(2026, 3, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), "Room 204 call button unresponsive", "Urgent", "Nurse call system malfunction" },
                    { 7, new DateTime(2026, 3, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), "Electronic health records taking >10s to load", "Open", "EHR system slow response" },
                    { 8, new DateTime(2026, 3, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), "Autoclave unit showing E-04 error code", "Open", "Sterilization unit error" },
                    { 9, new DateTime(2026, 3, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), "Only 2 wheelchairs available for 12-bed ward", "Open", "Wheelchair shortage Ward C" },
                    { 10, new DateTime(2026, 3, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), "Lab refrigerator temp drifting above safe range", "Urgent", "Temperature control Lab 3" },
                    { 11, new DateTime(2026, 3, 29, 16, 0, 0, 0, DateTimeKind.Unspecified), "Double booking for night shift radiology", "Open", "Shift scheduling conflict" },
                    { 12, new DateTime(2026, 3, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), "Ventilation fan noise in MRI suite", "Open", "MRI room ventilation" },
                    { 13, new DateTime(2026, 3, 29, 11, 0, 0, 0, DateTimeKind.Unspecified), "Batch of amoxicillin expiring within 30 days", "Open", "Medication expiry alert" },
                    { 14, new DateTime(2026, 3, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), "Ward A nursing station printer not responding", "Open", "Network printer offline" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
