using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MascotasApi.Models;
using Microsoft.AspNet.OData;

namespace MascotasApi.Controllers
{

    public class CalendarioQueryController : ControllerBase
    {
        private readonly MascotasContext _context;


        public CalendarioQueryController(MascotasContext context)
        {
            _context = context;

        }

        // GET: api/Mascotas

        [EnableQuery(MaxExpansionDepth = 3)]
        public IQueryable<Calendario> Get()
        {

            IQueryable<Calendario> calendario = _context.Calendario.AsQueryable();

            return calendario;
        }
    }
}
