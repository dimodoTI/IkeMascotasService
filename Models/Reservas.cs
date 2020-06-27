using System;
using System.Collections.Generic;

namespace MascotasApi.Models
{
    public class Reservas
    {
        public int Id { get; set; }
        public int TramoId { get; set; }
        public int MascotaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaAtencion { get; set; }
        public int HoraAtencion { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public string Motivo { get; set; }
        public int Estado { get; set; }
        public bool Activo { get; set; }
        public Tramos Tramo { get; set; }
        public Mascotas Mascota { get; set; }
        public Atenciones Atencion { get; set; }

    }
}