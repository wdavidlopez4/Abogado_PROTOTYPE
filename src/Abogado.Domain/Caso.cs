using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain
{
    public class Caso : Entity
    {
        public string NombreCaso { get; set; }
        public string? Descripcion { get; set; }
        public Proceso Proceso { get; set; }
        public FormaDivorcio FormaDivorcio { get; set; }
        public MecanismoDisolucion mecanismoDisolucion { get; set; }
        public string? Archivo { get; set; }
        public DateTime? FechaInicio { get; set; }
        public int? UsuarioId { get; set; }
    }
}
