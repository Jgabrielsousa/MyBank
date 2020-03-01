using MyBank.Accounts.Domain.Interfaces.Repository;
using MyBank.Shared.Domain.Entities;
using MyBank.Transfers.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Transfers.Domain.Services
{
    public class FinancialControlService : IFinancialControlService
    {
        private readonly IFinancialControlRepository _repoFC;
        private readonly IAccountRepository _repoAcc;

        public FinancialControlService(IFinancialControlRepository repoFC, IAccountRepository repoAcc)
        {
            _repoFC = repoFC;
            _repoAcc = repoAcc;
        }

        public void Credit(TransferDto transfer)
        {
            var toAccount = _repoAcc.Find(transfer.FromAccountId);
            toAccount.Balance += transfer.Amount;
            _repoAcc.Update(toAccount);
            _repoFC.Credit(toAccount.Balance ,transfer.Amount, transfer.FromAccountId, transfer.ToAccountId);
        }

        public void Debt(TransferDto transfer)
        {
            var fromAccount = _repoAcc.Find(transfer.FromAccountId);
            fromAccount.Balance -= transfer.Amount;
            _repoAcc.Update(fromAccount);
            _repoFC.Debt(fromAccount.Balance ,transfer.Amount, transfer.FromAccountId, transfer.ToAccountId);
        }
        public FinancialControl Add(FinancialControl entidade)
        {
            return _repoFC.Add(entidade);
        }

        public FinancialControl Find(long id)
        {
            return _repoFC.Find(id);
        }

        public IEnumerable<FinancialControl> GetAll()
        {
            return _repoFC.GetAll();
        }

        public void Remove(FinancialControl entidade)
        {
            _repoFC.Remove(entidade);
        }

        public void Update(FinancialControl entidade)
        {
            _repoFC.Update(entidade);
        }
        public void Dispose()
        {

        }

        public IEnumerable<FinancialControl> GetByAccountId(int id)
        {
            return _repoFC.GetByAccountId(id);
        }
    }
}
