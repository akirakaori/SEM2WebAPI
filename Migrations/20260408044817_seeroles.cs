using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SEM2WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class seeroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bd965c0-4f07-46de-b4ab-9a672045834a", "36ed5fbc-7faa-4de7-b639-8bb4021fb855", "Instructor", "Instructor" },
                    { "3f3319aa-44f1-45a2-9c45-065864e1dd75", "aca4779f-9168-46d3-bfd6-205cd0162ed1", "Student", "Student" },
                    { "410ffe09-548f-4c00-830b-f234a2b9e0e4", "a4cbcdc3-2cb6-4569-b1cf-d301a63cd490", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1bd965c0-4f07-46de-b4ab-9a672045834a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3f3319aa-44f1-45a2-9c45-065864e1dd75");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "410ffe09-548f-4c00-830b-f234a2b9e0e4");
        }
    }
}
