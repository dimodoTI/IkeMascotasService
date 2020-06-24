
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


    public class VacunasController : ControllerBase
    {
        private readonly MascotasContext _context;


        public VacunasController(MascotasContext context)
        {
            _context = context;

        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Put(int id, [FromBody] Vacunas vacunas)
        {
            if (id != vacunas.Id)
            {
                return BadRequest();
            }

            _context.Entry(vacunas).State = EntityState.Modified;

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

        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Vacunas> vacunasPatch)
        {


            Vacunas vacuna = await _context.Vacunas.FirstOrDefaultAsync(u => u.Id == id);

            if (vacuna == null)
            {
                return NotFound();
            }

            try
            {
                vacunasPatch.ApplyTo(vacuna);

                _context.Entry(vacuna).State = EntityState.Modified;

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
        public async Task<ActionResult<Vacunas>> Post(Vacunas vacuna)
        {


            _context.Vacunas.Add(vacuna);

            await _context.SaveChangesAsync();

            return Ok();
        }




        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Vacunas>> Delete(int id)
        {
            var vacuna = await _context.Vacunas.FindAsync(id);

            if (vacuna == null)
            {
                return NotFound();
            }

            _context.Vacunas.Remove(vacuna);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool Exists(int id)
        {
            return _context.Vacunas.Any(e => e.Id == id);
        }

    }

}
