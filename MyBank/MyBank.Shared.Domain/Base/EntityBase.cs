using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FluentValidation;
using FluentValidation.Results;

namespace MyBank.Shared.Domain.Base
{
    public abstract class EntityBase<T> : AbstractValidator<T>  where T : EntityBase<T>
    {
        public int Id { get; set; }
       
        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }
        public EntityBase()
        {
            ValidationResult = new ValidationResult();
        }
        public abstract bool Valid();

    }
}
