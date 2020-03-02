using MyBank.Accounts.Domain.Dtos;
using MyBank.Shared.Domain.Entities;
using MyBank.Shared.Domain.Interfaces.IServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Accounts.Domain.Interfaces.Services
{
    public interface IAccountService : IServiceBase<Account>
    {
        void UpdateAmount(int accountId, decimal amount);
    }
}
