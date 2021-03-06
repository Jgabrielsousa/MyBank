﻿using FluentValidation;
using MyBank.Shared.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Accounts.Domain.Entities
{
    public class Account : EntityBase<Account>
    {
        public int UserId { get; set; }
        public decimal Balance { get; set; }

        //public ICollection<FinancialControl> FinancialControl { get; set; }

        public override bool Valid()
        {
            return true;
        }
    }
}
