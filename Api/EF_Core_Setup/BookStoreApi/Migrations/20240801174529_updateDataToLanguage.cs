using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApi.Migrations
{
    /// <inheritdoc />
    public partial class updateDataToLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Books_T_Languages_T_LanguagesId",
                table: "T_Books");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "T_Languages",
                newName: "TITLE");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "T_Languages",
                newName: "DESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "T_Languages",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "T_LanguagesId",
                table: "T_Books",
                newName: "T_LanguagesID");

            migrationBuilder.RenameIndex(
                name: "IX_T_Books_T_LanguagesId",
                table: "T_Books",
                newName: "IX_T_Books_T_LanguagesID");

            migrationBuilder.InsertData(
                table: "T_Languages",
                columns: new[] { "ID", "DESCRIPTION", "TITLE" },
                values: new object[,]
                {
                    { 1, "Hindi", "Hindi" },
                    { 2, "Tamil", "Tamil" },
                    { 3, "Panjabi", "Panjabi" },
                    { 4, "Urdu", "Urdu" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_T_Books_T_Languages_T_LanguagesID",
                table: "T_Books",
                column: "T_LanguagesID",
                principalTable: "T_Languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Books_T_Languages_T_LanguagesID",
                table: "T_Books");

            migrationBuilder.DeleteData(
                table: "T_Languages",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "T_Languages",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "T_Languages",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "T_Languages",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "TITLE",
                table: "T_Languages",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "DESCRIPTION",
                table: "T_Languages",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "T_Languages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "T_LanguagesID",
                table: "T_Books",
                newName: "T_LanguagesId");

            migrationBuilder.RenameIndex(
                name: "IX_T_Books_T_LanguagesID",
                table: "T_Books",
                newName: "IX_T_Books_T_LanguagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Books_T_Languages_T_LanguagesId",
                table: "T_Books",
                column: "T_LanguagesId",
                principalTable: "T_Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
