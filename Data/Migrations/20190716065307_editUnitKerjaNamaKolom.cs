using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class editUnitKerjaNamaKolom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitKerja",
                table: "UnitKerja",
                newName: "Uraian");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
