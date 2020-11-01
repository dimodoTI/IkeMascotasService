using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using MascotasApi.Models;

namespace MascotasApi.Handlers.Turnos
{

    public class TurnosDisponiblesCommand : IRequest<TurnosDisponiblesResponse>
    {
        //Propiedades del comando
    }

    public class TurnosDisponiblesResponse
    {
        public List<AgendaDisponibleDTO> _retorno { get; set; }
        public TurnosDisponiblesResponse(List<AgendaDisponibleDTO> retorno)
        {
            _retorno = retorno;
        }

    }
    public class TurnosDisponiblesHandler : IRequestHandler<TurnosDisponiblesCommand, TurnosDisponiblesResponse>
    {
        readonly IMediator _mediatr;
        private readonly MascotasContext _context;
        public TurnosDisponiblesHandler(IMediator meditar, MascotasContext context)
        {
            _mediatr = meditar;
            _context = context;
        }

        public async Task<TurnosDisponiblesResponse> Handle(TurnosDisponiblesCommand request, CancellationToken cancellationToken)
        {
            //operar con la base de datos
            DateTime hoy = DateTime.Today;
            List<Tramos> tramos = _context.Tramos.Where((t) => t.Activo && t.FechaFin >= hoy).ToList();
            Configuracion config = _context.Configuracion.FirstOrDefault();
            List<Reservas> reservas = _context.Reservas.Where(r => r.FechaAtencion >= hoy).ToList();
            int duracionDelTurno = 60 / config.TurnosxHora;
            List<AgendaDisponibleDTO> agendaDisponible = new List<AgendaDisponibleDTO>();
            for (int i = 0; i < config.DiasReserva; i++)
            {
                int diaDeLasemana = (int)hoy.DayOfWeek;
                foreach (Tramos tramo in tramos.Where(t => t.Dia == diaDeLasemana && t.FechaFin >= hoy))
                {
                    for (int hora = tramo.HoraInicio; hora <= tramo.HoraFin; hora = sumaMinutos(hora, duracionDelTurno))
                    {
                        AgendaDisponibleDTO diaDisponible = agendaDisponible.FirstOrDefault(a => a.Fecha == hoy);
                        if (diaDisponible == null)
                        {
                            diaDisponible = new AgendaDisponibleDTO();
                            diaDisponible.Fecha = hoy;
                            List<Horario> horarioDisponibles = new List<Horario>();
                            diaDisponible.Horarios = horarioDisponibles;
                            agendaDisponible.Add(diaDisponible);
                        }
                        Horario horaDisponible = diaDisponible.Horarios.FirstOrDefault(h => h.Hora == hora);
                        if (horaDisponible == null)
                        {
                            horaDisponible = new Horario();
                            horaDisponible.Hora = hora;
                            horaDisponible.Tramos = new List<int>();
                            diaDisponible.Horarios.Add(horaDisponible);
                        }

                        if (reservas.FirstOrDefault(r => r.FechaAtencion == hoy && r.HoraAtencion == hora && r.TramoId == tramo.Id && r.Activo) == null)
                        {
                            horaDisponible.Tramos.Add(tramo.Id);
                        }
                    }
                }
                hoy = hoy.AddDays(1);
            }
            foreach (AgendaDisponibleDTO agenda in agendaDisponible)
            {
                agenda.Horarios.RemoveAll(h => h.Tramos.Count == 0);
            }

            //publicar eventos
            await _mediatr.Publish(new TurnosDisponiblesNotificaction());
            return new TurnosDisponiblesResponse(agendaDisponible);

        }
        private int sumaMinutos(int hora, int minutos)
        {
            int nuevaHora = hora + minutos;
            Decimal nuevosMinutos = ((Decimal)nuevaHora / 100 - Math.Truncate((Decimal)nuevaHora / 100)) * 100;
            if (nuevosMinutos > 59)
            {
                nuevaHora = (int)((Math.Truncate((Decimal)nuevaHora / 100) + 1) * 100 + nuevosMinutos - 60);
            }
            return nuevaHora;
        }
    }


    public class AgendaDisponibleDTO
    {
        public DateTime Fecha { get; set; }
        public List<Horario> Horarios { get; set; }
    }

    public class Horario
    {
        public int Hora { get; set; }
        public List<int> Tramos { get; set; }
    }



    public class TurnosDisponiblesNotificaction : INotification
    {
        public TurnosDisponiblesNotificaction() { }

    }

    public class TurnosDisponiblesNotificactionHandler1 : INotificationHandler<TurnosDisponiblesNotificaction>
    {

        public Task Handle(TurnosDisponiblesNotificaction notificacion, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }

    }

    public class TurnosDisponiblesNotificactionHandler2 : INotificationHandler<TurnosDisponiblesNotificaction>
    {

        public Task Handle(TurnosDisponiblesNotificaction notificacion, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }

    }

}
