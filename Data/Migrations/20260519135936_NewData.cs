using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class NewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsOpen",
                table: "Auctions",
                newName: "IsActive");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsActive",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bids_AuctionId",
                table: "Bids",
                column: "AuctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Auctions_AuctionId",
                table: "Bids",
                column: "AuctionId",
                principalTable: "Auctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Auctions_AuctionId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_AuctionId",
                table: "Bids");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Auctions",
                newName: "IsOpen");

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsOpen",
                value: false);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsOpen",
                value: false);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsOpen",
                value: false);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsOpen",
                value: false);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsOpen",
                value: false);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsOpen",
                value: false);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsOpen",
                value: false);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsOpen",
                value: false);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsOpen",
                value: false);

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsOpen",
                value: false);
        }
    }
}
