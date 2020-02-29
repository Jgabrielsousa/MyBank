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
            context.Add(new FinancialControl()
            {
                Id = 1,
                Value = 100,
                Type = "C",
                AccountId = 1
            });
            context.Add(new FinancialControl()
            {
                Id = 2,
                Value = 100,
                Type = "C",
                AccountId = 1
            });
            context.Add(new FinancialControl()
            {
                Id = 3,
                Value = 50,
                Type = "D",
                AccountId = 1
            });

            context.SaveChanges();

        }

        public void Credit(int value, int OriginAccountId, int DestinyAccountId)
        {
            context.Add(new FinancialControl()
            {
                Id = 1,
                Value = value,
                Type = "C",
                AccountId = OriginAccountId
            });
            context.SaveChanges();
        }

        public void Debt(int value, int OriginAccountId, int DestinyAccountId)
        {
            //var account=   context.FinancialControls.Where(c => c.AccountId == accountId).FirstOrDefault();

            context.Add(new FinancialControl()
            {
                Id = 1,
                Value = value,
                Type = "D",
                AccountId = OriginAccountId
            });

            context.SaveChanges();
        }
    }
}
