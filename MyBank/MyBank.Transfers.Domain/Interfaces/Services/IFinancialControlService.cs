using MyBank.Shared.Domain.Entities;
using MyBank.Shared.Domain.Interfaces.IServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Transfers.Domain.Interfaces
{
    public interface IFinancialControlService : IServiceBase<FinancialControl>
    {
        void Credit(TransferDto transfer);
        void Debt(TransferDto transfer);

        IEnumerable<FinancialControl> GetByAccountId(int accountId);

    }
}
