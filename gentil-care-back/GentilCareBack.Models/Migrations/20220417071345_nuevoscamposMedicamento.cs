using Microsoft.EntityFrameworkCore.Migrations;

namespace GentilCareBack.Models.Migrations
{
    public partial class nuevoscamposMedicamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "costo",
                table: "Medicamento",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "existencia",
                table: "Medicamento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "costo",
                table: "Medicamento");

            migrationBuilder.DropColumn(
                name: "existencia",
                table: "Medicamento");
        }
    }
}
