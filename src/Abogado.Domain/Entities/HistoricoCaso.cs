using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Entities
{
    public class HistoricoCaso : Entity
    {
        public int CasoId { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public string NombreCaso { get; set; }

        public Proceso Proceso { get; set; }

        public FormaDivorcio FormaDivorcio { get; set; }

        public MecanismoDisolucion mecanismoDisolucion { get; set; }
    }
}
