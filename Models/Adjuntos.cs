
using System;
using System.Collections.Generic;

namespace MascotasApi.Models
{
    public class Adjuntos
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public int UsuarioId { get; set; }
        public string Perfil { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Url { get; set; }
        public string Observaciones { get; set; }

        public bool Activo { get; set; }
        public Reservas Reserva { get; set; }
    }
}