using Arquitetura.Domain.Modules.ProductManagement.Models;
using DomainValidation.Interfaces.Specification;

namespace Arquitetura.Domain.Modules.ProductManagement.Specifications
{
    public class ProductValueMustBeGreaterThanZeroSpecification : ISpecification<Product>
    {
        public bool IsSatisfiedBy(Product obj)
        {
            if (obj.Value > 0)
                return true;

            return false;
        }
    }
}
