using leave_management.Application.Contracts.Persistence;
using leave_management.Persistance.DataBaseContext;
using leave_management.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leave_management.Persistance
{
    public static class PersistanceServiceRegitration
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContextPg>(options =>
                options.UseNpgsql(configuration.GetConnectionString("pg-connString")));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            return services;
        }
    }
}
