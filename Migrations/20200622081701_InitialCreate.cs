using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTaxi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Carros",
                columns: table => new
                {
                    CarroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<string>(nullable: true),
                    MotoristaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.CarroID);
                    table.ForeignKey(
                        name: "FK_Carros_Motoristas_MotoristaID",
                        column: x => x.MotoristaID,
                        principalTable: "Motoristas",
                        principalColumn: "MotoristaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_MotoristaID",
                table: "Carros",
                column: "MotoristaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Motoristas");
        }
    }
}
