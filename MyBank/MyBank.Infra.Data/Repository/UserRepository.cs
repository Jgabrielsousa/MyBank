using MyBank.Infra.Data.Context;
using MyBank.Infra.Data.Repository.Base;
using MyBank.Shared.Domain.Entities;
using MyBank.Shared.Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Infra.Data.Repository
{
   public  class UserRepository   : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MyBankContext context) : base(context)
        {
            base.context.Add(new User("Joao") { Id = 1});
            base.context.Add(new User("Joao1") { Id = 2});


            //contexto.Add(new Account()
            //{
            //    Id = 1,
            //    UserId = 1,
            //    Balance= 100,
            //    FinancialControlId = 1
            //});
            //contexto.Add(new Account()
            //{
            //    Id = 2,
            //    UserId = 2,
            //    Balance = 200,
            //    FinancialControlId = 2
            //});

           

            base.context.SaveChanges();


        }
    }
}
