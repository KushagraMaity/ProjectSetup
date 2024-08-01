using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApi.Migrations
{
    /// <inheritdoc />
    public partial class addDataToCurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CURRENCY",
                table: "T_CurrencyTypes");

            migrationBuilder.AddColumn<string>(
                name: "TITLE",
                table: "T_CurrencyTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TITLE",
                table: "T_CurrencyTypes");

            migrationBuilder.AddColumn<int>(
                name: "CURRENCY",
                table: "T_CurrencyTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
