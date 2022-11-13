using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Applications_ApplicationId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Selections_SelectionId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "SelectionId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c835cfc-305e-4c95-ac84-c9651c8925e5", "AQAAAAEAACcQAAAAEPHtfp63G4I7NTBTcKh6JzB/m/tuPpjJYEwQTjnXz0lDknsbiw4kpCu8xw9aUCakpw==", "0b48bf0f-6c10-4e79-a562-0cf2a802c3fe" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Applications_ApplicationId",
                table: "Comments",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Selections_SelectionId",
                table: "Comments",
                column: "SelectionId",
                principalTable: "Selections",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Applications_ApplicationId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Selections_SelectionId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "SelectionId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d375e520-05dc-45a8-9872-c98047e1c580", "AQAAAAEAACcQAAAAEPrEvCd1QsHiIuNSqIrymfHO7ioGYhSwApMBXghwAGFi03y+uTIlcYgtQZvRgL+FkA==", "bf32fff7-ea46-4d0d-b2d5-3b7140b3a235" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Applications_ApplicationId",
                table: "Comments",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Selections_SelectionId",
                table: "Comments",
                column: "SelectionId",
                principalTable: "Selections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
