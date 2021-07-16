using Microsoft.EntityFrameworkCore;
using Portal.Domain.Aggregates;
using Portal.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Portal.Infrastructure
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }

    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly PortalDbContext Context;
        protected readonly DbSet<T> DbSet;

        public EfRepository(
            PortalDbContext portalDbContext)
        {
            Context = portalDbContext ?? throw new ArgumentNullException(nameof(portalDbContext));
            DbSet = Context.Set<T>();
        }

        public void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}