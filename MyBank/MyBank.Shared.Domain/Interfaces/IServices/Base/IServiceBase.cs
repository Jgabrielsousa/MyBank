using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Shared.Domain.Interfaces.IServices.Base
{
    public interface IServiceBase<T> : IDisposable
    {
        T Add(T entidade);
        void Remove(T entidade);
        T Find(long id);
        IEnumerable<T> GetAll();
        void Update(T entidade);
    }
}
