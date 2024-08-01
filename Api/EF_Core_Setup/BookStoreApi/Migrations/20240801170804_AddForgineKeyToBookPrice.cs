using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApi.Migrations
{
    /// <inheritdoc />
    public partial class AddForgineKeyToBookPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "T_BOOKSId",
                table: "T_BookPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_T_BookPrices_T_BOOKSId",
                table: "T_BookPrices",
                column: "T_BOOKSId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_BookPrices_T_Books_T_BOOKSId",
                table: "T_BookPrices",
                column: "T_BOOKSId",
                principalTable: "T_Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_BookPrices_T_Books_T_BOOKSId",
                table: "T_BookPrices");

            migrationBuilder.DropIndex(
                name: "IX_T_BookPrices_T_BOOKSId",
                table: "T_BookPrices");

            migrationBuilder.DropColumn(
                name: "T_BOOKSId",
                table: "T_BookPrices");
        }
    }
}
