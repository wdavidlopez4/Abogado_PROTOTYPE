using Abogado.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Infrastructure.Persistencia
{
    public class AbogadoContext : DbContext
    {
        public DbSet<Caso> Casos { get; set; }

        public DbSet<Cita> Cita { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<HistoricoCaso> Historicos { get; set; }

        public AbogadoContext(DbContextOptions<AbogadoContext> options) : base(options)
        {

        }
    }
}
