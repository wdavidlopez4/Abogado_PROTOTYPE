using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Application
{
    public class UsersServices
    {
        private readonly IRepository repository;

        public UsersServices(IRepository repository)
        {
            //inyection container
            this.repository = repository;
        }

        public async Task Register(string nombre, string apellido,
            string correo, string password, TipoUsuario tipoUsuario)
        {
            var user = new Usuario
            {
                Nombre = nombre,
                Apellido = apellido,
                Email = correo,
                Password = password,
                TipoUsuario = tipoUsuario
            };

            await this.repository.Save<Usuario>(user);
        }

        public bool Login(string correo, string password)
        {
            return this.repository.Exists<Usuario>(x => 
                x.Email == correo &&
                x.Password == password);
        }

        public bool Verificar(string correo, TipoUsuario tipoUsuario)
        {
            return this.repository.Exists<Usuario>(x => 
                x.Email == correo && x.TipoUsuario == tipoUsuario);
        }
    }
}
