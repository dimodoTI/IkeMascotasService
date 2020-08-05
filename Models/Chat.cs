using System;
using System.Collections.Generic;

namespace MascotasApi.Models{

    public class Chat{
        public int Id { get; set; }
        public DateTime Fecha {get;set;}
        public int ReservaId {get;set;}
        public int UsuarioId {get;set;}
        public string Texto {get; set;}
        public DateTimeOffset Leido {get;set;}
        public DateTimeOffset Respondido {get;set;}
        public Reservas Reserva { get; set; }
    }
     
     }
