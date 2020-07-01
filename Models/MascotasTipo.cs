using System;
using System.Collections.Generic;

namespace MascotasApi.Models
{
    public class MascotasTipo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public List<Razas> Razas { get; set; }
        public List<Calendario> Calendarios { get; set; }
        public List<Vacunas> Vacunas { get; set; }

    }
}