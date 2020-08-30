
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MascotasApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using MascotasApi.Helpers;
using Microsoft.Extensions.Configuration;


namespace MascotasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdjuntosController : ControllerBase
    {
        private readonly MascotasContext _context;
        private readonly Permissions _permissions;

        private readonly IConfiguration _configuration;


        public AdjuntosController(MascotasContext context, IConfiguration configuration)
        {
            _context = context;

            _permissions = new Permissions();

            _configuration = configuration;
        }


        [HttpPut("{id}")]

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
        public async Task<ActionResult<Adjuntos>> Post(Adjuntos adjuntos)
        {


            _context.Adjuntos.Add(adjuntos);

            await _context.SaveChangesAsync();

            return Ok();
        }




        [HttpDelete("{id}")]
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

        [HttpPost("UploadFile")]
        public async Task<ActionResult> UploadFile()
        {

            int UsuarioId = _permissions.getUserId(this.User);

            if (UsuarioId == 0) return Forbid();

            int ReservaId = 0;

            Int32.TryParse(Request.Form["ReservaId"][0], out ReservaId);

            string perfil = _permissions.getUserRol(this.User);

            IFormFile file = Request.Form.Files[0];

            string originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

            originalFileName = this.EnsureCorrectFilename(originalFileName);

            string[] partes = originalFileName.Split(".");

            string extension = "";

            if (partes.Length > 1)
            {
                extension = partes.Last();
            }

            if (extension == "") return Forbid();

            AppSettings appSettings = new AppSettings();
            _configuration.GetSection("AppSettings").Bind(appSettings);

            String filename = Guid.NewGuid().ToString() + "." + extension;
            using (FileStream output = System.IO.File.Create("uploads/" + filename))
                await file.CopyToAsync(output);

            Adjuntos adjunto = new Adjuntos();
            adjunto.ReservaId = ReservaId;
            adjunto.UsuarioId = UsuarioId;
            adjunto.Nombre = originalFileName;
            adjunto.Tipo = extension;
            adjunto.Perfil = perfil;
            adjunto.Url = appSettings.uploadsURL + filename;
            adjunto.Activo = true;

            _context.Adjuntos.Add(adjunto);

            await _context.SaveChangesAsync();

            return Ok();

        }

        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }

        private string GetPathAndFilename(string filename)
        {
            return ".\\uploads\\" + filename;
        }

    }


}
