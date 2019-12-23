using Microsoft.EntityFrameworkCore;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LibServer.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        TEntity Find(params object[] keys);

        IQueryable<TEntity> Query { get; }

        PaginatedList<TEntity> GetPaged(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
                   int pageIndex = 1, int pageSize = 10,
                   Expression<Func<TEntity, bool>> filter = null,
                   string includeProperties = "");
    }
}
