using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class DiaryMaxLengNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WaktuSetuju2",
                table: "Diary",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "WaktuSetuju1",
                table: "Diary",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Tempat",
                table: "Diary",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 254);

            migrationBuilder.AlterColumn<string>(
                name: "Hasil",
                table: "Diary",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 254);

            migrationBuilder.AlterColumn<string>(
                name: "Aktifitas",
                table: "Diary",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 254);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WaktuSetuju2",
                table: "Diary",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WaktuSetuju1",
                table: "Diary",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tempat",
                table: "Diary",
                unicode: false,
                maxLength: 254,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "Hasil",
                table: "Diary",
                unicode: false,
                maxLength: 254,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "Aktifitas",
                table: "Diary",
                unicode: false,
                maxLength: 254,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false);
        }
    }
}
