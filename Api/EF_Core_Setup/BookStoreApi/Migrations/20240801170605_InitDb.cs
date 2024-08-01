using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApi.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_CurrencyTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURRENCY = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CurrencyTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_BookPrices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BOOK_ID = table.Column<int>(type: "int", nullable: false),
                    CURRENCY_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    T_CurrencyTypesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_BookPrices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_T_BookPrices_T_CurrencyTypes_T_CurrencyTypesID",
                        column: x => x.T_CurrencyTypesID,
                        principalTable: "T_CurrencyTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnOfPage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    T_LanguagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Books_T_Languages_T_LanguagesId",
                        column: x => x.T_LanguagesId,
                        principalTable: "T_Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_BookPrices_T_CurrencyTypesID",
                table: "T_BookPrices",
                column: "T_CurrencyTypesID");

            migrationBuilder.CreateIndex(
                name: "IX_T_Books_T_LanguagesId",
                table: "T_Books",
                column: "T_LanguagesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_BookPrices");

            migrationBuilder.DropTable(
                name: "T_Books");

            migrationBuilder.DropTable(
                name: "T_CurrencyTypes");

            migrationBuilder.DropTable(
                name: "T_Languages");
        }
    }
}
