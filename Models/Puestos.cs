using System;
using System.Collections.Generic;

namespace MascotasApi.Models

{
    public class Puestos
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public List<Tramos> Tramos { get; set; }
    }
}