using MyBank.Accounts.Domain.Dtos;
using MyBank.Accounts.Domain.Interfaces.Repository;
using MyBank.Accounts.Domain.Interfaces.Services;
using MyBank.Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<AccountDto> GetAllDto()
        {
            var lista = new List<AccountDto>();
            lista.Add(new AccountDto() { Balance = 1, FinancialControlId = 1, UserId = 1 });
            lista.Add(new AccountDto() { Balance = 2, FinancialControlId = 2, UserId = 2 });
            lista.Add(new AccountDto() { Balance = 3, FinancialControlId = 3, UserId = 3 });
            return lista;
        }
    }
}
