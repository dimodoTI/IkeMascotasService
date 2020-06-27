using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MascotasApi.Models;
using Microsoft.AspNet.OData;

namespace MascotasApi.Controllers
{

    public class PuestosQueryController : ControllerBase
    {
        private readonly MascotasContext _context;


        public PuestosQueryController(MascotasContext context)
        {
            _context = context;

        }

        // GET: api/Mascotas

        [EnableQuery(MaxExpansionDepth = 3)]
        public IQueryable<Puestos> Get()
        {

            IQueryable<Puestos> puestos = _context.Puestos.AsQueryable();


            return puestos;
        }
    }
}
