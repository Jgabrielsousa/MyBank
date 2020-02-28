using Microsoft.Extensions.DependencyInjection;
using MyBank.Credit.Domain.Interfaces;
using MyBank.Credit.Domain.Services;
using MyBank.Credit.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBank.Credit.Api
{
    public class Bootstrap
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICreditService, CreditService>();
            services.AddScoped<ICreditRepository, CreditRepository>();
        }
    }
}
