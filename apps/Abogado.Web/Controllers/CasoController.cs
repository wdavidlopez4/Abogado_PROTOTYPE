using Abogado.Application;
using Abogado.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abogado.Web.Controllers
{
    public class CasoController : Controller
    {
        private readonly CasosServices CasoServices;

        private readonly UsersServices Usersservices;

        public CasoController(CasosServices services, UsersServices Usersservices)
        {
            this.CasoServices = services;
            this.Usersservices = Usersservices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (TempData["Tipo"] == null)
                return RedirectToAction("Index", "Home");
            else if (TempData["Tipo"].ToString() == "0")
                return View();
            
            return RedirectToAction("Permisos", "Caso");
        }

        [HttpGet]
        public async Task<IActionResult> SeleccionarUsuario()
        {
            var vm = new CasoUsuarioVM();
            vm.Usuarios = await this.Usersservices.Listar();

            return View(vm);
        }

        [HttpGet]
        public IActionResult CrearCaso()
        {
            return View();
        }


    }
}
