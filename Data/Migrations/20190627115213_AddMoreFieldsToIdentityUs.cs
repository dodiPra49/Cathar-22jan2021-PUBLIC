using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class AddMoreFieldsToIdentityUs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Alamat",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KabKota",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provinsi",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telpon",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HariKerja",
                columns: table => new
                {
                    Tanggal = table.Column<DateTime>(type: "date", nullable: false),
                    IdLibur = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HariKerja", x => x.Tanggal);
                });

            migrationBuilder.CreateTable(
                name: "HariKerjaStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Uraian = table.Column<string>(unicode: false, maxLength: 254, nullable: false),
                    Libur = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HariKerjaStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JamKerjaPola",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Uraian = table.Column<string>(unicode: false, maxLength: 254, nullable: false),
                    MasukA = table.Column<TimeSpan>(nullable: true),
                    KeluarA = table.Column<TimeSpan>(nullable: false),
                    MasukB = table.Column<TimeSpan>(nullable: false),
                    KeluarB = table.Column<TimeSpan>(nullable: false),
                    Jumlah = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JamKerjaPola", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pegawai",
                columns: table => new
                {
                    NIP = table.Column<string>(unicode: false, maxLength: 18, nullable: false),
                    Nama = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    GelarDepan = table.Column<string>(unicode: false, maxLength: 8, nullable: true),
                    GelarBelakang = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    TempatLahir = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    TgLLahir = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pegawai", x => x.NIP);
                });

            migrationBuilder.CreateTable(
                name: "Periode",
                columns: table => new
                {
                    Id = table.Column<string>(unicode: false, maxLength: 7, nullable: false),
                    Tahun = table.Column<int>(nullable: true),
                    Bulan = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitKerja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    UnitKerja = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    IdLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitKerja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jabatan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IdUnitKerja = table.Column<int>(nullable: false),
                    Uraian = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    IdEselon = table.Column<int>(nullable: false),
                    Urut = table.Column<int>(nullable: false),
                    IdJabatan = table.Column<int>(nullable: false),
                    IdAtas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jabatan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jabatan_UnitKerja",
                        column: x => x.IdUnitKerja,
                        principalTable: "UnitKerja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PeriodeKaSKPD",
                columns: table => new
                {
                    IdPeriode = table.Column<string>(unicode: false, maxLength: 7, nullable: false),
                    IdUnitKerja = table.Column<int>(nullable: false),
                    IdJabatan = table.Column<int>(nullable: false),
                    IdKaSKPD = table.Column<string>(unicode: false, maxLength: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodeKaSKPD", x => new { x.IdPeriode, x.IdUnitKerja });
                    table.ForeignKey(
                        name: "FK_PeriodeKaSKPD_Jabatan",
                        column: x => x.IdJabatan,
                        principalTable: "Jabatan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodeKaSKPD_Pegawai",
                        column: x => x.IdKaSKPD,
                        principalTable: "Pegawai",
                        principalColumn: "NIP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PeriodeNIP",
                columns: table => new
                {
                    IdPeriode = table.Column<string>(unicode: false, maxLength: 7, nullable: false),
                    Nip = table.Column<string>(unicode: false, maxLength: 18, nullable: false),
                    IdUnitKerja = table.Column<int>(nullable: false),
                    IdJabatan = table.Column<int>(nullable: false),
                    NipAtas1 = table.Column<string>(unicode: false, maxLength: 18, nullable: false),
                    NipAtas2 = table.Column<string>(unicode: false, maxLength: 18, nullable: false),
                    IdJabatanAtas1 = table.Column<int>(nullable: false),
                    IdJabatanAtas2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodeNIP", x => new { x.IdPeriode, x.Nip });
                    table.ForeignKey(
                        name: "FK_PeriodeNIP_Jabatan",
                        column: x => x.IdJabatan,
                        principalTable: "Jabatan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodeNIP_Jabatan1",
                        column: x => x.IdJabatanAtas1,
                        principalTable: "Jabatan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodeNIP_Jabatan2",
                        column: x => x.IdJabatanAtas2,
                        principalTable: "Jabatan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodeNIP_Periode",
                        column: x => x.IdPeriode,
                        principalTable: "Periode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodeNIP_UnitKerja",
                        column: x => x.IdUnitKerja,
                        principalTable: "UnitKerja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodeNIP_Pegawai",
                        column: x => x.Nip,
                        principalTable: "Pegawai",
                        principalColumn: "NIP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodeNIP_Pegawai1",
                        column: x => x.NipAtas1,
                        principalTable: "Pegawai",
                        principalColumn: "NIP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodeNIP_Pegawai2",
                        column: x => x.NipAtas2,
                        principalTable: "Pegawai",
                        principalColumn: "NIP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodeNIP_PeriodeKaSKPD",
                        columns: x => new { x.IdPeriode, x.IdUnitKerja },
                        principalTable: "PeriodeKaSKPD",
                        principalColumns: new[] { "IdPeriode", "IdUnitKerja" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IdPeriode = table.Column<string>(unicode: false, maxLength: 7, nullable: false),
                    Nip = table.Column<string>(unicode: false, maxLength: 18, nullable: false),
                    Tanggal = table.Column<DateTime>(type: "date", nullable: false),
                    WaktuMulai = table.Column<TimeSpan>(nullable: false),
                    WaktuHingga = table.Column<TimeSpan>(nullable: false),
                    Aktifitas = table.Column<string>(unicode: false, maxLength: 254, nullable: false),
                    Tempat = table.Column<string>(unicode: false, maxLength: 254, nullable: false),
                    Hasil = table.Column<string>(unicode: false, maxLength: 254, nullable: false),
                    WaktuSetuju1 = table.Column<int>(nullable: false),
                    WaktuSetuju2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diary_PeriodeNIP",
                        columns: x => new { x.IdPeriode, x.Nip },
                        principalTable: "PeriodeNIP",
                        principalColumns: new[] { "IdPeriode", "Nip" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HariKerjaNip",
                columns: table => new
                {
                    IdPeriode = table.Column<string>(unicode: false, maxLength: 7, nullable: false),
                    NIP = table.Column<string>(unicode: false, maxLength: 18, nullable: false),
                    Tanggal = table.Column<DateTime>(type: "date", nullable: false),
                    IdHariKerjaStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HariKerjaNip", x => new { x.IdPeriode, x.NIP, x.Tanggal });
                    table.ForeignKey(
                        name: "FK_HariKerjaNip_HariKerjaStatus",
                        column: x => x.IdHariKerjaStatus,
                        principalTable: "HariKerjaStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HariKerjaNip_PeriodeNIP",
                        columns: x => new { x.IdPeriode, x.NIP },
                        principalTable: "PeriodeNIP",
                        principalColumns: new[] { "IdPeriode", "Nip" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diary_IdPeriode_Nip",
                table: "Diary",
                columns: new[] { "IdPeriode", "Nip" });

            migrationBuilder.CreateIndex(
                name: "IX_HariKerjaNip_IdHariKerjaStatus",
                table: "HariKerjaNip",
                column: "IdHariKerjaStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Jabatan_IdUnitKerja",
                table: "Jabatan",
                column: "IdUnitKerja");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodeKaSKPD_IdJabatan",
                table: "PeriodeKaSKPD",
                column: "IdJabatan");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodeKaSKPD_IdKaSKPD",
                table: "PeriodeKaSKPD",
                column: "IdKaSKPD");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodeNIP_IdJabatan",
                table: "PeriodeNIP",
                column: "IdJabatan");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodeNIP_IdJabatanAtas1",
                table: "PeriodeNIP",
                column: "IdJabatanAtas1");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodeNIP_IdJabatanAtas2",
                table: "PeriodeNIP",
                column: "IdJabatanAtas2");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodeNIP_IdUnitKerja",
                table: "PeriodeNIP",
                column: "IdUnitKerja");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodeNIP_Nip",
                table: "PeriodeNIP",
                column: "Nip");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodeNIP_NipAtas1",
                table: "PeriodeNIP",
                column: "NipAtas1");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodeNIP_NipAtas2",
                table: "PeriodeNIP",
                column: "NipAtas2");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodeNIP_IdPeriode_IdUnitKerja",
                table: "PeriodeNIP",
                columns: new[] { "IdPeriode", "IdUnitKerja" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diary");

            migrationBuilder.DropTable(
                name: "HariKerja");

            migrationBuilder.DropTable(
                name: "HariKerjaNip");

            migrationBuilder.DropTable(
                name: "JamKerjaPola");

            migrationBuilder.DropTable(
                name: "HariKerjaStatus");

            migrationBuilder.DropTable(
                name: "PeriodeNIP");

            migrationBuilder.DropTable(
                name: "Periode");

            migrationBuilder.DropTable(
                name: "PeriodeKaSKPD");

            migrationBuilder.DropTable(
                name: "Jabatan");

            migrationBuilder.DropTable(
                name: "Pegawai");

            migrationBuilder.DropTable(
                name: "UnitKerja");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Alamat",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KabKota",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Provinsi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telpon",
                table: "AspNetUsers");
        }
    }
}
