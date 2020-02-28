using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Shared.Domain.Interfaces.IRepository.Base
{
    public interface IRepositoryBase<T> : IDisposable
    {
        T Add(T entidade);
        void Remove(T entidade);
        T Find(long Id);
        IEnumerable<T> GetAll();
        void Update(T entidade);
        new void Dispose();
    }
}
