using Microsoft.AspNetCore.Mvc;
using CRUDASP.Data;
using CRUDASP.Models;
using Microsoft.EntityFrameworkCore;
using CRUDASP.ViewModels;

namespace CRUDASP.Controllers
{
    public class AccesoController : Controller
    {

        private readonly AppDBContext _appDBContext;

        public AccesoController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(EmpleadoVM modelo)
        {
            if (modelo.password != modelo.Confirmarpassword)
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            Empleado empleado = new Empleado()
            {
                Cedula = modelo.Cedula,
                NombreCompleto = modelo.NombreCompleto,
                correo = modelo.correo,
                password = modelo.password,
                FechaContrato = DateOnly.FromDateTime(DateTime.Now),
                activo = false,
                administrador = false
            };

            await _appDBContext.Empleados.AddAsync(empleado);
            await _appDBContext.SaveChangesAsync();

            if(empleado.Cedula != "") return RedirectToAction("Login", "Acceso");

            ViewData["Mensaje"] = "No se pudo crear el usuario, error fatal";
            return View();
        }
    }
}
