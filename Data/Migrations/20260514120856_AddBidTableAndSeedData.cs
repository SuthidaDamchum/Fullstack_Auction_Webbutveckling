using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBidTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    BidTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "Id", "Amount", "AuctionId", "BidTime", "UserId" },
                values: new object[,]
                {
                    { 1, 1200.00m, 1, new DateTime(2026, 5, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), "2" },
                    { 2, 1500.00m, 1, new DateTime(2026, 5, 10, 14, 30, 0, 0, DateTimeKind.Unspecified), "3" },
                    { 3, 1700.00m, 1, new DateTime(2026, 5, 11, 9, 15, 0, 0, DateTimeKind.Unspecified), "4" },
                    { 4, 2000.00m, 1, new DateTime(2026, 5, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), "5" },
                    { 5, 500.00m, 2, new DateTime(2026, 5, 12, 11, 0, 0, 0, DateTimeKind.Unspecified), "3" },
                    { 6, 650.00m, 2, new DateTime(2026, 5, 12, 13, 45, 0, 0, DateTimeKind.Unspecified), "4" },
                    { 7, 800.00m, 2, new DateTime(2026, 5, 12, 16, 20, 0, 0, DateTimeKind.Unspecified), "2" },
                    { 8, 10000.00m, 3, new DateTime(2026, 5, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), "5" },
                    { 9, 11000.00m, 3, new DateTime(2026, 5, 13, 12, 0, 0, 0, DateTimeKind.Unspecified), "4" },
                    { 10, 12500.00m, 3, new DateTime(2026, 5, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), "3" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsActive", "Name", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { 3, "suthida@hotmail.com", true, "Suthida Damchum", "$2a$12$i5PUbFxSc6N7QH1WAHt1i.1S7RVcafYAWiyG36xG42LnCU917dJP", "user" },
                    { 4, "rasmus@hotmail.com", true, "Rasmus Back", "$2a$12$WQ3NsQgOPjctZwvk/dJu8emIZXV57JWUN0uD.QCYgqsFjneNk7uwG", "user" },
                    { 5, "amanda@hotmail.com", true, "Amanda Park", "$2a$12$MdZbX9THP5GtTJ/7lEJpcOLComityiZK7FejdUWiRCh1QhCmow4v", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
