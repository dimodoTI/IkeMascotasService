
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



namespace MascotasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ConfiguracionController : ControllerBase
    {
        private readonly MascotasContext _context;


        public ConfiguracionController(MascotasContext context)
        {
            _context = context;

        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> PutConfiguracion(int id, [FromBody] Configuracion configuracion)
        {
            if (id != configuracion.Id)
            {
                return BadRequest();
            }

            _context.Entry(configuracion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfiguracionExists(id))
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

        // PUT: api/Usuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> PatchConfiguracion(int id, [FromBody] JsonPatchDocument<Configuracion> ConfiguracionPatch)
        {


            Configuracion configuracion = await _context.Configuracion.FirstOrDefaultAsync(u => u.Id == id);

            if (configuracion == null)
            {
                return NotFound();
            }

            try
            {
                ConfiguracionPatch.ApplyTo(configuracion);

                _context.Entry(configuracion).State = EntityState.Modified;

                await _context.SaveChangesAsync();


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfiguracionExists(id))
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
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<Mascotas>> PostConfiguracion(Configuracion configuracion)
        {


            _context.Configuracion.Add(configuracion);

            await _context.SaveChangesAsync();

            return Ok();
        }



        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Configuracion>> DeleteConfiguracion(int id)
        {
            var configuracion = await _context.Configuracion.FindAsync(id);

            if (configuracion == null)
            {
                return NotFound();
            }

            _context.Configuracion.Remove(configuracion);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ConfiguracionExists(int id)
        {
            return _context.Configuracion.Any(e => e.Id == id);
        }

    }

}
