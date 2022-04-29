using Abogado.Application;
using Abogado.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abogado.Web.Controllers
{
    public class CitaController: Controller
    {
        private readonly CitasServices citaServices;

        private readonly UsersServices Usersservices;

        private readonly IMemoryCache memoryCache;

        public CitaController(CitasServices citaServices, UsersServices Usersservices, IMemoryCache memoryCache)
        {
            this.citaServices = citaServices;
            this.Usersservices = Usersservices;
            this.memoryCache = memoryCache;
        }

        // GET: CitaController1
        public async Task<ActionResult> Index()
        {
            if (memoryCache.Get("TIPO") == null)
            {
                return RedirectToAction("Index", "Home");
            } 
            else if (memoryCache.Get("TIPO").ToString() == "3")
            {
                return RedirectToAction("Permisos", "Caso");
            }

            var vm = new CasoUsuarioVM();
            vm.Usuarios = await this.Usersservices.Listar();
            return View(vm);
        }


        // GET: CitaController1/Create
        public IActionResult CrearCita(string idUser)
        {
            TempData["USUARIO_ID_CITA"] = idUser;
            return View();
        }

        // POST: CitaController1/Create
        [HttpPost]
        public async Task <IActionResult> CrearCita(DateTime fecha)
        {
            var id = TempData["USUARIO_ID_CITA"].ToString();

            await this.citaServices.Asignar(int.Parse(id), fecha);

            return RedirectToAction("ListarCitas", "Cita");
        }

        // GET: CitaController1
        public async Task<ActionResult> ListarCitas()
        {
            var citas = await this.citaServices.Listar();
            return View(citas);
        }
    }
}
