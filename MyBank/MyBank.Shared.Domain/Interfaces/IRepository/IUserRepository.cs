using MyBank.Shared.Domain.Entities;
using MyBank.Shared.Domain.Interfaces.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Shared.Domain.Interfaces.IRepository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
    }
}
