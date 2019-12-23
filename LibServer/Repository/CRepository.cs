using Microsoft.EntityFrameworkCore;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace LibServer.Repository
{
    public class CRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected DbContext Context { get; private set; }

        protected DbSet<TEntity> Set => Context.Set<TEntity>();

        public CRepository(DbContext dbContext)
        {
            Context = dbContext;
        }

        public IQueryable<TEntity> Query => Set;

        public TEntity Find(params object[] keys)
        {
            return Set.Find(keys);
        }

        public void Insert(TEntity entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                Set.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                Set.Attach(entity);
            Set.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                Set.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public virtual PaginatedList<TEntity> GetPaged(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
                   int pageIndex = 1, int pageSize = 10,
                   Expression<Func<TEntity, bool>> filter = null,
                   string includeProperties = "")
        {
            IQueryable<TEntity> query = Set;
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            query = orderBy(Set);
            int totalCount = query.Count();
            var collection = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking();
            return new PaginatedList<TEntity>(collection, pageIndex, pageSize, totalCount);
        }
    }
}