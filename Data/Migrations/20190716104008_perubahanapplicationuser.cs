using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class perubahanapplicationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "UnitKerja",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UnitKerja",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(short),
                oldNullable: true);
        }
    }
}
