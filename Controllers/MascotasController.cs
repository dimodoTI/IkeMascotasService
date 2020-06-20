
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

    public class MascotasController : ControllerBase
    {
        private readonly MascotasContext _context;


        public MascotasController(MascotasContext context)
        {
            _context = context;

        }

        // GET: api/Mascotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mascotas>>> GetMascotas()
        {

            IEnumerable<Mascotas> mascotas = await _context.Mascotas.ToListAsync();

            return mascotas.ToList();
        }

        // GET: api/Mascotas/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Mascotas>> GetMascota(int id)
        {
            var mascotas = await _context.Mascotas.FindAsync(id);

            if (mascotas == null)
            {
                return NotFound();
            }

            return mascotas;
        }


        // PUT: api/Mascotas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]

        public async Task<IActionResult> PutMascotas(int id, [FromBody] Mascotas mascotas)
        {
            if (id != mascotas.Id)
            {
                return BadRequest();
            }

            _context.Entry(mascotas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotasExists(id))
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

        public async Task<IActionResult> PatchMascotas(int id, [FromBody] JsonPatchDocument<Mascotas> MascotasPatch)
        {


            Mascotas mascotas = await _context.Mascotas.FirstOrDefaultAsync(u => u.Id == id);

            if (mascotas == null)
            {
                return NotFound();
            }

            try
            {
                MascotasPatch.ApplyTo(mascotas);

                _context.Entry(mascotas).State = EntityState.Modified;

                await _context.SaveChangesAsync();


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotasExists(id))
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

        public async Task<ActionResult<Mascotas>> PostMascotas(Mascotas mascotas)
        {


            _context.Mascotas.Add(mascotas);

            await _context.SaveChangesAsync();

            return Ok();
        }



        // DELETE: api/Mascotas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mascotas>> DeleteMascotas(int id)
        {
            var mascotas = await _context.Mascotas.FindAsync(id);

            if (mascotas == null)
            {
                return NotFound();
            }

            _context.Mascotas.Remove(mascotas);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool MascotasExists(int id)
        {
            return _context.Mascotas.Any(e => e.Id == id);
        }

    }

}
