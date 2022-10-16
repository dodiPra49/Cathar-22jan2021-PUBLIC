using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class JabatanAddValidTill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTill",
                table: "Jabatan",
                type: "date",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidTill",
                table: "Jabatan");
        }
    }
}
