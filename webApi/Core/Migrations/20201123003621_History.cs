using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class History : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Action",
                table: "History",
                newName: "PostID");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2020, 11, 22, 21, 36, 20, 691, DateTimeKind.Local).AddTicks(5079));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "History",
                newName: "Action");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2020, 11, 21, 20, 10, 16, 365, DateTimeKind.Local).AddTicks(4326));
        }
    }
}
