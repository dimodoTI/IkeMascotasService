

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MascotasApi.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using Microsoft.AspNetCore.JsonPatch;
using MascotasApi.Helpers;
using mails;
using Microsoft.Extensions.Configuration;



namespace MascotasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReservasController : ControllerBase
    {
        private readonly MascotasContext _context;
        private readonly Permissions _permissions;
        private readonly IikeMailService _mailService;
        private readonly IConfiguration _configuration;

        public ReservasController(MascotasContext context, IikeMailService mailService, IConfiguration configuration)
        {
            _context = context;

            _permissions = new Permissions();
            _mailService = mailService;
            _configuration = configuration;



        }



        [HttpPut("{id}")]

        public async Task<IActionResult> PutReservas(int id, [FromBody] Reservas reservas)
        {
            if (!_permissions.isOwnerOrAdmin(this.User, reservas.UsuarioId))
            {
                return Forbid();
            }

            if (id != reservas.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/Mascotas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPatch("{id}")]

        public async Task<IActionResult> PatchReservas(int id, [FromBody] JsonPatchDocument<Reservas> ReservasPatch)
        {

            Reservas reservas = await _context.Reservas.FirstOrDefaultAsync(u => u.Id == id);

            if (reservas == null)
            {
                return NotFound();
            }

            if (!_permissions.isOwnerOrAdmin(this.User, reservas.UsuarioId))
            {
                return Forbid();
            }

            try
            {
                ReservasPatch.ApplyTo(reservas);

                _context.Entry(reservas).State = EntityState.Modified;

                await _context.SaveChangesAsync();


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Mascotas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[Authorize(Roles = Roles.Admin)]
        [HttpPost]

        public async Task<ActionResult<Reservas>> PostReserva(Reservas reservas)
        {
            if (!_permissions.isAdmin(this.User))
            {
                reservas.UsuarioId = _permissions.getUserId(this.User);
            }
            _context.Reservas.Add(reservas);

            Mascotas mascota = await _context.Mascotas.FirstOrDefaultAsync(e => e.Id == reservas.MascotaId);
            Usuarios usu = _context.Usuarios.FirstOrDefault(u => u.Id == reservas.UsuarioId);
            await _context.SaveChangesAsync();
            DateTime fechaHoy = DateTime.Now.Date;



            if (fechaHoy.CompareTo(reservas.FechaAtencion.Date) == 0)
            {
                var nombreMascota = mascota.Nombre;
                var cliente = usu.Apellido + ", " + usu.Nombre;
                var mail = usu.Email;
                var telefono = usu.Telefono;
                var fecha = reservas.FechaAtencion.Day.ToString().PadLeft(2, '0') + "/" + reservas.FechaAtencion.Month.ToString().PadLeft(2, '0') + "/" + reservas.FechaAtencion.Year.ToString();

                var hora = reservas.HoraAtencion;
                var motivo = reservas.Motivo;
                var body = "<table style='width: 100%;font-family:Verdana;font-size:12px;text-align:left;color: #000000;'><tr style='width: 50%;font-family:Verdana;font-size:12px;text-align:left;color: #000000'><td >Se ha registrado un turno para el día <b>" + fecha + " a las " + hora + " hs</b></td></tr><tr style='width: 50%;font-family:Verdana;font-size:12px;text-align:left;color: #000000;'><td>Nombre de la Mascota <b>" + nombreMascota + "</b></td></tr><tr style='width: 50%;font-family:Verdana;font-size:12px;text-align:left;color: #000000;'><td>Nombre del Cliente <b>" + cliente + "</b></td></tr>  </tr><tr style='width: 50%;font-family:Verdana;font-size:12px;text-align:left;color: #000000;'><td>Telefono del Cliente <b>" + telefono + "</b></td></tr> <tr style='width: 50%;font-family:Verdana;font-size:12px;text-align:left;color: #000000;'><td>Mail del Cliente <b>" + mail + "</b></td></tr> <tr style='width: 50%;font-family:Verdana;font-size:12px;text-align:left;color: #000000;'><td >Motivo de la Consulta</td></tr><tr style='width: 50%;font-family:Verdana;font-size:12px;text-align:left;color: #000000;'><td>" + motivo + "</td></tr></table>";

                AppSettings appSettings = new AppSettings();
                _configuration.GetSection("AppSettings").Bind(appSettings);
                await _mailService.sendReservaMail(body, appSettings.mailVeterinario);
            }





            return Ok();
        }



        // DELETE: api/Mascotas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservas>> DeleteReservas(int id)
        {

            var reservas = await _context.Reservas.FindAsync(id);

            if (reservas == null)
            {
                return NotFound();
            }
            if (!_permissions.isOwnerOrAdmin(this.User, reservas.UsuarioId))
            {
                return Forbid();
            }

            _context.Reservas.Remove(reservas);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ReservasExists(int id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }

    }

}
