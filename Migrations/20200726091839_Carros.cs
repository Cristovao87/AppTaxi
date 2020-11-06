using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTaxi.Migrations
{
    public partial class Carros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cobradores",
                columns: table => new
                {
                    CobradorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    BI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobradores", x => x.CobradorID);
                });

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    MotoristaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    BI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.MotoristaID);
                });

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
                name: "Carros",
                columns: table => new
                {
                    CarroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<string>(nullable: true),
                    MotoristaID = table.Column<int>(nullable: false),
                    CobradorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.CarroID);
                    table.ForeignKey(
                        name: "FK_Carros_Cobradores_CobradorID",
                        column: x => x.CobradorID,
                        principalTable: "Cobradores",
                        principalColumn: "CobradorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carros_Motoristas_MotoristaID",
                        column: x => x.MotoristaID,
                        principalTable: "Motoristas",
                        principalColumn: "MotoristaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aberturas",
                columns: table => new
                {
                    AberturaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dia = table.Column<DateTime>(nullable: false),
                    Hora = table.Column<DateTime>(nullable: false),
                    CarroID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aberturas", x => x.AberturaID);
                    table.ForeignKey(
                        name: "FK_Aberturas_Carros_CarroID",
                        column: x => x.CarroID,
                        principalTable: "Carros",
                        principalColumn: "CarroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RotaCarro",
                columns: table => new
                {
                    RotaID = table.Column<int>(nullable: false),
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
                        name: "FK_RotaCarro_Rotas_RotaID",
                        column: x => x.RotaID,
                        principalTable: "Rotas",
                        principalColumn: "RotaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aberturas_CarroID",
                table: "Aberturas",
                column: "CarroID");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_CobradorID",
                table: "Carros",
                column: "CobradorID");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_MotoristaID",
                table: "Carros",
                column: "MotoristaID");

            migrationBuilder.CreateIndex(
                name: "IX_RotaCarro_CarroID",
                table: "RotaCarro",
                column: "CarroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aberturas");

            migrationBuilder.DropTable(
                name: "RotaCarro");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Rotas");

            migrationBuilder.DropTable(
                name: "Cobradores");

            migrationBuilder.DropTable(
                name: "Motoristas");
        }
    }
}
