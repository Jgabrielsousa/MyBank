using MyBank.Shared.Domain.Entities;
using MyBank.Shared.Domain.Interfaces.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Transfers.Domain.Interfaces
{
    public interface IFinancialControlRepository : IRepositoryBase<FinancialControl>
    {
        void Credit(decimal balance, decimal amount, int fromAccountId, int toAccountId);
        void Debt(decimal balance, decimal amount, int fromAccountId, int toAccountId);
        IEnumerable<FinancialControl> GetByAccountId(int accountId);
    }
}
