using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Accounts.Domain.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public int FinancialControlId { get; set; }
    }
}
