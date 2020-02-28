using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Credit.Domain.Interfaces
{
    public interface ICreditRepository
    {
        void AddAcredit(int value, int OriginAccountId, int DestinyAccountId);
    }
}
