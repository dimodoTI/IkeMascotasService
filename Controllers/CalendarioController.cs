
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

    public class CalendarioController : ControllerBase
    {
        private readonly MascotasContext _context;


        public CalendarioController(MascotasContext context)
        {
            _context = context;

        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Put(int id, [FromBody] Calendario calendario)
        {
            if (id != calendario.Id)
            {
                return BadRequest();
            }

            _context.Entry(calendario).State = EntityState.Modified;

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

        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Calendario> calendarioPatch)
        {


            Calendario calendario = await _context.Calendario.FirstOrDefaultAsync(u => u.Id == id);

            if (calendario == null)
            {
                return NotFound();
            }

            try
            {
                calendarioPatch.ApplyTo(calendario);

                _context.Entry(calendario).State = EntityState.Modified;

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

        public async Task<ActionResult<Calendario>> Post(Calendario calendario)
        {


            _context.Calendario.Add(calendario);

            await _context.SaveChangesAsync();

            return Ok();
        }




        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Calendario>> Delete(int id)
        {
            var calendario = await _context.Calendario.FindAsync(id);

            if (calendario == null)
            {
                return NotFound();
            }

            _context.Calendario.Remove(calendario);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool Exists(int id)
        {
            return _context.Calendario.Any(e => e.Id == id);
        }

    }

}
