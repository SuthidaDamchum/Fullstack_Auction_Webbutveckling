using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class NewAuctionSeedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://localhost:7140/1MacBook.png");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://localhost:7140/2iphone.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "https://localhost:7140/4playstation5.png", 5000m });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://localhost:7140/5Ipad.png");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://localhost:7140/6sumsung.png");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://localhost:7140/7.png");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://localhost:7140/9.png");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://localhost:7140/10jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$12$M71HKUQxR3DzFHv57qraSeOrkOXyUbb9QKIbQur.uLRGEpoyhC6NG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$12$nra4y5TWIclit4uNxe4kB.Cc69sjhrs9M9Xm5QHIiuktsn0KdXwsa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$12$7MDFLndGn.n2BiDRw7W3Kem1DAztZUNgpmSbK1zOmyHk7h0VDarBS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://localhost:7140/1MacBookPro2020.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://localhost:7140/2iphone13pro.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "https://localhost:7140/4SonyPlayStation5.jpg", 400m });

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
                keyValue: 9,
                column: "ImageUrl",
                value: "https://localhost:7140/9NintendoSwitchOLED.jpg");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://localhost:7140/10applewatch.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$12$u3jUPddEgQPVoJATUd2VxOJGzzaO89p2eDB1Xe4x1umW4ceTEmkfK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$12$WQ3NsQgOPjctZwvk/dJu8emIZXV57JWUN0uD.QCYgqsFjneNk7uwG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$12$MdZbX9THP5GtTJ/7lEJpcOLComityiZK7FejdUWiRCh1QhCmow4v");
        }
    }
}
