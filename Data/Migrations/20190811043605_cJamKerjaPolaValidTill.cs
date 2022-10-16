using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class cJamKerjaPolaValidTill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jum",
                table: "JamKerjaPola");

            migrationBuilder.DropColumn(
                name: "Jumlah",
                table: "JamKerjaPola");

            migrationBuilder.DropColumn(
                name: "Kam",
                table: "JamKerjaPola");

            migrationBuilder.DropColumn(
                name: "KeluarA",
                table: "JamKerjaPola");

            migrationBuilder.DropColumn(
                name: "KeluarB",
                table: "JamKerjaPola");

            migrationBuilder.DropColumn(
                name: "MasukA",
                table: "JamKerjaPola");

            migrationBuilder.DropColumn(
                name: "MasukB",
                table: "JamKerjaPola");

            migrationBuilder.DropColumn(
                name: "Mgg",
                table: "JamKerjaPola");

            migrationBuilder.DropColumn(
                name: "Rab",
                table: "JamKerjaPola");

            migrationBuilder.DropColumn(
                name: "Sab",
                table: "JamKerjaPola");

            migrationBuilder.DropColumn(
                name: "Sel",
                table: "JamKerjaPola");

            migrationBuilder.DropColumn(
                name: "Sen",
                table: "JamKerjaPola");

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTill",
                table: "JamKerjaPola",
                type: "date",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidTill",
                table: "JamKerjaPola");

            migrationBuilder.AddColumn<bool>(
                name: "Jum",
                table: "JamKerjaPola",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Jumlah",
                table: "JamKerjaPola",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Kam",
                table: "JamKerjaPola",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "KeluarA",
                table: "JamKerjaPola",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "KeluarB",
                table: "JamKerjaPola",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "MasukA",
                table: "JamKerjaPola",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "MasukB",
                table: "JamKerjaPola",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "Mgg",
                table: "JamKerjaPola",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Rab",
                table: "JamKerjaPola",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sab",
                table: "JamKerjaPola",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sel",
                table: "JamKerjaPola",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sen",
                table: "JamKerjaPola",
                nullable: false,
                defaultValue: false);
        }
    }
}
