using Arquitetura.Domain.Modules.ProductManagement.Models;
using Arquitetura.Domain.Modules.ProductManagement.Specifications;
using DomainValidation.Validation;

namespace Arquitetura.Domain.Modules.ProductManagement.Validations
{
    public class ProductIsAbleToBeAddedValidation : Validator<Product>
    {
        public ProductIsAbleToBeAddedValidation()
        {
            var productQuantityMustBeGreaterThanZeroSpecification = new ProductQuantityMustBeGreaterThanZeroSpecification();
            var productValueMustBeGreaterThanZeroSpecification = new ProductValueMustBeGreaterThanZeroSpecification();

            base.Add("productQuantityMustBeGreaterThanZeroSpecification", new Rule<Product>(productQuantityMustBeGreaterThanZeroSpecification, "A quantidade informada precisa ser maior que zero"));
            base.Add("productValueMustBeGreaterThanZeroSpecification", new Rule<Product>(productValueMustBeGreaterThanZeroSpecification, "O valor do produto precisa ser maior que zero"));
        }
    }
}
