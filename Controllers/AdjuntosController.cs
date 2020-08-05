
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MascotasApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace MascotasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class AdjuntosController : ControllerBase
    {
        private readonly MascotasContext _context;


        public AdjuntosController(MascotasContext context)
        {
            _context = context;

        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Put(int id, [FromBody] Adjuntos adjuntos)
        {
            if (id != adjuntos.Id)
            {
                return BadRequest();
            }

            _context.Entry(adjuntos).State = EntityState.Modified;

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
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Adjuntos> adjuntosPatch)
        {


            Adjuntos adjuntos = await _context.Adjuntos.FirstOrDefaultAsync(u => u.Id == id);

            if (adjuntos == null)
            {
                return NotFound();
            }

            try
            {
                adjuntosPatch.ApplyTo(adjuntos);

                _context.Entry(adjuntos).State = EntityState.Modified;

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
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<Adjuntos>> Post(Adjuntos adjuntos)
        {


            _context.Adjuntos.Add(adjuntos);

            await _context.SaveChangesAsync();

            return Ok();
        }




        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Adjuntos>> Delete(int id)
        {
            var adjuntos = await _context.Adjuntos.FindAsync(id);

            if (adjuntos == null)
            {
                return NotFound();
            }

            _context.Adjuntos.Remove(adjuntos);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool Exists(int id)
        {
            return _context.Adjuntos.Any(e => e.Id == id);
        }

    }

}
