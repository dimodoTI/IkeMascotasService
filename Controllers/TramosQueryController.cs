using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MascotasApi.Models;
using Microsoft.AspNet.OData;

namespace MascotasApi.Controllers
{

    public class TramosQueryController : ControllerBase
    {
        private readonly MascotasContext _context;


        public TramosQueryController(MascotasContext context)
        {
            _context = context;

        }

        // GET: api/Mascotas

        [EnableQuery(MaxExpansionDepth = 3)]
        public IQueryable<Tramos> Get()
        {

            IQueryable<Tramos> tramos = _context.Tramos.AsQueryable();


            return tramos;
        }
    }
}
