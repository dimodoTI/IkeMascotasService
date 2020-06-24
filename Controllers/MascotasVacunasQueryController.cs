using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MascotasApi.Models;
using Microsoft.AspNet.OData;
using MascotasApi.Helpers;

namespace MascotasApi.Controllers
{

    public class MascotasVacunasQueryController : ControllerBase
    {
        private readonly MascotasContext _context;
        private readonly Permissions _permissions;


        public MascotasVacunasQueryController(MascotasContext context)
        {
            _context = context;
            _permissions = new Permissions();

        }

        // GET: api/Mascotas

        [EnableQuery(MaxExpansionDepth = 3)]
        public IQueryable<MascotasVacunas> Get()
        {
            IQueryable<MascotasVacunas> mascotasVacunas = null;

            int idUsurio = _permissions.getUserId(this.User);

            if (_permissions.isAdmin(this.User))
            {
                mascotasVacunas = _context.MascotasVacunas.AsQueryable();
            }
            else
            {
                mascotasVacunas = _context.MascotasVacunas.Where(f => f.Mascota.idUsuario == idUsurio).AsQueryable();
            }
            return mascotasVacunas;
        }
    }
}
