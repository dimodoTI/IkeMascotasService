
using System;
using System.Collections.Generic;

namespace MascotasApi.Models
{
    public class Atenciones
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public int VeterinarioId { get; set; }
        public DateTime InicioAtencion { get; set; }
        public DateTime FinAtencion { get; set; }
        public string Diagnostico { get; set; }
        public string Observaciones { get; set; }
        public int Estado { get; set; }
        public int Calificacion { get; set; }
        public String ComentarioCalificacion { get; set; }
        public bool Activo { get; set; }
        public Reservas Reserva { get; set; }
    }
}