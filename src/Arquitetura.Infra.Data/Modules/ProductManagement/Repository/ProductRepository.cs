using Arquitetura.Domain.Modules.ProductManagement.Interfaces.Repositories;
using Arquitetura.Domain.Modules.ProductManagement.Models;
using Arquitetura.Infra.Data.Modules.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arquitetura.Infra.Data.Modules.ProductManagement.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public IEnumerable<Product> GetAllActive()
        {
            var data = DbSet
                .Where(p => p.IsActive)
                .ToList();

            return data;
        }

        public Product GetByIdWithoutTracking(Guid id)
        {
            var data = DbSet
                .AsNoTracking()
                .Where(p => p.Id == id)
                .FirstOrDefault();

            return data;
        }
    }
}
