using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class addJamKerjaPolaDt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JamKerjaPolaDt",
                columns: table => new
                {
                    IdPola = table.Column<int>(nullable: false),
                    IdDow = table.Column<int>(nullable: false),
                    MasukA = table.Column<TimeSpan>(nullable: true),
                    KeluarA = table.Column<TimeSpan>(nullable: false),
                    MasukB = table.Column<TimeSpan>(nullable: false),
                    KeluarB = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JamPolaDt", x => new { x.IdPola, x.IdDow });
                    table.ForeignKey(
                        name: "FK_JamKerjaPolaDt_JamKerjaPola",
                        column: x => x.IdPola,
                        principalTable: "JamKerjaPola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JamKerjaPolaDt");
        }
    }
}
