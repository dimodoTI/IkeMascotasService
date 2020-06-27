using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MascotasApi.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MascotasApi.Helpers;


namespace MascotasApi.Controllers
{

    public class AtencionesQueryController : ControllerBase
    {
        private readonly MascotasContext _context;

        private readonly Permissions _permissions;

        public AtencionesQueryController(MascotasContext context)
        {
            _context = context;
            _permissions = new Permissions();
        }

        // GET: api/Mascotas

        [EnableQuery(MaxExpansionDepth = 3)]
        [AllowAnonymous]
        public IQueryable<Atenciones> Get()
        {

            IQueryable<Atenciones> atenciones;

            if (_permissions.isAdmin(this.User))
            {
                atenciones = _context.Atenciones.AsQueryable();
            }
            else
            {
                int idUsuario = _permissions.getUserId(this.User);
                atenciones = _context.Atenciones.Where(m => m.VeterinarioId == idUsuario).AsQueryable();
            }
            return atenciones;
        }
    }
}
