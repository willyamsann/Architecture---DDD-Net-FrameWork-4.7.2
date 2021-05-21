using DomainValidation.Validation;
using System;

namespace Arquitetura.Domain.Common.Models
{
    public abstract class Entity
    {
        protected Entity() 
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
