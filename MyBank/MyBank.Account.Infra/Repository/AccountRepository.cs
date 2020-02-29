using MyBank.Accounts.Domain.Interfaces.Repository;
using MyBank.Accounts.Infra.Context;
using MyBank.Accounts.Infra.Repository.Base;
using MyBank.Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Accounts.Infra.Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(AccountDbContext context) : base(context)
        {
            try
            {
                context.Add(new Account()
                {
                    Id = 1,
                    UserId = 1,
                    Balance = 100,
                    FinancialControlId = 1
                });
                context.Add(new Account()
                {
                    Id = 2,
                    UserId = 2,
                    Balance = 200,
                    FinancialControlId = 2
                });
                context.SaveChanges();
            }
            catch (Exception)
            {

                
            }
            
        }

       
    }
}
