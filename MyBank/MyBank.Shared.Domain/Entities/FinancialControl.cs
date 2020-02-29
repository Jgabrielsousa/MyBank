using FluentValidation;
using MyBank.Shared.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Shared.Domain.Entities
{
    public class FinancialControl : EntityBase<FinancialControl>
    {
       
        
        public decimal Value { get; set; }
        public string Type { get; set; }

        public int AccountId { get; set; }

        public Account Accounts { get; set; }

        public override bool Valid()
        {
            //RuleFor(x => x.Value).NotNull().WithMessage("Valor deve ser fornecido");
            //RuleFor(x => x.AccountId).NotEqual(0).WithMessage("conta deve ser fornecido");
            //RuleFor(x => x.Type).NotEmpty().WithMessage("O tipo da operação deve ser fornecida");

            //ValidationResult = Validate(this);
            //return ValidationResult.IsValid;
            return true;
        }
    }
}
