using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Results;

namespace MyBank.Shared.Domain.Base
{
    public abstract class EntityBase<T> : AbstractValidator<T>  where T : EntityBase<T>
    {
        public long Id { get; set; }


        public ValidationResult ValidationResult { get; protected set; }
        public EntityBase()
        {
            ValidationResult = new ValidationResult();
        }
        public abstract bool Valid();

    }
}
