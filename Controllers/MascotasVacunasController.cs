
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MascotasApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> Put(int id, [FromBody] MascotasVacunas mascotasVacunas)
        {
            MascotasVacunas mascotaVa = await _context.MascotasVacunas.Include(b => b.Mascota).FirstOrDefaultAsync(u => u.Id == id);

            if (mascotaVa == null)
            {
                return NotFound();
            }

            if (!_permissions.isOwnerOrAdmin(this.User, mascotaVa.Mascota.idUsuario))
            {
                return Forbid();
            }

            _context.Entry(mascotasVacunas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
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


        [HttpPatch("{id}")]


        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<MascotasVacunas> mascotasVacunasPatch)
        {


            MascotasVacunas mascotasVacunas = await _context.MascotasVacunas.Include(b => b.Mascota).FirstOrDefaultAsync(u => u.Id == id);

            if (mascotasVacunas == null)
            {
                return NotFound();
            }

            if (!_permissions.isOwnerOrAdmin(this.User, mascotasVacunas.Mascota.idUsuario))
            {
                return Forbid();
            }

            try
            {
                mascotasVacunasPatch.ApplyTo(mascotasVacunas);

                _context.Entry(mascotasVacunas).State = EntityState.Modified;

                await _context.SaveChangesAsync();


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
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


        [HttpPost]


        public async Task<ActionResult<MascotasVacunas>> Post(MascotasVacunas mascotasVacunas)
        {
            Mascotas mascota = await _context.Mascotas.FirstOrDefaultAsync(u => u.Id == mascotasVacunas.MascotaId);

            if (mascota == null)
            {
                return NotFound();
            }

            if (!_permissions.isOwnerOrAdmin(this.User, mascota.idUsuario))
            {
                return Forbid();
            }
            _context.MascotasVacunas.Add(mascotasVacunas);

            await _context.SaveChangesAsync();

            return Ok();
        }




        [HttpDelete("{id}")]

        public async Task<ActionResult<MascotasVacunas>> Delete(int id)
        {
            var mascotasVacunas = await _context.MascotasVacunas.Include(b => b.Mascota).FirstOrDefaultAsync(f => f.Id == id);

            if (mascotasVacunas == null)
            {
                return NotFound();
            }

            if (!_permissions.isOwnerOrAdmin(this.User, mascotasVacunas.Mascota.idUsuario))
            {
                return Forbid();
            }

            _context.MascotasVacunas.Remove(mascotasVacunas);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool Exists(int id)
        {
            return _context.MascotasVacunas.Any(e => e.Id == id);
        }

    }

}
