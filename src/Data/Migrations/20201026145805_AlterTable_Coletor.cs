using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AlterTable_Coletor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UtilizaCC",
                table: "Coletor",
                newName: "Utiliza_CC");

            migrationBuilder.RenameColumn(
                name: "LastSincCC",
                table: "Coletor",
                newName: "Last_Sinc_CC");

            migrationBuilder.RenameColumn(
                name: "LastFichaCC",
                table: "Coletor",
                newName: "Last_Ficha_CC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Utiliza_CC",
                table: "Coletor",
                newName: "UtilizaCC");

            migrationBuilder.RenameColumn(
                name: "Last_Sinc_CC",
                table: "Coletor",
                newName: "LastSincCC");

            migrationBuilder.RenameColumn(
                name: "Last_Ficha_CC",
                table: "Coletor",
                newName: "LastFichaCC");
        }
    }
}
