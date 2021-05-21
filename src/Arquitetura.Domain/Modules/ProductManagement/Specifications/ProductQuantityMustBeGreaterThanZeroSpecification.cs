using Arquitetura.Domain.Modules.ProductManagement.Models;
using DomainValidation.Interfaces.Specification;

namespace Arquitetura.Domain.Modules.ProductManagement.Specifications
{
    public class ProductQuantityMustBeGreaterThanZeroSpecification : ISpecification<Product>
    {
        public bool IsSatisfiedBy(Product obj)
        {
            if (obj.Quantity > 0)
                return true;

            return false;
        }
    }
}
