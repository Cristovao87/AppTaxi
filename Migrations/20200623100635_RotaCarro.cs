using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTaxi.Migrations
{
    public partial class RotaCarro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Cobradores_CobradorID",
                table: "Carros");

            migrationBuilder.AlterColumn<int>(
                name: "CobradorID",
                table: "Carros",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Rotas",
                columns: table => new
                {
                    RotaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome_Rota = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rotas", x => x.RotaID);
                });

            migrationBuilder.CreateTable(
                name: "RotaCarro",
                columns: table => new
                {
                    RotaID = table.Column<int>(nullable: false),
                    RotaID1 = table.Column<int>(nullable: true),
                    CarroID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotaCarro", x => new { x.RotaID, x.CarroID });
                    table.ForeignKey(
                        name: "FK_RotaCarro_Carros_CarroID",
                        column: x => x.CarroID,
                        principalTable: "Carros",
                        principalColumn: "CarroID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RotaCarro_Rotas_RotaID1",
                        column: x => x.RotaID1,
                        principalTable: "Rotas",
                        principalColumn: "RotaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RotaCarro_CarroID",
                table: "RotaCarro",
                column: "CarroID");

            migrationBuilder.CreateIndex(
                name: "IX_RotaCarro_RotaID1",
                table: "RotaCarro",
                column: "RotaID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Cobradores_CobradorID",
                table: "Carros",
                column: "CobradorID",
                principalTable: "Cobradores",
                principalColumn: "CobradorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Cobradores_CobradorID",
                table: "Carros");

            migrationBuilder.DropTable(
                name: "RotaCarro");

            migrationBuilder.DropTable(
                name: "Rotas");

            migrationBuilder.AlterColumn<int>(
                name: "CobradorID",
                table: "Carros",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Cobradores_CobradorID",
                table: "Carros",
                column: "CobradorID",
                principalTable: "Cobradores",
                principalColumn: "CobradorID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
