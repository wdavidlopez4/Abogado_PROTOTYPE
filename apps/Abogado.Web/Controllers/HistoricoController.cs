using Abogado.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abogado.Web.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly HistoricosServices services;

        public HistoricoController(HistoricosServices services)
        {
            this.services = services;
        }

        public async Task<IActionResult> Index(int CasoId)
        {
            var historicos = await services.Listar(CasoId);

            return View(historicos);
        }
    }
}
