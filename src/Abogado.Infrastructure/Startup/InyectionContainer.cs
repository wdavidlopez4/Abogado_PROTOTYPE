using Abogado.Application;
using Abogado.Domain.Ports;
using Abogado.Infrastructure.Persistencia;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Infrastructure.Startup
{
    public class InyectionContainer
    {
        public static void Inyection(IServiceCollection services)
        {
            services.AddScoped<IRepository, RepositorySQL>();
            services.AddScoped<UsersServices>();
            services.AddScoped<CasosServices>();
            services.AddScoped<CitasServices>();
        }
    }
}
