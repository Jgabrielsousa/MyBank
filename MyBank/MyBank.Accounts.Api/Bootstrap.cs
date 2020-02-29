using Microsoft.Extensions.DependencyInjection;
using MyBank.Accounts.Domain.Interfaces.Repository;
using MyBank.Accounts.Domain.Interfaces.Services;
using MyBank.Accounts.Domain.Services;
using MyBank.Accounts.Infra.Context;
using MyBank.Accounts.Infra.Repository;
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
            services.AddScoped<AccountDbContext>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
