using Microsoft.AspNetCore.Mvc;
using CRUDASP.Data;
using CRUDASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CRUDASP.Controllers
{

    [Authorize(Roles = "Admin")]
    public class UsuarioController : Controller
    {

        private readonly AppDBContext _appDbContext;
        public UsuarioController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Lista()
        {

            List<Usuario> lista = await _appDbContext.Usuario.ToListAsync();
            return View(lista);
        }
        public IActionResult Nuevo()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Nuevo(Usuario empleado)
        {
            await _appDbContext.Usuario.AddAsync(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        public async Task<IActionResult> Editar(string id)
        {
            Usuario empleado = await _appDbContext.Usuario.FirstAsync(e => e.Cedula == id);
            return View(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Usuario empleado)
        {
            _appDbContext.Usuario.Update(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        public async Task<IActionResult> Eliminar(string id)
        {
            Usuario empleado = await _appDbContext.Usuario.FirstAsync(e => e.Cedula == id);
            _appDbContext.Usuario.Remove(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
