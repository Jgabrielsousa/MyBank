using Microsoft.Extensions.DependencyInjection;
using MyBank.Accounts.Domain.Interfaces.Repository;
using MyBank.Accounts.Domain.Interfaces.Services;
using MyBank.Accounts.Domain.Services;
using MyBank.Accounts.Infra.Context;
using MyBank.Accounts.Infra.Repository;
using MyBank.Infra.Data.Context;
using MyBank.Infra.Data.Repository;
using MyBank.Shared.Domain.Interfaces.IRepository;
using MyBank.Shared.Domain.Interfaces.IServices;
using MyBank.Shared.Domain.Services;
using MyBank.Transfers.Domain.Interfaces;
using MyBank.Transfers.Domain.Services;
using MyBank.Transfers.Infra.Context;
using MyBank.Transfers.Infra.Repository;
using System;

namespace MyBank.Infra.IoC
{
    public class Bootstrap
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<MyBankContext>();

            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddTransient<AccountDbContext>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<TransfersDbContext>();
            services.AddScoped<IFinancialControlService, FinancialControlService>();
            services.AddScoped<IFinancialControlRepository, FinancialControlRepository>();
        }
    }
}
