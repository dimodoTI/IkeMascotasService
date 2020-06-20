
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

    public class MascotasTipoController : ControllerBase
    {
        private readonly MascotasContext _context;


        public MascotasTipoController(MascotasContext context)
        {
            _context = context;

        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MascotasTipo>>> GetMascotasTipos()
        {

            IEnumerable<MascotasTipo> mascotasTipos = await _context.MascotasTipo.ToListAsync();

            return mascotasTipos.ToList();
        }

        // GET: api/MascotasTipo/5
        [HttpGet("{id}")]

        public async Task<ActionResult<MascotasTipo>> GetMascotasTipo(int id)
        {
            var mascotasTipo = await _context.MascotasTipo.FindAsync(id);

            if (mascotasTipo == null)
            {
                return NotFound();
            }

            return mascotasTipo;
        }


        // PUT: api/MascotasTipo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]

        public async Task<IActionResult> PutMascotasTipo(int id, [FromBody] MascotasTipo mascotastipo)
        {
            if (id != mascotastipo.Id)
            {
                return BadRequest();
            }

            _context.Entry(mascotastipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotasTipoExists(id))
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

        public async Task<IActionResult> PatchMascotasTipo(int id, [FromBody] JsonPatchDocument<MascotasTipo> MascotasTipoPatch)
        {


            MascotasTipo mascotasTipo = await _context.MascotasTipo.FirstOrDefaultAsync(u => u.Id == id);

            if (mascotasTipo == null)
            {
                return NotFound();
            }

            try
            {
                MascotasTipoPatch.ApplyTo(mascotasTipo);

                _context.Entry(mascotasTipo).State = EntityState.Modified;

                await _context.SaveChangesAsync();


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotasTipoExists(id))
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

        // POST: api/Usuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[Authorize(Roles = Roles.Admin)]
        [HttpPost]

        public async Task<ActionResult<Mascotas>> PostUsuario(MascotasTipo mascotasTipo)
        {


            _context.MascotasTipo.Add(mascotasTipo);

            await _context.SaveChangesAsync();

            return Ok();
        }



        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MascotasTipo>> DeleteMascotasTipo(int id)
        {
            var mascotasTipo = await _context.MascotasTipo.FindAsync(id);

            if (mascotasTipo == null)
            {
                return NotFound();
            }

            _context.MascotasTipo.Remove(mascotasTipo);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool MascotasTipoExists(int id)
        {
            return _context.MascotasTipo.Any(e => e.Id == id);
        }

    }

}
