using Abogado.Application;
using Abogado.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abogado.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsersServices services;

        public UsuarioController(UsersServices services)
        {
            this.services = services;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email,Password")] Usuario usuario)
        {
            var us = await this.services.Login(usuario.Email, usuario.Password);

            TempData["Tipo"] = us.TipoUsuario.GetHashCode();
            TempData["Email"] = us.Email;

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(
            [Bind("Nombre,Apellido,Email,Password,TipoUsuario")]  Usuario usuario)
        {
            TempData["Email"] = usuario.Email;
            TempData["Tipo"] = usuario.TipoUsuario.GetHashCode();

            await this.services.Register(usuario.Nombre, usuario.Apellido, 
                usuario.Email, usuario.Password, usuario.TipoUsuario);

            return View();
        }
    }
}
