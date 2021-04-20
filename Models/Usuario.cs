using System;
using System.Collections.Generic;

namespace MascotasApi.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
        public List<Atenciones> Atenciones { get; set; }
        public List<Mascotas> Mascotas { get; set; }
    }
}