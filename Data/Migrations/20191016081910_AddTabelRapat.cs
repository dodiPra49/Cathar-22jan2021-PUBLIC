using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class AddTabelRapat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rapat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdPeriode = table.Column<string>(maxLength: 7, nullable: false),
                    Tanggal = table.Column<DateTime>(type: "date", nullable: false),
                    WaktuMulai = table.Column<TimeSpan>(nullable: false),
                    WaktuHingga = table.Column<TimeSpan>(nullable: false),
                    Aktifitas = table.Column<string>(nullable: false),
                    Tempat = table.Column<string>(nullable: false),
                    Hasil = table.Column<string>(nullable: false),
                    IdUnitKerja = table.Column<int>(nullable: false),
                    Level = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rapat", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rapat");
        }
    }
}
