using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AlterNameTable_temMovim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemMovimento_ClienteProduto_cliprdID",
                table: "ItemMovimento");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemMovimento_Movimento_MovimentoId",
                table: "ItemMovimento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemMovimento",
                table: "ItemMovimento");

            migrationBuilder.RenameTable(
                name: "ItemMovimento",
                newName: "Item_Movimento");

            migrationBuilder.RenameIndex(
                name: "IX_ItemMovimento_cliprdID",
                table: "Item_Movimento",
                newName: "IX_Item_Movimento_cliprdID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item_Movimento",
                table: "Item_Movimento",
                columns: new[] { "MovimentoId", "cliprdID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Movimento_ClienteProduto_cliprdID",
                table: "Item_Movimento",
                column: "cliprdID",
                principalTable: "ClienteProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Movimento_Movimento_MovimentoId",
                table: "Item_Movimento",
                column: "MovimentoId",
                principalTable: "Movimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Movimento_ClienteProduto_cliprdID",
                table: "Item_Movimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Movimento_Movimento_MovimentoId",
                table: "Item_Movimento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item_Movimento",
                table: "Item_Movimento");

            migrationBuilder.RenameTable(
                name: "Item_Movimento",
                newName: "ItemMovimento");

            migrationBuilder.RenameIndex(
                name: "IX_Item_Movimento_cliprdID",
                table: "ItemMovimento",
                newName: "IX_ItemMovimento_cliprdID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemMovimento",
                table: "ItemMovimento",
                columns: new[] { "MovimentoId", "cliprdID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMovimento_ClienteProduto_cliprdID",
                table: "ItemMovimento",
                column: "cliprdID",
                principalTable: "ClienteProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMovimento_Movimento_MovimentoId",
                table: "ItemMovimento",
                column: "MovimentoId",
                principalTable: "Movimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
