using Microsoft.AspNetCore.Mvc;
using CRUDASP.Data;
using CRUDASP.Models;
using Microsoft.EntityFrameworkCore;
using CRUDASP.ViewModels;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

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
        public async Task<IActionResult> Registrarse(UsuarioVM modelo)
        {
            if (modelo.password != modelo.Confirmarpassword)
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            Usuario empleado = new Usuario()
            {
                Cedula = modelo.Cedula,
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                correo = modelo.correo,
                password = modelo.password,
                activo = true,
                administrador = false
            };

            await _appDBContext.Usuario.AddAsync(empleado);
            await _appDBContext.SaveChangesAsync();

            if(empleado.Cedula != "") return RedirectToAction("Login", "Acceso");

            ViewData["Mensaje"] = "No se pudo crear el usuario, error fatal";
            return View();
        }

        public IActionResult Login()
        {

            if (User.Identity!.IsAuthenticated) return RedirectToAction("Lista", "Usuario");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM modelo)
        {

            Usuario? usuario = await _appDBContext.Usuario.Where(e => e.Cedula == modelo.Cedula).FirstOrDefaultAsync();

            if (usuario == null)
            {
                ViewData["Mensaje"] = "El usuario no existe";
                return View();
            }
            if (usuario.password != modelo.password)
            {
                ViewData["Mensaje"] = "La contraseña es incorrecta";
                return View();
            }
            if (!usuario.activo)
            {
                ViewData["Mensaje"] = "El usuario no se encuentra activo!";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.GivenName, usuario.Nombre),
                new Claim(ClaimTypes.Name, usuario.Apellido),
                new Claim(ClaimTypes.Role, usuario.administrador ? "Admin": "User")
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties() {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
            );

            if (usuario.administrador != true) return RedirectToAction("Index", "Home");

            return RedirectToAction("Lista", "Usuario");


        }
    }
}
