using MyBank.Credit.Domain.Interfaces;
using MyBank.Shared.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Credit.Infra.Repository
{
    public class CreditRepository : ICreditRepository
    {
        private readonly IAccountService _x;
        public CreditRepository(IAccountService x)
        {
            _x = x;
        }

        public void AddAcredit(int value, int OriginAccountId, int DestinyAccountId)
        {
            var item  = _x.GetAll();
        }
    }
}
