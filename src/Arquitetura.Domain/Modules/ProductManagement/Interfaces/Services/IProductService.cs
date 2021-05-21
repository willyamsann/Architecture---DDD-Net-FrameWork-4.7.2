using Arquitetura.Domain.Modules.ProductManagement.Models;
using System;

namespace Arquitetura.Domain.Modules.ProductManagement.Interfaces.Services
{
    public interface IProductService : IDisposable
    {
        Product Add(Product obj);
        
        Product Update(Product obj);

        void Delete(Guid id);
    }
}
