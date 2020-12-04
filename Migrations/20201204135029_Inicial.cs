using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTaxi.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    PagamentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<double>(nullable: false),
                    tipo = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.PagamentoID);
                });

            migrationBuilder.CreateTable(
                name: "Rotas",
                columns: table => new
                {
                    RotaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Custo = table.Column<double>(nullable: false),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rotas", x => x.RotaID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "RotaCorridas",
                columns: table => new
                {
                    RotaCorridaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RotaID = table.Column<int>(nullable: false),
                    PagamentoID = table.Column<int>(nullable: false),
                    TimeInicio = table.Column<DateTime>(nullable: false),
                    TimeFim = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotaCorridas", x => x.RotaCorridaID);
                    table.ForeignKey(
                        name: "FK_RotaCorridas_Pagamentos_PagamentoID",
                        column: x => x.PagamentoID,
                        principalTable: "Pagamentos",
                        principalColumn: "PagamentoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RotaCorridas_Rotas_RotaID",
                        column: x => x.RotaID,
                        principalTable: "Rotas",
                        principalColumn: "RotaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RotaDestinos",
                columns: table => new
                {
                    RotaDestinoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RotaID = table.Column<int>(nullable: false),
                    Destino = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotaDestinos", x => x.RotaDestinoID);
                    table.ForeignKey(
                        name: "FK_RotaDestinos_Rotas_RotaID",
                        column: x => x.RotaID,
                        principalTable: "Rotas",
                        principalColumn: "RotaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RotaOrigens",
                columns: table => new
                {
                    RotaOrigemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RotaID = table.Column<int>(nullable: false),
                    Origem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotaOrigens", x => x.RotaOrigemID);
                    table.ForeignKey(
                        name: "FK_RotaOrigens_Rotas_RotaID",
                        column: x => x.RotaID,
                        principalTable: "Rotas",
                        principalColumn: "RotaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diarias",
                columns: table => new
                {
                    DiariaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<string>(nullable: true),
                    abertura = table.Column<DateTime>(nullable: false),
                    fecho = table.Column<DateTime>(nullable: false),
                    RotaCorridaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diarias", x => x.DiariaID);
                    table.ForeignKey(
                        name: "FK_Diarias_RotaCorridas_RotaCorridaID",
                        column: x => x.RotaCorridaID,
                        principalTable: "RotaCorridas",
                        principalColumn: "RotaCorridaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    CarroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<string>(nullable: true),
                    DiariaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.CarroID);
                    table.ForeignKey(
                        name: "FK_Carros_Diarias_DiariaID",
                        column: x => x.DiariaID,
                        principalTable: "Diarias",
                        principalColumn: "DiariaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    UsuarioID = table.Column<int>(nullable: false),
                    CarroID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaID);
                    table.ForeignKey(
                        name: "FK_Pessoas_Carros_CarroID",
                        column: x => x.CarroID,
                        principalTable: "Carros",
                        principalColumn: "CarroID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pessoas_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarteiraPassageiros",
                columns: table => new
                {
                    CarteiraPassageiroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PessoaID = table.Column<int>(nullable: false),
                    Saldo = table.Column<double>(nullable: false),
                    PagamentoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteiraPassageiros", x => x.CarteiraPassageiroID);
                    table.ForeignKey(
                        name: "FK_CarteiraPassageiros_Pagamentos_PagamentoID",
                        column: x => x.PagamentoID,
                        principalTable: "Pagamentos",
                        principalColumn: "PagamentoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarteiraPassageiros_Pessoas_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cobradores",
                columns: table => new
                {
                    CobradorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PessoaID = table.Column<int>(nullable: false),
                    DiariaID = table.Column<int>(nullable: false),
                    NumeroAssociado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobradores", x => x.CobradorID);
                    table.ForeignKey(
                        name: "FK_Cobradores_Diarias_DiariaID",
                        column: x => x.DiariaID,
                        principalTable: "Diarias",
                        principalColumn: "DiariaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cobradores_Pessoas_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    MotoristaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PessoaID = table.Column<int>(nullable: false),
                    NumeroCarta = table.Column<string>(nullable: true),
                    CarroID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.MotoristaID);
                    table.ForeignKey(
                        name: "FK_Motoristas_Carros_CarroID",
                        column: x => x.CarroID,
                        principalTable: "Carros",
                        principalColumn: "CarroID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motoristas_Pessoas_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passageiros",
                columns: table => new
                {
                    PassageiroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PessoaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiros", x => x.PassageiroID);
                    table.ForeignKey(
                        name: "FK_Passageiros_Pessoas_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_DiariaID",
                table: "Carros",
                column: "DiariaID");

            migrationBuilder.CreateIndex(
                name: "IX_CarteiraPassageiros_PagamentoID",
                table: "CarteiraPassageiros",
                column: "PagamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_CarteiraPassageiros_PessoaID",
                table: "CarteiraPassageiros",
                column: "PessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_Cobradores_DiariaID",
                table: "Cobradores",
                column: "DiariaID");

            migrationBuilder.CreateIndex(
                name: "IX_Cobradores_PessoaID",
                table: "Cobradores",
                column: "PessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_Diarias_RotaCorridaID",
                table: "Diarias",
                column: "RotaCorridaID");

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_CarroID",
                table: "Motoristas",
                column: "CarroID");

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_PessoaID",
                table: "Motoristas",
                column: "PessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_PessoaID",
                table: "Passageiros",
                column: "PessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CarroID",
                table: "Pessoas",
                column: "CarroID");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_UsuarioID",
                table: "Pessoas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_RotaCorridas_PagamentoID",
                table: "RotaCorridas",
                column: "PagamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_RotaCorridas_RotaID",
                table: "RotaCorridas",
                column: "RotaID");

            migrationBuilder.CreateIndex(
                name: "IX_RotaDestinos_RotaID",
                table: "RotaDestinos",
                column: "RotaID");

            migrationBuilder.CreateIndex(
                name: "IX_RotaOrigens_RotaID",
                table: "RotaOrigens",
                column: "RotaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarteiraPassageiros");

            migrationBuilder.DropTable(
                name: "Cobradores");

            migrationBuilder.DropTable(
                name: "Motoristas");

            migrationBuilder.DropTable(
                name: "Passageiros");

            migrationBuilder.DropTable(
                name: "RotaDestinos");

            migrationBuilder.DropTable(
                name: "RotaOrigens");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Diarias");

            migrationBuilder.DropTable(
                name: "RotaCorridas");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Rotas");
        }
    }
}
