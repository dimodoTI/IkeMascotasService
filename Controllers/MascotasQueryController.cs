using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MascotasApi.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace MascotasApi.Controllers
{

    public class MascotasQueryController : ControllerBase
    {
        private readonly MascotasContext _context;

        public MascotasQueryController(MascotasContext context)
        {
            _context = context;
        }

        // GET: api/Mascotas

        [EnableQuery(MaxExpansionDepth = 3)]
        [AllowAnonymous]
        public IQueryable<Mascotas> Get()
        {

            System.Security.Claims.ClaimsPrincipal currentUser = this.User;

            int idUsuario;
            string rolUsuario = currentUser.Claims.First(r => r.Type == ClaimTypes.Role).Value;

            var res = int.TryParse(currentUser.Identity.Name, out idUsuario);

            IQueryable<Mascotas> mascotas;

            if (rolUsuario == "Admin")
            {
                mascotas = _context.Mascotas.AsQueryable();
            }
            else
            {
                mascotas = _context.Mascotas.Where(m => m.idUsuario == idUsuario).AsQueryable();
            }
            return mascotas;
        }
    }
}
