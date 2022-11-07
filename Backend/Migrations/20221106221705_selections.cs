using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class selections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Selections",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "internship/1");

            migrationBuilder.InsertData(
                table: "Selections",
                columns: new[] { "Id", "Description", "EndDate", "Name", "StartDate" },
                values: new object[] { 2, "desc2", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "internship/2", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Selections",
                columns: new[] { "Id", "Description", "EndDate", "Name", "StartDate" },
                values: new object[] { 3, "desc3", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "internship/3", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Selections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Selections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Selections",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "internship");
        }
    }
}
