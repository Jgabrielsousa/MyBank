using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyBank.Shared.Domain.Entities;
using MyBank.Transfers.Domain.Interfaces;
using MyBank.Transfers.Infra.Context;
using MyBank.Transfers.Infra.Repository.Base;

namespace MyBank.Transfers.Infra.Repository
{


    public class FinancialControlRepository : RepositoryBase<FinancialControl>, IFinancialControlRepository
    {

        public FinancialControlRepository(TransfersDbContext context) : base(context)
        { 
        }

        public void Credit(decimal balance,  decimal amount, int fromAccountId, int toAccountId)
        {
            var id = newId();
            context.Add(new FinancialControl()
            {
                Id = id,
                Amount = amount,
                Balance = balance,
                Type = "C",
                AccountId = fromAccountId
            });
            context.SaveChanges();
        }

        public void Debt(decimal balance,  decimal amount, int fromAccountId, int toAccountId)
        {
            var id = newId();
            context.Add(new FinancialControl()
            {
                Id = id,
                Amount = amount,
                Balance = balance,
                Type = "D",
                AccountId = fromAccountId
            });

            context.SaveChanges();
        }

        public IEnumerable<FinancialControl> GetByAccountId(int accountId)
        {
            return context.FinancialControls.Where(c => c.AccountId == accountId);
        }

        private int newId() => (context.FinancialControls.LastOrDefault()==null? 1: context.FinancialControls.LastOrDefault().Id + 1);
    }
}
