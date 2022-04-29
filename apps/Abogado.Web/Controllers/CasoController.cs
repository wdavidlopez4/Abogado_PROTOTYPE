using Abogado.Application;
using Abogado.Domain.Entities;
using Abogado.Web.Models;
using Microsoft.AspNetCore.Http;
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
        public IActionResult CrearCaso(string idUser)
        {
            TempData["USUARIO_ID"] = idUser;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearCaso([Bind("NombreCaso,Descripcion,FechaInicio,Proceso,FormaDivorcio,MecanismoDisolucion,Archivo")]
            string NombreCaso, string Descripcion, 
            DateTime FechaInicio, Proceso Proceso, FormaDivorcio FormaDivorcio,
            MecanismoDisolucion MecanismoDisolucion, IFormCollection Archivo)
        {
            string usuarioId = TempData["USUARIO_ID"].ToString();

            await this.CasoServices.Crear(
                NombreCaso: NombreCaso,
                Descripcion: Descripcion,
                FechaInicio: FechaInicio,
                Proceso: Proceso,
                FormaDivorcio: FormaDivorcio,
                mecanismoDisolucion: MecanismoDisolucion,
                archivo: Archivo.Files.FirstOrDefault(),
                UsuarioId: int.Parse(usuarioId));

            return RedirectToAction("ListarCasos", "Caso");
        }

        [HttpGet]
        public async Task<IActionResult> ListarCasos()
        {
            var vm = new CasoUsuarioVM();
            vm.Casos = await this.CasoServices.Listar();

            return View(vm);
        }


        [HttpGet]
        public async Task<IActionResult> ModificarCaso()
        {
            var vm = new CasoUsuarioVM();
            vm.Casos = await this.CasoServices.Listar();

            return View(vm);
        }

        [HttpGet]
        public IActionResult ModificarCasoConfirmacion(string idCaso)
        {
            TempData["CASO_ID"] = idCaso;
            return View();
        }

        [HttpGet]
        public IActionResult ModificarCasoFrm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ModificarCasoFrm([Bind("NombreCaso,Descripcion,FechaInicio,Proceso,FormaDivorcio,MecanismoDisolucion,Archivo")]
            string NombreCaso, string Descripcion,
            DateTime FechaInicio, Proceso Proceso, FormaDivorcio FormaDivorcio,
            MecanismoDisolucion MecanismoDisolucion, IFormCollection Archivo)
        {
            string casoId = TempData["CASO_ID"].ToString();

            var caso = await this.CasoServices.Consultar(casoId);

            await this.CasoServices.Monificar(
                idCaso: int.Parse(casoId),
                NombreCaso: NombreCaso,
                Descripcion: Descripcion,
                FechaInicio: FechaInicio,
                Proceso: Proceso,
                FormaDivorcio: FormaDivorcio,
                mecanismoDisolucion: MecanismoDisolucion,
                archivo: Archivo.Files.FirstOrDefault(),
                UsuarioId: caso.UsuarioId.Value);

            return RedirectToAction("ListarCasos", "Caso");
        }
    }
}
