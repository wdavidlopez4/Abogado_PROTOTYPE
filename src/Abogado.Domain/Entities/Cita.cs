using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Entities
{
    public class Cita : Entity
    {
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
