using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "https://localhost:7140/1MacBookPro2020.jpg", 3000m });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 2500m);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 2800m);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 400m);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 2600m);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 2000m);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 3500m);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 300m);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: 1500m);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Price",
                value: 2400m);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Amount", "UserId" },
                values: new object[] { 3250.00m, 3 });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "UserId" },
                values: new object[] { 3500.00m, 4 });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amount", "UserId" },
                values: new object[] { 3750.00m, 5 });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Amount", "UserId" },
                values: new object[] { 4000.00m, 3 });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Amount", "UserId" },
                values: new object[] { 2750.00m, 4 });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Amount", "UserId" },
                values: new object[] { 3000.00m, 5 });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Amount", "UserId" },
                values: new object[] { 3250.00m, 3 });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 8,
                column: "Amount",
                value: 3050.00m);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 9,
                column: "Amount",
                value: 3300.00m);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 10,
                column: "Amount",
                value: 3550.00m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$12$u3jUPddEgQPVoJATUd2VxOJGzzaO89p2eDB1Xe4x1umW4ceTEmkfK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "https://localhost:7140/10applewatch.jpg", 8000m });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 5000m);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 15000m);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 6000m);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 9000m);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 4000m);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 7000m);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 1500m);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: 3500m);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Price",
                value: 4500m);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Amount", "UserId" },
                values: new object[] { 1200.00m, 2 });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "UserId" },
                values: new object[] { 1500.00m, 3 });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amount", "UserId" },
                values: new object[] { 1700.00m, 4 });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Amount", "UserId" },
                values: new object[] { 2000.00m, 5 });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Amount", "UserId" },
                values: new object[] { 500.00m, 3 });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Amount", "UserId" },
                values: new object[] { 650.00m, 4 });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Amount", "UserId" },
                values: new object[] { 800.00m, 2 });

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 8,
                column: "Amount",
                value: 10000.00m);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 9,
                column: "Amount",
                value: 11000.00m);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 10,
                column: "Amount",
                value: 12500.00m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$12$i5PUbFxSc6N7QH1WAHt1i.1S7RVcafYAWiyG36xG42LnCU917dJP");
        }
    }
}
