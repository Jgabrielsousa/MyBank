using Microsoft.EntityFrameworkCore;
using MyBank.Shared.Domain.Base;
using MyBank.Shared.Domain.Interfaces.IRepository.Base;
using MyBank.Transfers.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBank.Transfers.Infra.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : EntityBase<T>
    {
        protected readonly TransfersDbContext context;
        protected DbSet<T> DbSet;


        public RepositoryBase(TransfersDbContext _context)
        {
            context = _context;
            DbSet = context.Set<T>();
        }


        public T Add(T entidade)
        {
            DbSet.Add(entidade);
            context.SaveChanges();
            return entidade;
        }

        

        public T Find(long id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public  void Update(T entidade)
        {
            DbSet.Update(entidade);
            context.SaveChanges();
        }

        public  void Dispose()
        { }

        public void Remove(T entidade)
        {
            DbSet.Remove(entidade);
            context.SaveChanges();
        }
    }
}
