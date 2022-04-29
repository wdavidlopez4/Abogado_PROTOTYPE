using Abogado.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abogado.Web.Models
{
    public class CasoUsuarioVM
    {
        public Caso Caso { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public List<Caso> Casos { get; set; }
    }
}
