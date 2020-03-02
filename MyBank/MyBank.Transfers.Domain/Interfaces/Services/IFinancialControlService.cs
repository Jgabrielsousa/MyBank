using MyBank.Infra.CrossCutting;
using MyBank.Shared.Domain.Entities;
using MyBank.Shared.Domain.Interfaces.IServices.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Transfers.Domain.Interfaces
{
    public interface IFinancialControlService : IServiceBase<FinancialControl>
    {
        Task<RequestResult> Credit(TransferDto transfer);
        Task<RequestResult> Debt(TransferDto transfer);

        IEnumerable<FinancialControl> GetByAccountId(int accountId);

    }
}
