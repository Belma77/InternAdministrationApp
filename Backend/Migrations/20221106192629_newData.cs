using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class newData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CoverLetter", "EducationLevel", "Email", "FirstName", "LastName", "Status" },
                values: new object[] { 4, "", 2, "novi@hotmail.com", "novi", "prezime", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CoverLetter", "EducationLevel", "Email", "FirstName", "LastName", "Status" },
                values: new object[] { 2, "", 0, "test2@hotmail.com", "test2", "test2", 0 });
        }
    }
}
