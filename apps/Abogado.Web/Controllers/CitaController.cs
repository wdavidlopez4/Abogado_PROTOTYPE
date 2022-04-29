using Abogado.Application;
using Abogado.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public CitaController(CitasServices citaServices, UsersServices Usersservices)
        {
            this.citaServices = citaServices;
            this.Usersservices = Usersservices;
        }

        // GET: CitaController1
        public async Task<ActionResult> Index()
        {
            var vm = new CasoUsuarioVM();
            vm.Usuarios = await this.Usersservices.Listar();
            return View(vm);
        }


        // GET: CitaController1/Create
        public IActionResult CrearCita(string idUser)
        {
            TempData["USUARIO_ID"] = idUser;
            return View();
        }

        // POST: CitaController1/Create
        [HttpPost]
        public async Task <IActionResult> CrearCita(DateTime fecha)
        {
            var id = TempData["USUARIO_ID"].ToString();

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
