using Microsoft.EntityFrameworkCore;

namespace MascotasApi.Models
{
    public class MascotasContext : DbContext
    {
        public MascotasContext(DbContextOptions<MascotasContext> options)
            : base(options)
        {
        }

        public DbSet<Mascotas> Mascotas { get; set; }
        public DbSet<MascotasTipo> MascotasTipo { get; set; }
        public DbSet<Razas> Razas { get; set; }

    }
}