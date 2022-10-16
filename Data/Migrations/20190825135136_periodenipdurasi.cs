using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class periodenipdurasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurasiAAL",
                table: "PeriodeNIP",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DurasiAL",
                table: "PeriodeNIP",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DurasiCatHar",
                table: "PeriodeNIP",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DurasiYbs",
                table: "PeriodeNIP",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurasiAAL",
                table: "PeriodeNIP");

            migrationBuilder.DropColumn(
                name: "DurasiAL",
                table: "PeriodeNIP");

            migrationBuilder.DropColumn(
                name: "DurasiCatHar",
                table: "PeriodeNIP");

            migrationBuilder.DropColumn(
                name: "DurasiYbs",
                table: "PeriodeNIP");
        }
    }
}
