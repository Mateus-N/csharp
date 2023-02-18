using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApi.Migrations
{
    /// <inheritdoc />
    public partial class Criandoroleregular : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, null, "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fd040f5-2d17-4ed1-ba53-e3938e540f34", "AQAAAAIAAYagAAAAEEHepHDHTyw4v2kHTeXS4diKV/k1P9Xm7XQkthTKiG3YKxCV3mtHv210GVn5fEew2w==", "7e261ca4-924c-4232-b0ba-21451367a078" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b935410-7b8a-4dea-b619-3515c6c4e619", "AQAAAAIAAYagAAAAEKHVbvXyfZgBqKJ+l0RcejSYa9DglWBByfX88G25bCqYF8i041iqDBwlmz3cfRQxLw==", "9aa444fc-fa7a-4cf3-b462-29689ed7738f" });
        }
    }
}
