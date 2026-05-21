using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bids",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bids",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: "5");

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: "5");

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: "3");
        }
    }
}
