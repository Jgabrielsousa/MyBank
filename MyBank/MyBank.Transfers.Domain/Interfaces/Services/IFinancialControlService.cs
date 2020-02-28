using MyBank.Shared.Domain.Entities;
using MyBank.Shared.Domain.Interfaces.IServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Transfers.Domain.Interfaces
{
    public interface IFinancialControlService : IServiceBase<FinancialControl>
    {
        void Credit(int value, int OriginAccountId, int DestinyAccountId);
        void Debt(int value, int OriginAccountId, int DestinyAccountId);
    }
}
