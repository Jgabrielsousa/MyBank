using System;
using System.Collections.Generic;
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
            context.Add(new Account()
            {
                Id = 1,
                UserId = 1,
                Balance = 100,
                FinancialControlId = 1
            });
            context.Add(new Account()
            {
                Id = 2,
                UserId = 2,
                Balance = 200,
                FinancialControlId = 2
            });
            context.SaveChanges();

        }

        public void Credit(int value, int OriginAccountId, int DestinyAccountId)
        {
            throw new NotImplementedException();
        }

        public void Debt(int value, int OriginAccountId, int DestinyAccountId)
        {
            throw new NotImplementedException();
        }
    }
}
