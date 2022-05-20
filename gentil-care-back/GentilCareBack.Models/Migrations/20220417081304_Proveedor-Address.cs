using Microsoft.EntityFrameworkCore.Migrations;

namespace GentilCareBack.Models.Migrations
{
    public partial class ProveedorAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AddressesId",
                table: "Proveedor",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_AddressesId",
                table: "Proveedor",
                column: "AddressesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_Addresses_AddressesId",
                table: "Proveedor",
                column: "AddressesId",
                principalTable: "Addresses",
                principalColumn: "AddressesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_Addresses_AddressesId",
                table: "Proveedor");

            migrationBuilder.DropIndex(
                name: "IX_Proveedor_AddressesId",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "AddressesId",
                table: "Proveedor");
        }
    }
}
