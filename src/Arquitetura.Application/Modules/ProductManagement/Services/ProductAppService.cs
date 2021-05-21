using Arquitetura.Application.Modules.ProductManagement.Interfaces;
using Arquitetura.Application.Modules.ProductManagement.ViewModels;
using Arquitetura.Domain.Modules.ProductManagement.Interfaces.Repositories;
using Arquitetura.Domain.Modules.ProductManagement.Interfaces.Services;
using Arquitetura.Domain.Modules.ProductManagement.Models;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Arquitetura.Application.Modules.ProductManagement.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;

        public ProductAppService(IProductService productService, IProductRepository productRepository)
        {
            _productService = productService;
            _productRepository = productRepository;
        }

        public ProductViewModel GetById(Guid id)
        {
            var product = _productRepository.GetById(id);

            return Mapper.Map<ProductViewModel>(product);
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            var products = _productRepository.GetAll();

            return Mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public IEnumerable<ProductViewModel> GetAllActive()
        {
            var products = _productRepository.GetAllActive();

            return Mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public ProductViewModel Add(ProductViewModel obj)
        {
            var product = Mapper.Map<Product>(obj);

            var productViewModel = Mapper.Map<ProductViewModel>(_productService.Add(product));

            return productViewModel;
        }

        public ProductViewModel Update(ProductViewModel obj)
        {
            var product = Mapper.Map<Product>(obj);

            var productViewModel = Mapper.Map<ProductViewModel>(_productService.Update(product));

            return productViewModel;
        }

        public void Delete(Guid id)
        {
            _productService.Delete(id);
        }

        public void Dispose()
        {
            _productService.Dispose();
            _productRepository.Dispose();
        }
    }
}
