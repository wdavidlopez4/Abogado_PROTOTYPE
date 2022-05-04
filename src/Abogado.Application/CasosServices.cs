using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application
{
    public class CasosServices
    {
        private readonly IRepository repository;

        private readonly HistoricosServices historicosServices;

        public CasosServices(IRepository repository, HistoricosServices historicosServices)
        {
            //inyection container
            this.repository = repository;
            this.historicosServices = historicosServices;
        }

        public async Task Crear(string NombreCaso, string Descripcion, Proceso Proceso,
            FormaDivorcio FormaDivorcio, MecanismoDisolucion mecanismoDisolucion,
            DateTime? FechaInicio, int UsuarioId, IFormFile archivo)
        {
            var caso = new Caso 
            { 
                NombreCaso = NombreCaso,
                Descripcion = Descripcion,
                Proceso = Proceso,
                FormaDivorcio = FormaDivorcio,
                mecanismoDisolucion = mecanismoDisolucion,
                RutaArchivo = await SubirArchivo(archivo),
                FechaInicio = FechaInicio,
                UsuarioId = UsuarioId
            };

            await this.repository.Save<Caso>(caso);

            await this.historicosServices.Crear(CasoId: caso.Id, Descripcion: caso.Descripcion,
                Fecha: caso.FechaInicio.Value, NombreCaso: caso.NombreCaso, Proceso: caso.Proceso,
                FormaDivorcio: caso.FormaDivorcio, mecanismoDisolucion: mecanismoDisolucion);
        }

        public async Task Monificar(int idCaso, string NombreCaso, string Descripcion, Proceso Proceso,
            FormaDivorcio FormaDivorcio, MecanismoDisolucion mecanismoDisolucion,
            DateTime? FechaInicio, int UsuarioId, IFormFile archivo)
        {
            var caso = new Caso
            {
                Id = idCaso,
                NombreCaso = NombreCaso,
                Descripcion = Descripcion,
                Proceso = Proceso,
                FormaDivorcio = FormaDivorcio,
                mecanismoDisolucion = mecanismoDisolucion,
                RutaArchivo = await SubirArchivo(archivo),
                FechaInicio = FechaInicio,
                UsuarioId = UsuarioId
            };
            await this.repository.Update<Caso>(caso);

            await this.historicosServices.Crear(CasoId: caso.Id, Descripcion: caso.Descripcion,
                Fecha: caso.FechaInicio.Value, NombreCaso: caso.NombreCaso, Proceso: caso.Proceso,
                FormaDivorcio: caso.FormaDivorcio, mecanismoDisolucion: mecanismoDisolucion);
        }

        public async Task<List<Caso>> Listar()
        {
            return await this.repository.GetAll<Caso>();
        }

        public async Task<Caso> Consultar(string id)
        {
            return await this.repository.Get<Caso>(id);
        }

        private async static Task<String> SubirArchivo(IFormFile archivo)
        {
            Random rnd = new Random();
            int rndx = rnd.Next(0, 1000000);

            string ruta = Path.Combine(Directory.GetCurrentDirectory(), "CasosPDF", rndx + ".pdf");

            using var stream = new FileStream(ruta, FileMode.Create);
            await archivo.CopyToAsync(stream);

            return ruta;
        }
    }
}
