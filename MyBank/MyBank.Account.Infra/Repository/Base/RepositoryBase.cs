using Microsoft.EntityFrameworkCore;
using MyBank.Accounts.Infra.Context;
using MyBank.Shared.Domain.Base;
using MyBank.Shared.Domain.Interfaces.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBank.Accounts.Infra.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase<T>
    {
        protected readonly AccountDbContext contexto;
        protected DbSet<T> DbSet;


        public RepositoryBase(AccountDbContext _contexto)
        {
            contexto = _contexto;
            DbSet = contexto.Set<T>();
        }


        public virtual T Add(T entidade)
        {
            DbSet.Add(entidade);
            return entidade;
        }

        public virtual void Remove(T entidade)
        {
            DbSet.Remove(entidade);
        }

        public virtual T Find(long id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public virtual void Update(T entidade)
        {
            DbSet.Update(entidade);
        }

        public virtual void Dispose()
        { }
    }
}
