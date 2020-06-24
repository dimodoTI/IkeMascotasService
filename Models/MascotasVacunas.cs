using System;
namespace MascotasApi.Models
{
    public class MascotasVacunas
    {
        public int Id { get; set; }
        public int MascotaId { get; set; }
        public int VacunaId { get; set; }
        public DateTime Fecha { get; set; }
        public bool Realizada { get; set; }
        public bool Activo { get; set; }
        public Mascotas Mascota { get; set; }
        public Vacunas Vacuna { get; set; }


    }
}