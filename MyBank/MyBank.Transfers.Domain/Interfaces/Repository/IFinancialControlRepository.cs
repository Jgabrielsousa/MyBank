using MyBank.Shared.Domain.Interfaces.IRepository.Base;
using MyBank.Transfers.Domain.Entities;
using System.Collections.Generic;

namespace MyBank.Transfers.Domain.Interfaces
{
    public interface IFinancialControlRepository : IRepositoryBase<FinancialControl>
    {
        void Credit(decimal balance, decimal amount, int fromAccountId, int toAccountId);
        void Debt(decimal balance, decimal amount, int fromAccountId, int toAccountId);
        IEnumerable<FinancialControl> GetByAccountId(int accountId);
    }
}
