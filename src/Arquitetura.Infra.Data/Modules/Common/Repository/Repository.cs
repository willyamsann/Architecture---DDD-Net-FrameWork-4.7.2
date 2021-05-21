using Arquitetura.Domain.Common.Interfaces.Repositories;
using Arquitetura.Domain.Common.Models;
using Arquitetura.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Arquitetura.Infra.Data.Modules.Common.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected ArquiteturaContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository()
        {
            Db = new ArquiteturaContext();
            DbSet = Db.Set<TEntity>();
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public IEnumerable<TEntity> GetAllPaged(int skip, int take)
        {
            return DbSet.Skip(skip).Take(take).ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        //TODO: Call SaveChanges on UnitOfWork
        public TEntity Add(TEntity obj)
        {
            var retEntity = DbSet.Add(obj);
            SaveChanges();

            return retEntity;
        }

        //TODO: Call SaveChanges on UnitOfWork
        public TEntity Update(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();

            return obj;
        }

        //TODO: Call SaveChanges on UnitOfWork
        public void Delete(Guid id)
        {
            var obj = new TEntity() { Id = id };
            DbSet.Remove(obj);
            SaveChanges();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
