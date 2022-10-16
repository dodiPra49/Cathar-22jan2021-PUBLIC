using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class AddParaGantiSD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "MasukA",
                table: "JamKerjaPolaDt",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdPeriode",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Tanggal",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPeriode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Tanggal",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "MasukA",
                table: "JamKerjaPolaDt",
                nullable: true,
                oldClrType: typeof(TimeSpan));
        }
    }
}
