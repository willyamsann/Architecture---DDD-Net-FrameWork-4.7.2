using Arquitetura.Domain.Common.Interfaces.Repositories;
using Arquitetura.Domain.Modules.ProductManagement.Models;
using System;
using System.Collections.Generic;

namespace Arquitetura.Domain.Modules.ProductManagement.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllActive();

        Product GetByIdWithoutTracking(Guid id);
    }
}
