using Microsoft.EntityFrameworkCore;

namespace MascotasApi.Models
{
    public class MascotasContext : DbContext
    {
        public MascotasContext(DbContextOptions<MascotasContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mascotas>()
                .HasOne(p => p.Raza)
                .WithMany(b => b.Mascotas)
                .HasForeignKey(f => f.idRaza);

            modelBuilder.Entity<Razas>()
                .HasOne(p => p.MascotasTipo)
                .WithMany(b => b.Razas)
                .HasForeignKey(f => f.idMascotasTipo);
        }
        public DbSet<Mascotas> Mascotas { get; set; }
        public DbSet<MascotasTipo> MascotasTipo { get; set; }
        public DbSet<Razas> Razas { get; set; }
        public DbSet<Calendario> Calendario { get; set; }
        public DbSet<Vacunas> Vacunas { get; set; }

        public DbSet<MascotasVacunas> MascotasVacunas { get; set; }
        public DbSet<Configuracion> Configuracion { get; set; }
        public DbSet<Puestos> Puestos { get; set; }
        public DbSet<Tramos> Tramos { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<Atenciones> Atenciones { get; set; }

        public DbSet<Adjuntos> Adjuntos { get; set; }





    }
}