using Microsoft.Extensions.DependencyInjection;
using MyBank.Transfers.Domain.Interfaces;
using MyBank.Transfers.Domain.Services;
using MyBank.Transfers.Infra.Context;
using MyBank.Transfers.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBank.Transfers.Api
{
    public class Bootstrap
    {

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<TransfersDbContext>();
            services.AddScoped<IFinancialControlService, FinancialControlService>();
            services.AddScoped<IFinancialControlRepository, FinancialControlRepository>();
        }
    }
}
