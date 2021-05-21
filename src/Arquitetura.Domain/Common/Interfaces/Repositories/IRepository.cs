using Arquitetura.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Arquitetura.Domain.Common.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity GetById(Guid id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAllPaged(int skip, int take);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity obj);

        TEntity Update(TEntity obj);

        void Delete(Guid id);

        int SaveChanges();
    }
}
