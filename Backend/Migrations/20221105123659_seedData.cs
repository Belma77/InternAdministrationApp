using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CoverLetter", "EducationLevel", "Email", "FirstName", "LastName", "Status" },
                values: new object[,]
                {
                    { 1, "", 0, "test@hotmail.com", "test", "test", 0 },
                    { 2, "", 0, "test2@hotmail.com", "test2", "test2", 0 },
                    { 3, "", 0, "test3@hotmail.com", "test3", "test3", 0 }
                });

            migrationBuilder.InsertData(
                table: "Selections",
                columns: new[] { "Id", "Description", "EndDate", "Name", "StartDate" },
                values: new object[] { 1, "desc", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "internship", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Selections",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
