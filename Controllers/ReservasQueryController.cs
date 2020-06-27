using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MascotasApi.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MascotasApi.Helpers;


namespace MascotasApi.Controllers
{

    public class ReservasQueryController : ControllerBase
    {
        private readonly MascotasContext _context;

        private readonly Permissions _permissions;

        public ReservasQueryController(MascotasContext context)
        {
            _context = context;
            _permissions = new Permissions();
        }

        // GET: api/Mascotas

        [EnableQuery(MaxExpansionDepth = 3)]
        [AllowAnonymous]
        public IQueryable<Reservas> Get()
        {

            IQueryable<Reservas> reservas;

            if (_permissions.isAdmin(this.User))
            {
                reservas = _context.Reservas.AsQueryable();
            }
            else
            {
                int idUsuario = _permissions.getUserId(this.User);
                reservas = _context.Reservas.Where(m => m.UsuarioId == idUsuario).AsQueryable();
            }
            return reservas;
        }
    }
}
