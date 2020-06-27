using System;
using System.Collections.Generic;

namespace MascotasApi.Models
{
    public class Tramos
    {
        public int Id { get; set; }
        public int PuestoId { get; set; }
        public int Dia { get; set; }
        public int HoraInicio { get; set; }
        public int HoraFin { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Activo { get; set; }
        public Puestos Puesto { get; set; }
        public List<Reservas> Reservas { get; set; }

    }
}