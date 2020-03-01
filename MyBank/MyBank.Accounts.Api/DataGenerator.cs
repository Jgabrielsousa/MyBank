using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBank.Accounts.Domain.Interfaces.Services;
using MyBank.Accounts.Infra.Context;
using MyBank.Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBank.Accounts.Api
{
    //public class DataGenerator
    //{

    //    public static void Initialize(IServiceProvider serviceProvider)
    //    {
    //        var service = serviceProvider.GetRequiredService<IAccountService>();
    //        service.Add(new Account()
    //            {
    //                Id = 1,
    //                UserId = 1,
    //                Balance = 100
                    
    //            });
    //        service.Add(new Account()
    //            {
    //                Id = 2,
    //                UserId = 2,
    //                Balance = 200
    //            });
            
    //    }
    //}
}
