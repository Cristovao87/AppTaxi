using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTaxi.Migrations
{
    public partial class tb_cobrador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CobradorID",
                table: "Carros",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Carros_CobradorID",
                table: "Carros",
                column: "CobradorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Cobradores_CobradorID",
                table: "Carros",
                column: "CobradorID",
                principalTable: "Cobradores",
                principalColumn: "CobradorID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Cobradores_CobradorID",
                table: "Carros");

            migrationBuilder.DropTable(
                name: "Cobradores");

            migrationBuilder.DropIndex(
                name: "IX_Carros_CobradorID",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "CobradorID",
                table: "Carros");
        }
    }
}
