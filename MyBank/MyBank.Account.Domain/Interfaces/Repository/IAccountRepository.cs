using MyBank.Shared.Domain.Entities;
using MyBank.Shared.Domain.Interfaces.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Accounts.Domain.Interfaces.Repository
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        void Credit(int value, int OriginAccountId, int DestinyAccountId);
        void Debt(int value, int OriginAccountId, int DestinyAccountId);
    }
}
