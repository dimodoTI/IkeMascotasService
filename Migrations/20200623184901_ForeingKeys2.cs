using Microsoft.EntityFrameworkCore.Migrations;

namespace MascotasApi.Migrations
{
    public partial class ForeingKeys2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Razas_idMascotasTipo",
                table: "Razas",
                column: "idMascotasTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_idRaza",
                table: "Mascotas",
                column: "idRaza");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Razas_idRaza",
                table: "Mascotas",
                column: "idRaza",
                principalTable: "Razas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Razas_MascotasTipo_idMascotasTipo",
                table: "Razas",
                column: "idMascotasTipo",
                principalTable: "MascotasTipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Razas_idRaza",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Razas_MascotasTipo_idMascotasTipo",
                table: "Razas");

            migrationBuilder.DropIndex(
                name: "IX_Razas_idMascotasTipo",
                table: "Razas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_idRaza",
                table: "Mascotas");

            migrationBuilder.AddColumn<int>(
                name: "MascotasTipoId",
                table: "Razas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RazaId",
                table: "Mascotas",
                type: "int",
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
    }
}
