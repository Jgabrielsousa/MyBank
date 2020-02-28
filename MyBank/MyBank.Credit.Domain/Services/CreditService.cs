using MyBank.Credit.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Credit.Domain.Services
{
    public class CreditService : ICreditService
    {
        private readonly ICreditRepository _repo;
        public CreditService(ICreditRepository repo)
        {
            _repo = repo;
        }
        public void AddAcredit(int value, int OriginAccountId, int DestinyAccountId)
        {
            _repo.AddAcredit(value, OriginAccountId, DestinyAccountId);
        }
    }
}
