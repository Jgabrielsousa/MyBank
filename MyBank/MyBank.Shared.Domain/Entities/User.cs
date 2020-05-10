using FluentValidation;
using MyBank.Shared.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Shared.Domain.Entities
{
    public class User : EntityBase<User>
    {
        public string Name { get; private set; }
        public string Cpf { get; private set; }

        public User(string name, string cpf) {
            this.Name = name;
            this.Cpf = cpf;
        } 

        public override bool Valid() =>  (!string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.Name));
       
    }
}
