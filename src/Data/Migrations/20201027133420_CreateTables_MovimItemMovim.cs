using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CreateTables_MovimItemMovim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movimento",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColetorId = table.Column<long>(nullable: false),
                    UsuarioId = table.Column<long>(nullable: false),
                    FrotaId = table.Column<long>(nullable: false),
                    Coletor_Chave = table.Column<string>(type: "varchar(20)", nullable: true),
                    Coletor_App = table.Column<string>(type: "varchar(15)", nullable: true),
                    Coletor_Doc = table.Column<decimal>(type: "numeric", nullable: false),
                    Data_Hora_Gravacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Data_Hora_Inicial = table.Column<DateTime>(type: "datetime", nullable: true),
                    Data_Hora_Final = table.Column<DateTime>(type: "datetime", nullable: true),
                    Obs = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimento_Coletor_ColetorId",
                        column: x => x.ColetorId,
                        principalTable: "Coletor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movimento_Frota_FrotaId",
                        column: x => x.FrotaId,
                        principalTable: "Frota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movimento_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemMovimento",
                columns: table => new
                {
                    MovimentoId = table.Column<long>(nullable: false),
                    cliprdID = table.Column<long>(nullable: false),
                    Qtd = table.Column<decimal>(type: "numeric(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMovimento", x => new { x.MovimentoId, x.cliprdID });
                    table.ForeignKey(
                        name: "FK_ItemMovimento_ClienteProduto_cliprdID",
                        column: x => x.cliprdID,
                        principalTable: "ClienteProduto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemMovimento_Movimento_MovimentoId",
                        column: x => x.MovimentoId,
                        principalTable: "Movimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemMovimento_cliprdID",
                table: "ItemMovimento",
                column: "cliprdID");

            migrationBuilder.CreateIndex(
                name: "IX_Movimento_ColetorId",
                table: "Movimento",
                column: "ColetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimento_FrotaId",
                table: "Movimento",
                column: "FrotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimento_UsuarioId",
                table: "Movimento",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemMovimento");

            migrationBuilder.DropTable(
                name: "Movimento");
        }
    }
}
