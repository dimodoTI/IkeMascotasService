using System;
using System.Collections.Generic;


namespace MascotasApi.Models
{
    public class Vacunas
    {
        public int Id { get; set; }
        public int MascotaTipoId { set; get; }

        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public List<Calendario> Calendarios { get; set; }
        public MascotasTipo MascotaTipo { get; set; }
    }
}
