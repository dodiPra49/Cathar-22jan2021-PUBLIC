using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class JamKerjaPolaAddSeninSDMinggu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Jum",
                table: "JamKerjaPola",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Kam",
                table: "JamKerjaPola",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Mgg",
                table: "JamKerjaPola",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rab",
                table: "JamKerjaPola",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sab",
                table: "JamKerjaPola",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sel",
                table: "JamKerjaPola",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sen",
                table: "JamKerjaPola",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jum",
                table: "JamKerjaPola");

            migrationBuilder.DropColumn(
                name: "Kam",
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
        }
    }
}
