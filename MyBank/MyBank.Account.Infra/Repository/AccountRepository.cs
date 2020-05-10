using MyBank.Accounts.Domain.Entities;
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

        private int newId() => (context.Accounts.LastOrDefault() == null ? 1 : context.Accounts.LastOrDefault().Id + 1); 


    }
}
