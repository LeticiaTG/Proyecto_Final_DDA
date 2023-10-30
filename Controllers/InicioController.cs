using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_DDA.Models;
using Proyecto_Final_DDA.Recursos;
using Proyecto_Final_DDA.Servicios.Contrato;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Proyecto_Final_DDA.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioServico;
        public InicioController(IUsuarioService usuarioService)
        {
            
            _usuarioServico = usuarioService;   
            
        }
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Registrarse(Usuario modelo)
        {
            modelo.Clave = Utilidades.EncriptarClave(modelo.Clave);

            Usuario usuario_creado = await_usuarioServicio.SaveUsuario(modelo);

            if(usuario_creado.IdUsuario>0)
                return RedirectToAction("IniciarSesion","Inicio");

            ViewData["Mensaje"] = "No se pudo crear el usuario";

            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>IniciarSesion(string correo, string clave)
        {
            Usuario usuario_encontrado = await_usuarioServicio.GetUsuario(correo, Utilidades.EncriptarClave(clave));

            if(usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencias";
                return View();
            }

            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, usuario_encontrado.NombreUsuario)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            { 
                AllowRefresh = true   
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );
            return RedirectToAction("Index", "Home");

        }
    }
}
