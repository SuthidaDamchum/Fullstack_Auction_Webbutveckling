using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAuctionData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://localhost:7140/10applewatch.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://localhost:7140/2iphone13pro.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://localhost:7140/3GamingPC.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://localhost:7140/4SonyPlayStation5.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://localhost:7140/5ipad.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://localhost:7140/6monitor.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://localhost:7140/7DJIDrone.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://localhost:7140/8MechanicalKeyboard.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://localhost:7140/9NintendoSwitchOLED.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://localhost:7140/10applewatch.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://localhost:7140/macbook.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://localhost:7140/iphone.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://localhost:7140/gaming-pc.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://localhost:7140/ps5.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://localhost:7140/ipad.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://localhost:7140/monitor.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://localhost:7140/drone.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://localhost:7140/keyboard.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://localhost:7140/nintendo.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://localhost:7140/applewatch.jpg");
        }
    }
}
