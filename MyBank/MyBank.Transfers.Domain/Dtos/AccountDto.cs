using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Transfers.Domain.Dtos
{
   public  class AccountDto
    {
        public int UserId { get; set; }
        public decimal Balance { get; set; }
    }
}
