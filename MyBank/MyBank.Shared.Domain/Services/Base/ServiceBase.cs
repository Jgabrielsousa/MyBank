using MyBank.Shared.Domain.Interfaces.IRepository.Base;
using MyBank.Shared.Domain.Interfaces.IServices.Base;
using System;
using System.Collections.Generic;

namespace MyBank.Shared.Domain.Services.Base
{
    public class ServiceBase<T> : IServiceBase<T>
    {
        public readonly IRepositoryBase<T> _repo;

        public ServiceBase(IRepositoryBase<T> repo)
        {
            _repo = repo;
        }

        public T Add(T entidade) => _repo.Add(entidade);

        public T Find(long id) => _repo.Find(id);

        public IEnumerable<T> GetAll() => _repo.GetAll();

        public void Remove(T entidade) => _repo.Remove(entidade);

        public void Update(T entidade) => _repo.Update(entidade);

        public void Dispose() => GC.Collect();

    }
}
