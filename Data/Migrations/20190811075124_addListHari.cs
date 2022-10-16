using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class addListHari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListHari",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Uraian = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListHari", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JamKerjaPolaDt_IdDow",
                table: "JamKerjaPolaDt",
                column: "IdDow");

            migrationBuilder.AddForeignKey(
                name: "FK_JamKerjaPolaDt_ListHari",
                table: "JamKerjaPolaDt",
                column: "IdDow",
                principalTable: "ListHari",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JamKerjaPolaDt_ListHari",
                table: "JamKerjaPolaDt");

            migrationBuilder.DropTable(
                name: "ListHari");

            migrationBuilder.DropIndex(
                name: "IX_JamKerjaPolaDt_IdDow",
                table: "JamKerjaPolaDt");
        }
    }
}
