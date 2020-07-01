using Microsoft.EntityFrameworkCore.Migrations;

namespace MascotasApi.Migrations
{
    public partial class VacunasCalendarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Calendario_MascotasTipoId",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "Cachorro",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Calendario");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Vacunas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Edad",
                table: "Calendario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Periodicidad",
                table: "Calendario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VacunaId",
                table: "Calendario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_MascotasTipoId",
                table: "Calendario",
                column: "MascotasTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_VacunaId",
                table: "Calendario",
                column: "VacunaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendario_Vacunas_VacunaId",
                table: "Calendario",
                column: "VacunaId",
                principalTable: "Vacunas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendario_Vacunas_VacunaId",
                table: "Calendario");

            migrationBuilder.DropIndex(
                name: "IX_Calendario_MascotasTipoId",
                table: "Calendario");

            migrationBuilder.DropIndex(
                name: "IX_Calendario_VacunaId",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Vacunas");

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "Periodicidad",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "VacunaId",
                table: "Calendario");

            migrationBuilder.AddColumn<bool>(
                name: "Cachorro",
                table: "Calendario",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Calendario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_MascotasTipoId",
                table: "Calendario",
                column: "MascotasTipoId",
                unique: true);
        }
    }
}
