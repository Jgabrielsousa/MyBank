using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Transfers.Domain
{
    public class TransferDto
    {
        public decimal Amount { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
    }
}
