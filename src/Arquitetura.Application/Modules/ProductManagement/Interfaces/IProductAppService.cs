using Arquitetura.Application.Modules.ProductManagement.ViewModels;
using System;
using System.Collections.Generic;

namespace Arquitetura.Application.Modules.ProductManagement.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        ProductViewModel GetById(Guid id);

        IEnumerable<ProductViewModel> GetAll();
        
        IEnumerable<ProductViewModel> GetAllActive();

        ProductViewModel Add(ProductViewModel obj);

        ProductViewModel Update(ProductViewModel obj);

        void Delete(Guid id);
    }
}
