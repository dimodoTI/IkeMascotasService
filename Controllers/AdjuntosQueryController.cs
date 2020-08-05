using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MascotasApi.Models;
using Microsoft.AspNet.OData;

namespace MascotasApi.Controllers
{

    public class AdjuntosQueryController : ControllerBase
    {
        private readonly MascotasContext _context;


        public AdjuntosQueryController(MascotasContext context)
        {
            _context = context;

        }

        // GET: api/Mascotas

        [EnableQuery(MaxExpansionDepth = 3)]
        public IQueryable<Adjuntos> Get()
        {

            IQueryable<Adjuntos> adjuntos = _context.Adjuntos.AsQueryable();

            return adjuntos;
        }
    }
}
