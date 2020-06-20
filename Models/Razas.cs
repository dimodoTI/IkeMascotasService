using System;
namespace MascotasApi.Models
{

    public class Razas
    {
        public int Id { get; set; }
        public int idMascotasTipo { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

    }
}