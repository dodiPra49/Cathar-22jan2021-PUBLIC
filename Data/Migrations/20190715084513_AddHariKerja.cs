using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class AddHariKerja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HariKerja_IdLibur",
                table: "HariKerja",
                column: "IdLibur");

            migrationBuilder.AddForeignKey(
                name: "FK_HariKerja_HariKerjaStatus_IdLibur",
                table: "HariKerja",
                column: "IdLibur",
                principalTable: "HariKerjaStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HariKerja_HariKerjaStatus_IdLibur",
                table: "HariKerja");

            migrationBuilder.DropIndex(
                name: "IX_HariKerja_IdLibur",
                table: "HariKerja");
        }
    }
}
