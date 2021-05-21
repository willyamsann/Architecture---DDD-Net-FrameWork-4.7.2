using Arquitetura.Domain.Modules.ProductManagement.Interfaces.Repositories;
using Arquitetura.Domain.Modules.ProductManagement.Interfaces.Services;
using Arquitetura.Domain.Modules.ProductManagement.Models;
using System;

namespace Arquitetura.Domain.Modules.ProductManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Add(Product obj)
        {
            if (!obj.IsValid())
                return obj;

            if (!obj.IsAbleToBeAdded())
                return obj;

            var data = _productRepository.Add(obj);

            data.ValidationResult.Message = "Produto adicionado com sucesso";

            return data;
        }
        
        public Product Update(Product obj)
        {
            if (!obj.IsValid())
                return obj;

            var data = _productRepository.Update(obj);

            data.ValidationResult.Message = "Produto atualizado com sucesso";

            return data;
        }

        public void Delete(Guid id)
        {
            var product = _productRepository.GetByIdWithoutTracking(id);

            product.IsActive = false;

            _productRepository.Update(product);
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}
