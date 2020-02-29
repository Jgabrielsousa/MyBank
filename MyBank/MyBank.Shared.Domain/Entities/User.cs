using FluentValidation;
using MyBank.Shared.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Shared.Domain.Entities
{
    public class User : EntityBase<User>
    {
        public User(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public int AccountId { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public override bool Valid()
        {
            //RuleFor(x => x.Name)
            //     .NotEmpty().WithMessage("Nome precisa ser fornecido ")
            //     .Length(4, 200).WithMessage("Nome precisa ter entre 4 e 200 caracteres");
            //ValidationResult = Validate(this);
            //return ValidationResult.IsValid;
            return true;

        }
    }
}
