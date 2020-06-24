using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MascotasApi.Models;
using Microsoft.AspNet.OData;

namespace MascotasApi.Controllers
{

    public class MascotasTipoQueryController : ControllerBase
    {
        private readonly MascotasContext _context;


        public MascotasTipoQueryController(MascotasContext context)
        {
            _context = context;

        }

        // GET: api/Mascotas

        [EnableQuery(MaxExpansionDepth = 3)]
        public IQueryable<MascotasTipo> Get()
        {

            IQueryable<MascotasTipo> mascotasTipo = _context.MascotasTipo.AsQueryable();


            return mascotasTipo;
        }
    }
}
