using Microsoft.Extensions.DependencyInjection;
using MyBank.Accounts.Domain.Interfaces.Repository;
using MyBank.Accounts.Domain.Interfaces.Services;
using MyBank.Accounts.Domain.Services;
using MyBank.Accounts.Infra.Context;
using MyBank.Accounts.Infra.Repository;
using MyBank.Transfers.Domain.Interfaces;
using MyBank.Transfers.Domain.Services;
using MyBank.Transfers.Infra.Context;
using MyBank.Transfers.Infra.Repository;

namespace MyBank.Infra.IoC
{
    public static  class Bootstrap
    {
        public static void RegisterServicesUser(this IServiceCollection services)
        {
            //services.AddScoped<UserDbContext>();
            //services.AddScoped<IUserService,UserService>();
            //services.AddScoped<IUserRepository, UserRepository>();
        }
        public static void RegisterServicesAccount(this IServiceCollection services)
        {
            services.AddScoped<AccountDbContext>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountRepository, AccountRepository>(); 
        }
        public static void RegisterServicesTransfers(this IServiceCollection services)
        {
            services.AddScoped<TransfersDbContext>();
            services.AddScoped<IFinancialControlService, FinancialControlService>();
            services.AddScoped<IFinancialControlRepository, FinancialControlRepository>();
        }
    }
}
