using Microsoft.EntityFrameworkCore.Migrations;

namespace GentilCareBack.Models.Migrations
{
    public partial class Proveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    ProveedorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    provedor = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    costo = table.Column<decimal>(nullable: true),
                    cellphone = table.Column<string>(nullable: true),
                    estudio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.ProveedorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proveedor");
        }
    }
}
