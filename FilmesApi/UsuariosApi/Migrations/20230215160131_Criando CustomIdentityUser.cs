using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApi.Migrations
{
    /// <inheritdoc />
    public partial class CriandoCustomIdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "DataNascimento", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36e95d9b-5d05-4c70-93f2-fb11185e1251", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAEEfAnCaNRiM8LmyAAx0pzH1wAtCmq7EsZ+OTtZgR/HdFZ1721h12qHQfRvHPZi1vYQ==", "19ed77e3-0761-452b-9769-7066881195e1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fd040f5-2d17-4ed1-ba53-e3938e540f34", "AQAAAAIAAYagAAAAEEHepHDHTyw4v2kHTeXS4diKV/k1P9Xm7XQkthTKiG3YKxCV3mtHv210GVn5fEew2w==", "7e261ca4-924c-4232-b0ba-21451367a078" });
        }
    }
}
