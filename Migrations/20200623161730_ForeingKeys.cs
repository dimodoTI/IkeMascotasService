using Microsoft.EntityFrameworkCore.Migrations;

namespace MascotasApi.Migrations
{
    public partial class ForeingKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MascotasTipoId",
                table: "Razas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RazaId",
                table: "Mascotas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Razas_MascotasTipoId",
                table: "Razas",
                column: "MascotasTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_RazaId",
                table: "Mascotas",
                column: "RazaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Razas_RazaId",
                table: "Mascotas",
                column: "RazaId",
                principalTable: "Razas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Razas_MascotasTipo_MascotasTipoId",
                table: "Razas",
                column: "MascotasTipoId",
                principalTable: "MascotasTipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Razas_RazaId",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Razas_MascotasTipo_MascotasTipoId",
                table: "Razas");

            migrationBuilder.DropIndex(
                name: "IX_Razas_MascotasTipoId",
                table: "Razas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_RazaId",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "MascotasTipoId",
                table: "Razas");

            migrationBuilder.DropColumn(
                name: "RazaId",
                table: "Mascotas");
        }
    }
}
