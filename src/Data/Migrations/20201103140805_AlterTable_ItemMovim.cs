using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AlterTable_ItemMovim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Item_Movimento",
                table: "Item_Movimento");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Item_Movimento",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item_Movimento",
                table: "Item_Movimento",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Movimento_MovimentoId",
                table: "Item_Movimento",
                column: "MovimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Item_Movimento",
                table: "Item_Movimento");

            migrationBuilder.DropIndex(
                name: "IX_Item_Movimento_MovimentoId",
                table: "Item_Movimento");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Item_Movimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item_Movimento",
                table: "Item_Movimento",
                columns: new[] { "MovimentoId", "cliprdID" });
        }
    }
}
