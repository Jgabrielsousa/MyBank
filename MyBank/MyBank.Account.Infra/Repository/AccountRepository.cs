using MyBank.Accounts.Domain.Interfaces.Repository;
using MyBank.Accounts.Infra.Context;
using MyBank.Accounts.Infra.Repository.Base;
using MyBank.Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBank.Accounts.Infra.Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(AccountDbContext context) : base(context)
        {
          
        }

        //public void LoadAddData() {

        //    var id = newId();
        //        context.Add(new Account()
        //        {
        //            Id = id ,
        //            UserId = 1,
        //            Balance = 100
        //        });                context.Add(new Account()
        //        {
        //            Id = ++id,
        //            UserId = 2,
        //            Balance = 200
        //        });
        //        context.SaveChanges();

            
           
        //}

        private int newId() => (context.Accounts.LastOrDefault() == null ? 1 : context.Accounts.LastOrDefault().Id + 1);


    }
}
