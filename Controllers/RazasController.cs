
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

    public class RazasController : ControllerBase
    {
        private readonly MascotasContext _context;


        public RazasController(MascotasContext context)
        {
            _context = context;

        }

        // GET: api/Razas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Razas>>> GetRazas()
        {

            IEnumerable<Razas> razas = await _context.Razas.ToListAsync();

            return razas.ToList();
        }

        // GET: api/Razas/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Razas>> GetRaza(int id)
        {
            var razas = await _context.Razas.FindAsync(id);

            if (razas == null)
            {
                return NotFound();
            }

            return razas;
        }


        // PUT: api/Razas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]

        public async Task<IActionResult> PutRazas(int id, [FromBody] Razas razas)
        {
            if (id != razas.Id)
            {
                return BadRequest();
            }

            _context.Entry(razas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RazasExists(id))
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

        // PUT: api/Razas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPatch("{id}")]

        public async Task<IActionResult> PatchRazas(int id, [FromBody] JsonPatchDocument<Razas> RazasPatch)
        {


            Razas razas = await _context.Razas.FirstOrDefaultAsync(u => u.Id == id);

            if (razas == null)
            {
                return NotFound();
            }

            try
            {
                RazasPatch.ApplyTo(razas);

                _context.Entry(razas).State = EntityState.Modified;

                await _context.SaveChangesAsync();


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RazasExists(id))
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

        // POST: api/Razas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[Authorize(Roles = Roles.Admin)]
        [HttpPost]

        public async Task<ActionResult<Razas>> PostRazas(Razas razas)
        {


            _context.Razas.Add(razas);

            await _context.SaveChangesAsync();

            return Ok();
        }



        // DELETE: api/Razas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Razas>> DeleteRazas(int id)
        {
            var razas = await _context.Razas.FindAsync(id);

            if (razas == null)
            {
                return NotFound();
            }

            _context.Razas.Remove(razas);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool RazasExists(int id)
        {
            return _context.Razas.Any(e => e.Id == id);
        }

    }

}
