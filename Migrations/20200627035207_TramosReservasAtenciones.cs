using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MascotasApi.Migrations
{
    public partial class TramosReservasAtenciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuracion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiasReserva = table.Column<int>(nullable: false),
                    TurnosxHora = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tramos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PuestoId = table.Column<int>(nullable: false),
                    Dia = table.Column<int>(nullable: false),
                    HoraInicio = table.Column<int>(nullable: false),
                    HoraFin = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tramos_Puestos_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TramoId = table.Column<int>(nullable: false),
                    MascotaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    FechaAtencion = table.Column<DateTime>(nullable: false),
                    HoraAtencion = table.Column<int>(nullable: false),
                    FechaGeneracion = table.Column<DateTime>(nullable: false),
                    Motivo = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Mascotas_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Tramos_TramoId",
                        column: x => x.TramoId,
                        principalTable: "Tramos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atenciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservaId = table.Column<int>(nullable: false),
                    VeterinarioId = table.Column<int>(nullable: false),
                    FinAtencion = table.Column<DateTime>(nullable: false),
                    Diagnostico = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    Calificacion = table.Column<int>(nullable: false),
                    ComentarioCalificacion = table.Column<string>(nullable: true),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atenciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atenciones_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atenciones_ReservaId",
                table: "Atenciones",
                column: "ReservaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_MascotaId",
                table: "Reservas",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_TramoId",
                table: "Reservas",
                column: "TramoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tramos_PuestoId",
                table: "Tramos",
                column: "PuestoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atenciones");

            migrationBuilder.DropTable(
                name: "Configuracion");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Tramos");

            migrationBuilder.DropTable(
                name: "Puestos");
        }
    }
}
