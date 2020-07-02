

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

    public class MascotasVacunasController : ControllerBase
    {
        private readonly MascotasContext _context;
        private readonly Permissions _permissions;

        public MascotasVacunasController(MascotasContext context)
        {
            _context = context;

            _permissions = new Permissions();

        }



        [HttpPut("{id}")]

        public async Task<IActionResult> PutMascotasVacunas(int id, [FromBody] MascotasVacunas mascotasvacunas)
        {
            Mascotas mascota = await _context.Mascotas.FirstOrDefaultAsync(u => u.Id == mascotasvacunas.MascotaId);
            if (!_permissions.isOwnerOrAdmin(this.User, mascota.idUsuario))
            {
                return Forbid();
            }

            if (id != mascotasvacunas.Id)
            {
                return BadRequest();
            }

            _context.Entry(mascotasvacunas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotasVacunasExists(id))
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

        public async Task<IActionResult> PatchMascotasVacunas(int id, [FromBody] JsonPatchDocument<MascotasVacunas> MascotasVacunasPatch)
        {

            MascotasVacunas mascotasvacunas = await _context.MascotasVacunas.FirstOrDefaultAsync(u => u.Id == id);

            if (mascotasvacunas == null)
            {
                return NotFound();
            }

            Mascotas mascota = await _context.Mascotas.FirstOrDefaultAsync(u => u.Id == mascotasvacunas.MascotaId);

            if (!_permissions.isOwnerOrAdmin(this.User, mascota.idUsuario))
            {
                return Forbid();
            }

            try
            {
                MascotasVacunasPatch.ApplyTo(mascotasvacunas);

                _context.Entry(mascotasvacunas).State = EntityState.Modified;

                await _context.SaveChangesAsync();


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotasVacunasExists(id))
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

        public async Task<ActionResult<MascotasVacunas>> PostMascotasVacunas(MascotasVacunas mascotasvacunas)
        {
            Mascotas mascota = await _context.Mascotas.FirstOrDefaultAsync(u => u.Id == mascotasvacunas.MascotaId);

            if (!_permissions.isAdmin(this.User))
            {
                mascota.idUsuario = _permissions.getUserId(this.User);
            }
            _context.MascotasVacunas.Add(mascotasvacunas);

            await _context.SaveChangesAsync();

            return Ok();
        }



        // DELETE: api/Mascotas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MascotasVacunas>> DeleteMascotasVacunas(int id)
        {

            var mascotasvacunas = await _context.MascotasVacunas.FindAsync(id);

            if (mascotasvacunas == null)
            {
                return NotFound();
            }
            Mascotas mascota = await _context.Mascotas.FirstOrDefaultAsync(u => u.Id == mascotasvacunas.MascotaId);

            if (!_permissions.isOwnerOrAdmin(this.User, mascota.idUsuario))
            {
                return Forbid();
            }

            _context.MascotasVacunas.Remove(mascotasvacunas);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool MascotasVacunasExists(int id)
        {
            return _context.MascotasVacunas.Any(e => e.Id == id);
        }

    }

}
