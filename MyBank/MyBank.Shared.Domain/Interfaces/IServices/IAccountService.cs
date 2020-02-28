using MyBank.Shared.Domain.Entities;
using MyBank.Shared.Domain.Interfaces.IServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Shared.Domain.Interfaces.IServices
{
    public interface IAccountService : IServiceBase<Account>
    {
    }
}
