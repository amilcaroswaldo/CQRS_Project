using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leave_management.Infraestructure
{
    public static class InfraestructureServiceRegistration
    {
        public static IServiceCollection ConfifureInfraestructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            return services;
        }
    }
}
