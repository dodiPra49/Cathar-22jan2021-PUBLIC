using Microsoft.EntityFrameworkCore.Migrations;

namespace New.Data.Migrations
{
    public partial class spDurasiCatHar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[spDurasiCatHar]
                        @IDPERIODE AS VARCHAR(7),
	                    @NIP AS VARCHAR(18)
                    AS
                    BEGIN
                        --SET NOCOUNT ON added to prevent extra result sets from
                        -- interfering with SELECT statements.
                        SET NOCOUNT ON;
                        --Insert statements for procedure here
                        SELECT
                            COUNT(*) N, SUM(DATEDIFF(minute, WAKTUMULAI, WaktuHingga)) Durasi
                            FROM DIARY
                            WHERE IDPERIODE = @IDPERIODE AND NIP = @NIP
                    END";

            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
