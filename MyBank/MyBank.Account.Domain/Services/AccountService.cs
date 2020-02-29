using MyBank.Accounts.Domain.Interfaces.Repository;
using MyBank.Accounts.Domain.Interfaces.Services;
using MyBank.Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Accounts.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;
        public AccountService(IAccountRepository repo)
        {
            _repo = repo;
        }
        public Account Add(Account entidade)
        {
            return _repo.Add(entidade);
        }

        public Account Find(long id)
        {
            return _repo.Find(id);
        }

        public IEnumerable<Account> GetAll()
        {
            return _repo.GetAll();
        }

        public void Remove(Account entidade)
        {
            _repo.Remove(entidade);
        }

        public void Update(Account entidade)
        {
            _repo.Update(entidade);
        }
        public void Dispose()
        {

        }
    }
}
