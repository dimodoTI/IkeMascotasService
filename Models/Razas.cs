using System;
using System.Collections.Generic;
namespace MascotasApi.Models
{

    public class Razas
    {
        public int Id { get; set; }
        public int idMascotasTipo { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public MascotasTipo MascotasTipo { get; set; }
        public List<Mascotas> Mascotas { get; set; }

    }
}