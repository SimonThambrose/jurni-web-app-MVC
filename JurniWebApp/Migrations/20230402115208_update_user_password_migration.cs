using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JurniWebApp.Migrations
{
    public partial class update_user_password_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "longblob",
                nullable: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "longblob",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 4, 2, 13, 52, 8, 773, DateTimeKind.Local).AddTicks(47), new byte[] { 201, 184, 127, 71, 192, 49, 79, 239, 1, 124, 164, 227, 92, 2, 235, 140, 207, 203, 106, 116, 212, 229, 110, 215, 114, 239, 209, 151, 51, 2, 211, 250, 88, 25, 67, 83, 116, 49, 241, 207, 189, 75, 253, 171, 98, 111, 29, 71, 139, 25, 86, 39, 72, 17, 225, 110, 28, 7, 236, 46, 45, 110, 161, 66 }, new byte[] { 243, 103, 39, 63, 188, 72, 155, 235, 201, 226, 63, 215, 113, 96, 251, 86, 116, 229, 129, 211, 112, 239, 172, 145, 201, 204, 172, 213, 2, 28, 94, 78, 47, 102, 232, 231, 156, 13, 78, 208, 150, 63, 62, 211, 107, 29, 16, 101, 207, 32, 93, 112, 181, 122, 42, 85, 129, 79, 220, 249, 37, 245, 130, 242, 24, 83, 238, 178, 190, 100, 21, 92, 141, 220, 92, 110, 213, 123, 140, 82, 76, 22, 188, 10, 41, 146, 22, 249, 154, 59, 29, 173, 48, 249, 102, 214, 255, 107, 149, 67, 232, 56, 113, 30, 201, 143, 244, 56, 120, 215, 185, 51, 139, 120, 88, 33, 209, 190, 20, 20, 109, 143, 156, 158, 166, 143, 14, 248 }, new DateTime(2023, 4, 2, 13, 52, 8, 773, DateTimeKind.Local).AddTicks(85) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "varchar(90)",
                maxLength: 90,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 3, 30, 13, 7, 59, 711, DateTimeKind.Local).AddTicks(2942), "8F670A39A63922B54541CBFFF2C6ECBF", new DateTime(2023, 3, 30, 13, 7, 59, 711, DateTimeKind.Local).AddTicks(2948) });
        }
    }
}
