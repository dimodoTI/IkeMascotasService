using System;
namespace MascotasApi.Models
{
    public class Calendario
    {
        public int Id { get; set; }
        public int MascotasTipoId { get; set; }
        public string Descripcion { get; set; }
        public string Enfermedades { get; set; }
        public bool Optativa { get; set; }
        public bool Cachorro { get; set; }
        public bool Activo { get; set; }
        public MascotasTipo MascotasTipo { get; set; }

    }
}
