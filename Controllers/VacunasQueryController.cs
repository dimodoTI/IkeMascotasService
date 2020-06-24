using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MascotasApi.Models;
using Microsoft.AspNet.OData;

namespace MascotasApi.Controllers
{

    public class VacunasQueryController : ControllerBase
    {
        private readonly MascotasContext _context;


        public VacunasQueryController(MascotasContext context)
        {
            _context = context;

        }

        // GET: api/Mascotas

        [EnableQuery(MaxExpansionDepth = 3)]
        public IQueryable<Vacunas> Get()
        {

            IQueryable<Vacunas> vacunas = _context.Vacunas.AsQueryable();

            return vacunas;
        }
    }
}
