using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application
{
    public class HistoricosServices
    {
        private readonly IRepository repository;

        public HistoricosServices(IRepository repository)
        {
            //inyection container
            this.repository = repository;
        }

        public async Task Crear(int CasoId, string Descripcion, DateTime Fecha, string NombreCaso,
            Proceso Proceso, FormaDivorcio FormaDivorcio, MecanismoDisolucion mecanismoDisolucion)
        {
            var historico = new HistoricoCaso
            {
                NombreCaso = NombreCaso,
                Descripcion = Descripcion,
                Proceso = Proceso,
                FormaDivorcio = FormaDivorcio,
                mecanismoDisolucion = mecanismoDisolucion,
                CasoId = CasoId,
                Fecha = Fecha
            };

            await this.repository.Save<HistoricoCaso>(historico);
        }

        public async Task<List<HistoricoCaso>> Listar(int CasoId)
        {
            return await this.repository.GetAll<HistoricoCaso>(
                x => x.CasoId == CasoId);
        }
    }
}
