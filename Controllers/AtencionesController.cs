

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

    public class AtencionesController : ControllerBase
    {
        private readonly MascotasContext _context;
        private readonly Permissions _permissions;

        public AtencionesController(MascotasContext context)
        {
            _context = context;

            _permissions = new Permissions();

        }



        [HttpPut("{id}")]

        public async Task<IActionResult> PutAtenciones(int id, [FromBody] Atenciones atenciones)
        {
            if (!_permissions.isOwnerOrAdmin(this.User, atenciones.VeterinarioId))
            {
                return Forbid();
            }

            if (id != atenciones.Id)
            {
                return BadRequest();
            }

            _context.Entry(atenciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtencionesExists(id))
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

        public async Task<IActionResult> PatchAtenciones(int id, [FromBody] JsonPatchDocument<Atenciones> AtencionesPatch)
        {

            Atenciones atenciones = await _context.Atenciones.FirstOrDefaultAsync(u => u.Id == id);

            if (atenciones == null)
            {
                return NotFound();
            }

            if (!_permissions.isOwnerOrAdmin(this.User, atenciones.VeterinarioId))
            {
                return Forbid();
            }

            try
            {
                AtencionesPatch.ApplyTo(atenciones);

                _context.Entry(atenciones).State = EntityState.Modified;

                await _context.SaveChangesAsync();


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtencionesExists(id))
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

        public async Task<ActionResult<Atenciones>> PostReserva(Atenciones atenciones)
        {
            if (!_permissions.isAdmin(this.User))
            {
                atenciones.VeterinarioId = _permissions.getUserId(this.User);
            }
            _context.Atenciones.Add(atenciones);

            await _context.SaveChangesAsync();

            return Ok();
        }



        // DELETE: api/Mascotas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Atenciones>> DeleteAtenciones(int id)
        {

            var atenciones = await _context.Atenciones.FindAsync(id);

            if (atenciones == null)
            {
                return NotFound();
            }
            if (!_permissions.isOwnerOrAdmin(this.User, atenciones.VeterinarioId))
            {
                return Forbid();
            }

            _context.Atenciones.Remove(atenciones);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool AtencionesExists(int id)
        {
            return _context.Atenciones.Any(e => e.Id == id);
        }

    }

}
