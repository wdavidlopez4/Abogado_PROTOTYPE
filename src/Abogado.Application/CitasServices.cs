using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application
{
    public class CitasServices
    {
        private readonly IRepository repository;

        public CitasServices(IRepository repository)
        {
            //inyection container
            this.repository = repository;
        }

        public async Task Asignar(int UsuarioId, DateTime? Fecha)
        {
            await this.repository.Save<Cita>(
                new Cita { UsuarioId = UsuarioId, Fecha = Fecha });
        }

        public async Task<List<Cita>> Listar()
        {
            return await this.repository.GetAll<Cita>();
        }
    }
}
