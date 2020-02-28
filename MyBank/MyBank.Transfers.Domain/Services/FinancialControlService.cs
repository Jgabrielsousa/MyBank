using MyBank.Shared.Domain.Entities;
using MyBank.Transfers.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Transfers.Domain.Services
{
    public class FinancialControlService : IFinancialControlService
    {
        private readonly IFinancialControlRepository _repo;
        public FinancialControlService(IFinancialControlRepository repo)
        {
            _repo = repo;
        }

        public void Credit(int value, int OriginAccountId, int DestinyAccountId)
        {
            _repo.Credit(value, OriginAccountId, DestinyAccountId);
        }

        public void Debt(int value, int OriginAccountId, int DestinyAccountId)
        {
            _repo.Debt(value, OriginAccountId, DestinyAccountId);
        }
        public FinancialControl Add(FinancialControl entidade)
        {
            return _repo.Add(entidade);
        }

        public FinancialControl Find(long id)
        {
            return _repo.Find(id);
        }

        public IEnumerable<FinancialControl> GetAll()
        {
            return _repo.GetAll();
        }

        public void Remove(FinancialControl entidade)
        {
            _repo.Remove(entidade);
        }

        public void Update(FinancialControl entidade)
        {
            _repo.Update(entidade);
        }
        public void Dispose()
        {

        }
    }
}
