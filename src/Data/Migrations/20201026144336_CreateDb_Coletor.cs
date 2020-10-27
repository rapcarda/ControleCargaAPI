using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CreateDb_Coletor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Codigo",
                table: "Usuario",
                type: "numeric(5)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoBarra",
                table: "ClienteProduto",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Coletor",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<decimal>(type: "numeric(3)", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(250)", nullable: true),
                    Imei = table.Column<string>(type: "varchar(25)", nullable: false),
                    Status = table.Column<decimal>(type: "numeric(1)", nullable: false),
                    UtilizaCC = table.Column<decimal>(type: "numeric(1)", nullable: false),
                    LastFichaCC = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastSincCC = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coletor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coletor");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoBarra",
                table: "ClienteProduto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");
        }
    }
}
