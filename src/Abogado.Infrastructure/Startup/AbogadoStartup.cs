using Abogado.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Infrastructure.Startup
{
    public class AbogadoStartup
    {
        public static void SetUp(IServiceCollection services, IConfiguration configuration)
        {
            InyectionContainer.Inyection(services);
            ConfigurationSqlServer(services, configuration);
        }

        /// <summary>
        /// configura el sql server
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        private static void ConfigurationSqlServer(IServiceCollection services, IConfiguration configuration)
        {
            // entity framework db context
            string connString = configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<AbogadoContext>(
                options => options.UseSqlServer(connString));
        }
    }
}
