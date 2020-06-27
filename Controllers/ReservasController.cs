

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



namespace MascotasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReservasController : ControllerBase
    {
        private readonly MascotasContext _context;
        private readonly Permissions _permissions;

        public ReservasController(MascotasContext context)
        {
            _context = context;

            _permissions = new Permissions();

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

            await _context.SaveChangesAsync();

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
