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
            try
            {
                if (!context.Accounts.Any())
                {

                    context.Add(new Account()
                    {
                        Id = 1,
                        UserId = 1,
                        Balance = 100
                    });
                    context.Add(new Account()
                    {
                        Id = 2,
                        UserId = 2,
                        Balance = 200
                    });
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                
            }
            
        }

       
    }
}
