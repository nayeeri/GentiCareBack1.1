using Microsoft.EntityFrameworkCore.Migrations;

namespace GentilCareBack.Models.Migrations
{
    public partial class Planes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PlanesId",
                table: "Servicios",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    PlanesId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    costo = table.Column<decimal>(nullable: false),
                    descripcion = table.Column<string>(maxLength: 2000, nullable: true),
                    nombre = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.PlanesId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_PlanesId",
                table: "Servicios",
                column: "PlanesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Planes_PlanesId",
                table: "Servicios",
                column: "PlanesId",
                principalTable: "Planes",
                principalColumn: "PlanesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Planes_PlanesId",
                table: "Servicios");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_PlanesId",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "PlanesId",
                table: "Servicios");
        }
    }
}
