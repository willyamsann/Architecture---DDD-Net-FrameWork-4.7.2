using Arquitetura.Domain.Modules.ProductManagement.Models;
using DomainValidation.Interfaces.Specification;

namespace Arquitetura.Domain.Modules.ProductManagement.Specifications
{
    public class ProductNameIsMandatorySpecification : ISpecification<Product>
    {
        public bool IsSatisfiedBy(Product obj)
        {
            if (!string.IsNullOrEmpty(obj.Name))
                return true;

            return false;
        }
    }
}
