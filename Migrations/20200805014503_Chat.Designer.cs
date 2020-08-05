﻿// <auto-generated />
using System;
using MascotasApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MascotasApi.Migrations
{
    [DbContext(typeof(MascotasContext))]
    [Migration("20200805014503_Chat")]
    partial class Chat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MascotasApi.Models.Atenciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.Property<string>("ComentarioCalificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnostico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FinAtencion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InicioAtencion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.Property<int>("VeterinarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservaId")
                        .IsUnique();

                    b.ToTable("Atenciones");
                });

            modelBuilder.Entity("MascotasApi.Models.Calendario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Edad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Enfermedades")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MascotasTipoId")
                        .HasColumnType("int");

                    b.Property<bool>("Optativa")
                        .HasColumnType("bit");

                    b.Property<string>("Periodicidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VacunaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MascotasTipoId");

                    b.HasIndex("VacunaId");

                    b.ToTable("Calendario");
                });

            modelBuilder.Entity("MascotasApi.Models.Configuracion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiasReserva")
                        .HasColumnType("int");

                    b.Property<int>("TurnosxHora")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Configuracion");
                });

            modelBuilder.Entity("MascotasApi.Models.Mascotas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<bool>("Castrada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idRaza")
                        .HasColumnType("int");

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("idRaza");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("MascotasApi.Models.MascotasTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MascotasTipo");
                });

            modelBuilder.Entity("MascotasApi.Models.MascotasVacunas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("MascotaId")
                        .HasColumnType("int");

                    b.Property<bool>("Realizada")
                        .HasColumnType("bit");

                    b.Property<int>("VacunaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MascotaId");

                    b.HasIndex("VacunaId");

                    b.ToTable("MascotasVacunas");
                });

            modelBuilder.Entity("MascotasApi.Models.Puestos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Puestos");
                });

            modelBuilder.Entity("MascotasApi.Models.Razas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idMascotasTipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("idMascotasTipo");

                    b.ToTable("Razas");
                });

            modelBuilder.Entity("MascotasApi.Models.Reservas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.Property<string>("ComentarioCalificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAtencion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaGeneracion")
                        .HasColumnType("datetime2");

                    b.Property<int>("HoraAtencion")
                        .HasColumnType("int");

                    b.Property<int>("MascotaId")
                        .HasColumnType("int");

                    b.Property<string>("Motivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TramoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MascotaId");

                    b.HasIndex("TramoId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("MascotasApi.Models.Tramos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("Dia")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<int>("HoraFin")
                        .HasColumnType("int");

                    b.Property<int>("HoraInicio")
                        .HasColumnType("int");

                    b.Property<int>("PuestoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PuestoId");

                    b.ToTable("Tramos");
                });

            modelBuilder.Entity("MascotasApi.Models.Vacunas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MascotaTipoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MascotaTipoId");

                    b.ToTable("Vacunas");
                });

            modelBuilder.Entity("MascotasApi.Models.Atenciones", b =>
                {
                    b.HasOne("MascotasApi.Models.Reservas", "Reserva")
                        .WithOne("Atencion")
                        .HasForeignKey("MascotasApi.Models.Atenciones", "ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MascotasApi.Models.Calendario", b =>
                {
                    b.HasOne("MascotasApi.Models.MascotasTipo", "MascotasTipo")
                        .WithMany("Calendarios")
                        .HasForeignKey("MascotasTipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MascotasApi.Models.Vacunas", "Vacuna")
                        .WithMany("Calendarios")
                        .HasForeignKey("VacunaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MascotasApi.Models.Mascotas", b =>
                {
                    b.HasOne("MascotasApi.Models.Razas", "Raza")
                        .WithMany("Mascotas")
                        .HasForeignKey("idRaza")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MascotasApi.Models.MascotasVacunas", b =>
                {
                    b.HasOne("MascotasApi.Models.Mascotas", "Mascota")
                        .WithMany("MascotasVacuna")
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MascotasApi.Models.Vacunas", "Vacuna")
                        .WithMany()
                        .HasForeignKey("VacunaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MascotasApi.Models.Razas", b =>
                {
                    b.HasOne("MascotasApi.Models.MascotasTipo", "MascotasTipo")
                        .WithMany("Razas")
                        .HasForeignKey("idMascotasTipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MascotasApi.Models.Reservas", b =>
                {
                    b.HasOne("MascotasApi.Models.Mascotas", "Mascota")
                        .WithMany("Reservas")
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MascotasApi.Models.Tramos", "Tramo")
                        .WithMany("Reservas")
                        .HasForeignKey("TramoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MascotasApi.Models.Tramos", b =>
                {
                    b.HasOne("MascotasApi.Models.Puestos", "Puesto")
                        .WithMany("Tramos")
                        .HasForeignKey("PuestoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MascotasApi.Models.Vacunas", b =>
                {
                    b.HasOne("MascotasApi.Models.MascotasTipo", "MascotaTipo")
                        .WithMany("Vacunas")
                        .HasForeignKey("MascotaTipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
