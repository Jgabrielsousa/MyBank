using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBank.Accounts.Api
{
    public class Bootstrap
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //services.AddScoped<ICreditService, CreditService>();
            //services.AddScoped<ICreditRepository, CreditRepository>();
        }
    }
}
