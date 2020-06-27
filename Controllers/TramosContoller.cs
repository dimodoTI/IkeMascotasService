
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

    public class TramosController : ControllerBase
    {
        private readonly MascotasContext _context;


        public TramosController(MascotasContext context)
        {
            _context = context;

        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> PutTramos(int id, [FromBody] Tramos tramos)
        {
            if (id != tramos.Id)
            {
                return BadRequest();
            }

            _context.Entry(tramos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TramosExists(id))
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

        public async Task<IActionResult> PatchTramos(int id, [FromBody] JsonPatchDocument<Tramos> TramosPatch)
        {


            Tramos tramos = await _context.Tramos.FirstOrDefaultAsync(u => u.Id == id);

            if (tramos == null)
            {
                return NotFound();
            }

            try
            {
                TramosPatch.ApplyTo(tramos);

                _context.Entry(tramos).State = EntityState.Modified;

                await _context.SaveChangesAsync();


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TramosExists(id))
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

        public async Task<ActionResult<Mascotas>> PostTramos(Tramos tramos)
        {


            _context.Tramos.Add(tramos);

            await _context.SaveChangesAsync();

            return Ok();
        }



        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Tramos>> DeleteTramos(int id)
        {
            var tramos = await _context.Tramos.FindAsync(id);

            if (tramos == null)
            {
                return NotFound();
            }

            _context.Tramos.Remove(tramos);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool TramosExists(int id)
        {
            return _context.Tramos.Any(e => e.Id == id);
        }

    }

}
