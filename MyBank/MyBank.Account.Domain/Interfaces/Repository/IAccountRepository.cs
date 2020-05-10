using MyBank.Accounts.Domain.Entities;
using MyBank.Shared.Domain.Interfaces.IRepository.Base;

namespace MyBank.Accounts.Domain.Interfaces.Repository
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
      
    }
}
