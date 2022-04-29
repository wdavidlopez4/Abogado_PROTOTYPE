using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain
{
    public class Usuario : Entity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string Password { get; set; }
        public List<Caso> Casos { get; set; }
        public List<Cita> Citas { get; set; }
    }
}
