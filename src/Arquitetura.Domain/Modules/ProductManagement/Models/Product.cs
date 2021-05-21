using Arquitetura.Domain.Common.Models;
using Arquitetura.Domain.Modules.ProductManagement.Validations;

namespace Arquitetura.Domain.Modules.ProductManagement.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public double Value { get; set; }

        public int Quantity { get; set; }

        public bool IsActive { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ProductIsConsistentValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool IsAbleToBeAdded()
        {
            ValidationResult = new ProductIsAbleToBeAddedValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
