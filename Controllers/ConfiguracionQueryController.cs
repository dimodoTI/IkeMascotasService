using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MascotasApi.Models;
using Microsoft.AspNet.OData;

namespace MascotasApi.Controllers
{

    public class ConfiguracionQueryController : ControllerBase
    {
        private readonly MascotasContext _context;


        public ConfiguracionQueryController(MascotasContext context)
        {
            _context = context;

        }

        // GET: api/Mascotas

        [EnableQuery(MaxExpansionDepth = 3)]
        public IQueryable<Configuracion> Get()
        {

            IQueryable<Configuracion> configuracion = _context.Configuracion.AsQueryable();


            return configuracion;
        }
    }
}
