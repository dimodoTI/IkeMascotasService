
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MascotasApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using MascotasApi.Handlers.Turnos;

namespace MascotasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class TurnosDisponiblesController : ControllerBase
    {
        private readonly MascotasContext _context;
        private readonly IMediator _mediatr;


        public TurnosDisponiblesController(MascotasContext context, IMediator mediatr)
        {
            _context = context;
            _mediatr = mediatr;

        }


        [HttpGet()]
        public async Task<ActionResult> get()
        {
            return Ok(await _mediatr.Send(new TurnosDisponiblesCommand()));
        }
    }
}
