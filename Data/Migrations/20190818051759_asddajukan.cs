using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class asddajukan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Ajukan1",
                table: "PeriodeNIP",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Ajukan2",
                table: "PeriodeNIP",
                type: "date",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ajukan1",
                table: "PeriodeNIP");

            migrationBuilder.DropColumn(
                name: "Ajukan2",
                table: "PeriodeNIP");
        }
    }
}
