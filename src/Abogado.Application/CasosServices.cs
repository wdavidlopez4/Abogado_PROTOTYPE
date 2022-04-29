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

        public CasosServices(IRepository repository)
        {
            //inyection container
            this.repository = repository;
        }

        public async Task Crear(string NombreCaso, string Descripcion, Proceso Proceso,
            FormaDivorcio FormaDivorcio, MecanismoDisolucion mecanismoDisolucion,
            string? Archivo, DateTime? FechaInicio, int UsuarioId, IFormFile archivo)
        {
            await SubirArchivo(archivo);

            var caso = new Caso 
            { 
                NombreCaso = NombreCaso,
                Descripcion = Descripcion,
                Proceso = Proceso,
                FormaDivorcio = FormaDivorcio,
                mecanismoDisolucion = mecanismoDisolucion,
                Archivo = Archivo,
                FechaInicio = FechaInicio,
                UsuarioId = UsuarioId
            };
            await this.repository.Save<Caso>(caso);
        }

        public async Task Monificar(string NombreCaso, string Descripcion, Proceso Proceso,
            FormaDivorcio FormaDivorcio, MecanismoDisolucion mecanismoDisolucion,
            string? Archivo, DateTime? FechaInicio, int UsuarioId, IFormFile archivo)
        {
            await SubirArchivo(archivo);

            var caso = new Caso
            {
                NombreCaso = NombreCaso,
                Descripcion = Descripcion,
                Proceso = Proceso,
                FormaDivorcio = FormaDivorcio,
                mecanismoDisolucion = mecanismoDisolucion,
                Archivo = Archivo,
                FechaInicio = FechaInicio,
                UsuarioId = UsuarioId
            };
            await this.repository.Update<Caso>(caso);
        }

        public async Task<List<Caso>> Listar()
        {
            return await this.repository.GetAll<Caso>();
        }

        public async Task<Caso> Consultar(string id)
        {
            return await this.repository.Get<Caso>(id);
        }

        private async static Task SubirArchivo(IFormFile archivo)
        {
            Random rnd = new Random();
            int rndx = rnd.Next(0, 1000000);

            string ruta = Path.Combine(Directory.GetCurrentDirectory(), "CasosPDF", rndx + ".pdf");

            using var stream = new FileStream(ruta, FileMode.Create);
            await archivo.CopyToAsync(stream);
        }
    }
}
