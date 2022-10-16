using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class UnitKerjaAddValidTill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTill",
                table: "UnitKerja",
                type: "date",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidTill",
                table: "UnitKerja");
        }
    }
}
