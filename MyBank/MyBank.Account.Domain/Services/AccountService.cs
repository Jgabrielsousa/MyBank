using MyBank.Accounts.Domain.Entities;
using MyBank.Accounts.Domain.Interfaces.Repository;
using MyBank.Accounts.Domain.Interfaces.Services;
using MyBank.Shared.Domain.Services.Base;
using System;

namespace MyBank.Accounts.Domain.Services
{
    public class AccountService : ServiceBase<Account> , IAccountService
    {
        public AccountService(IAccountRepository repo) : base(repo) { }
      
        public void UpdateAmount(int accountId, decimal amount)
        {
            try
            {

                var item = _repo.Find(accountId);
                item.Balance = amount;
                _repo.Update(item);
            }
            catch (Exception erro)
            {

                throw erro;
            }
            

        }
    }
}
