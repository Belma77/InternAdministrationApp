using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb4b9080-d87d-4945-8aad-17aed65afd39", "AQAAAAEAACcQAAAAEPQLRh0Vo5Ug8oL5bCeOAOat8iHFHAgQiERq1ovEWTYGv32MagfCQzODZ9fVk/X6rA==", "1df3c2a4-9de7-4157-9d61-aba7121ccbf1" });

            migrationBuilder.UpdateData(
                table: "Selections",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Name", "StartDate" },
                values: new object[] { new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "JAP Development", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Selections",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "JAP QA");

            migrationBuilder.UpdateData(
                table: "Selections",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "Name", "StartDate" },
                values: new object[] { new DateTime(2022, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "JAP Devops", new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cde6deb-055a-4f0a-8a6f-90c353c23983", "AQAAAAEAACcQAAAAEBeCjb7KDsW1O8OjgBVff81dFxon6oXwhdUVOeIdKtOBLL0c523xZ5P8w1pcMR97Tg==", "11a183ae-31bb-4b30-ab18-05913fcddd94" });

            migrationBuilder.UpdateData(
                table: "Selections",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Name", "StartDate" },
                values: new object[] { new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "internship/1", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Selections",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "internship/2");

            migrationBuilder.UpdateData(
                table: "Selections",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "Name", "StartDate" },
                values: new object[] { new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "internship/3", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
