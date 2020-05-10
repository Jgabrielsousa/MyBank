using MyBank.Infra.CrossCutting;
using MyBank.Shared.Domain.Interfaces.IServices.Base;
using MyBank.Transfers.Domain.Entities;
using System.Collections.Generic;
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
