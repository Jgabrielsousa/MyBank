using MyBank.Accounts.Domain.Entities;
using MyBank.Shared.Domain.Interfaces.IServices.Base;

namespace MyBank.Accounts.Domain.Interfaces.Services
{
    public interface IAccountService : IServiceBase<Account>
    {
        void UpdateAmount(int accountId, decimal amount);
    }
}
