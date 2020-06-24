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

    }
}