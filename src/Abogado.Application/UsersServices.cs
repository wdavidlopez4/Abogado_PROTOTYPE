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

        public async Task<Usuario> Login(string correo, string password)
        {
            Usuario usuario = null;
            if (this.repository.Exists<Usuario>(x => x.Email == correo))
                usuario = await this.repository.Get<Usuario>(
                    x => x.Email == correo && x.Password == password);

            return usuario;
        }

        public bool Verificar(string correo, TipoUsuario tipoUsuario)
        {
            return this.repository.Exists<Usuario>(x => 
                x.Email == correo && x.TipoUsuario == tipoUsuario);
        }

        public async Task<List<Usuario>> Listar()
        {
            return await this.repository.GetAll<Usuario>();
        }

        public async Task Modificar(int id, string nombre, string apellido,
            string correo, string password, TipoUsuario tipoUsuario)
        {
            var usuario = await this.repository.Get<Usuario>(x => x.Id == id);

            usuario.Nombre = nombre;
            usuario.Apellido = apellido;
            usuario.Email = correo;
            usuario.Password = password;
            usuario.TipoUsuario = tipoUsuario;

            await this.repository.Update<Usuario>(usuario);
        }
    }
}
