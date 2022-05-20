using Microsoft.EntityFrameworkCore.Migrations;

namespace GentilCareBack.Models.Migrations
{
    public partial class SemanasHorasColaboratorskey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Semana",
                columns: table => new
                {
                    SemanaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradorsId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semana", x => x.SemanaId);
                    table.ForeignKey(
                        name: "FK_Semana_Colaboradors_ColaboradorsId",
                        column: x => x.ColaboradorsId,
                        principalTable: "Colaboradors",
                        principalColumn: "ColaboradorsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Horas",
                columns: table => new
                {
                    HorasId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cero = table.Column<bool>(nullable: false),
                    una = table.Column<bool>(nullable: false),
                    dos = table.Column<bool>(nullable: false),
                    tres = table.Column<bool>(nullable: false),
                    cuatro = table.Column<bool>(nullable: false),
                    cinco = table.Column<bool>(nullable: false),
                    seis = table.Column<bool>(nullable: false),
                    siete = table.Column<bool>(nullable: false),
                    ocho = table.Column<bool>(nullable: false),
                    nueve = table.Column<bool>(nullable: false),
                    diez = table.Column<bool>(nullable: false),
                    once = table.Column<bool>(nullable: false),
                    doce = table.Column<bool>(nullable: false),
                    trece = table.Column<bool>(nullable: false),
                    catorce = table.Column<bool>(nullable: false),
                    quince = table.Column<bool>(nullable: false),
                    dieciseis = table.Column<bool>(nullable: false),
                    diecisiete = table.Column<bool>(nullable: false),
                    dieciocho = table.Column<bool>(nullable: false),
                    diecinueve = table.Column<bool>(nullable: false),
                    veinte = table.Column<bool>(nullable: false),
                    veintiuno = table.Column<bool>(nullable: false),
                    veintidos = table.Column<bool>(nullable: false),
                    veintitres = table.Column<bool>(nullable: false),
                    SemanaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horas", x => x.HorasId);
                    table.ForeignKey(
                        name: "FK_Horas_Semana_SemanaId",
                        column: x => x.SemanaId,
                        principalTable: "Semana",
                        principalColumn: "SemanaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horas_SemanaId",
                table: "Horas",
                column: "SemanaId");

            migrationBuilder.CreateIndex(
                name: "IX_Semana_ColaboradorsId",
                table: "Semana",
                column: "ColaboradorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horas");

            migrationBuilder.DropTable(
                name: "Semana");
        }
    }
}
