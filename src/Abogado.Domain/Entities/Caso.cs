using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Entities
{
    public class Caso : Entity
    {
        public string NombreCaso { get; set; }
        public string? Descripcion { get; set; }
        public Proceso Proceso { get; set; }
        public FormaDivorcio FormaDivorcio { get; set; }
        public MecanismoDisolucion mecanismoDisolucion { get; set; }
        public string? RutaArchivo { get; set; }
        [NotMapped]
        public IFormFile Archivo { get; set; }
        public DateTime? FechaInicio { get; set; }
        public int? UsuarioId { get; set; }

        public List<HistoricoCaso> Historicos { get; set; }
    }
}
