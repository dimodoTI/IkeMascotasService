
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

    public class PuestosController : ControllerBase
    {
        private readonly MascotasContext _context;


        public PuestosController(MascotasContext context)
        {
            _context = context;

        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> PutPuestos(int id, [FromBody] Puestos puestos)
        {
            if (id != puestos.Id)
            {
                return BadRequest();
            }

            _context.Entry(puestos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuestosExists(id))
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

        public async Task<IActionResult> PatchPuestos(int id, [FromBody] JsonPatchDocument<Puestos> PuestosPatch)
        {


            Puestos puestos = await _context.Puestos.FirstOrDefaultAsync(u => u.Id == id);

            if (puestos == null)
            {
                return NotFound();
            }

            try
            {
                PuestosPatch.ApplyTo(puestos);

                _context.Entry(puestos).State = EntityState.Modified;

                await _context.SaveChangesAsync();


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuestosExists(id))
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

        public async Task<ActionResult<Mascotas>> PostPuestos(Puestos puestos)
        {


            _context.Puestos.Add(puestos);

            await _context.SaveChangesAsync();

            return Ok();
        }



        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Puestos>> DeletePuestos(int id)
        {
            var puestos = await _context.Puestos.FindAsync(id);

            if (puestos == null)
            {
                return NotFound();
            }

            _context.Puestos.Remove(puestos);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool PuestosExists(int id)
        {
            return _context.Puestos.Any(e => e.Id == id);
        }

    }

}
