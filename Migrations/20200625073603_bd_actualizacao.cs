using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTaxi.Migrations
{
    public partial class bd_actualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RotaCarro_Rotas_RotaID1",
                table: "RotaCarro");

            migrationBuilder.DropIndex(
                name: "IX_RotaCarro_RotaID1",
                table: "RotaCarro");

            migrationBuilder.DropColumn(
                name: "RotaID1",
                table: "RotaCarro");

            migrationBuilder.AddForeignKey(
                name: "FK_RotaCarro_Rotas_RotaID",
                table: "RotaCarro",
                column: "RotaID",
                principalTable: "Rotas",
                principalColumn: "RotaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RotaCarro_Rotas_RotaID",
                table: "RotaCarro");

            migrationBuilder.AddColumn<int>(
                name: "RotaID1",
                table: "RotaCarro",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RotaCarro_RotaID1",
                table: "RotaCarro",
                column: "RotaID1");

            migrationBuilder.AddForeignKey(
                name: "FK_RotaCarro_Rotas_RotaID1",
                table: "RotaCarro",
                column: "RotaID1",
                principalTable: "Rotas",
                principalColumn: "RotaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
