using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class AddJoinPeriodeNipToJamKerjaPola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PeriodeNIP_IdJamKerjaPola",
                table: "PeriodeNIP",
                column: "IdJamKerjaPola");

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodeNIP_JamKerjaPola_IdJamKerjaPola",
                table: "PeriodeNIP",
                column: "IdJamKerjaPola",
                principalTable: "JamKerjaPola",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeriodeNIP_JamKerjaPola_IdJamKerjaPola",
                table: "PeriodeNIP");

            migrationBuilder.DropIndex(
                name: "IX_PeriodeNIP_IdJamKerjaPola",
                table: "PeriodeNIP");
        }
    }
}
