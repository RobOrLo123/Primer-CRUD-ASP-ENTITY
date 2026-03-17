using Microsoft.AspNetCore.Mvc;
using CRUDASP.Data;
using CRUDASP.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDASP.Controllers
{
    public class EmpleadoController : Controller
    {

        private readonly AppDBContext _appDbContext;
        public EmpleadoController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Lista()
        {

            List<Empleado> lista = await _appDbContext.Empleados.ToListAsync();
            return View(lista);
        }
        public IActionResult Nuevo()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Nuevo(Empleado empleado)
        {
            await _appDbContext.Empleados.AddAsync(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        public async Task<IActionResult> Editar(string id)
        {
            Empleado empleado = await _appDbContext.Empleados.FirstAsync(e => e.Cedula == id);
            return View(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Empleado empleado)
        {
            _appDbContext.Empleados.Update(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        public async Task<IActionResult> Eliminar(string id)
        {
            Empleado empleado = await _appDbContext.Empleados.FirstAsync(e => e.Cedula == id);
            _appDbContext.Empleados.Remove(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
