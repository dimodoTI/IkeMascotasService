using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MascotasApi.Models;
using Microsoft.AspNet.OData;

namespace MascotasApi.Controllers
{

    public class RazasQueryController : ControllerBase
    {
        private readonly MascotasContext _context;


        public RazasQueryController(MascotasContext context)
        {
            _context = context;

        }

        // GET: api/Mascotas

        [EnableQuery(MaxExpansionDepth = 3)]
        public IQueryable<Razas> Get()
        {

            IQueryable<Razas> razas = _context.Razas.AsQueryable();

            return razas;
        }
    }
}
