using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Comments",
                newName: "comment");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d375e520-05dc-45a8-9872-c98047e1c580", "AQAAAAEAACcQAAAAEPrEvCd1QsHiIuNSqIrymfHO7ioGYhSwApMBXghwAGFi03y+uTIlcYgtQZvRgL+FkA==", "bf32fff7-ea46-4d0d-b2d5-3b7140b3a235" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "comment",
                table: "Comments",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f5628ae-eee1-47be-a2cb-ad0606df5893", "AQAAAAEAACcQAAAAEPifz10Zpw3hZKc2w5u0E50cNBXeewpcCtX5ugBYo4jt2nRkeuhhmFg8v3I45NT/cw==", "c5fdc2ac-abe6-4021-aa78-a8f3fd4de995" });
        }
    }
}
