using Microsoft.Extensions.DependencyInjection;
using MyBank.Infra.Data.Context;
using MyBank.Infra.Data.Repository;
using MyBank.Shared.Domain.Interfaces.IRepository;
using MyBank.Shared.Domain.Interfaces.IServices;
using MyBank.Shared.Domain.Services;
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
        }
    }
}
