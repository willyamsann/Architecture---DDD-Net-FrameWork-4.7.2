using Arquitetura.Domain.Modules.ProductManagement.Models;
using Arquitetura.Domain.Modules.ProductManagement.Specifications;
using DomainValidation.Validation;

namespace Arquitetura.Domain.Modules.ProductManagement.Validations
{
    public class ProductIsConsistentValidation : Validator<Product>
    {
        public ProductIsConsistentValidation()
        {
            var productNameIsMandatorySpecification = new ProductNameIsMandatorySpecification();

            base.Add("productNameIsMandatorySpecification", new Rule<Product>(productNameIsMandatorySpecification, "O Nome do produto é obrigatório"));
        }
    }
}
