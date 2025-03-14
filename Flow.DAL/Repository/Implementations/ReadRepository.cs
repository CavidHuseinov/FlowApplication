using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Flow.Core.Entities.Common;
using Flow.DAL.Context;
using Flow.DAL.Repositories.Interfaces;

namespace Flow.DAL.Repositories.Implementations
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly FlowDbContext _context;

        public ReadRepository(FlowDbContext context)
        {
            _context = context;
        }

        private DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool enableTracking = true)
        {
            IQueryable<TEntity> query = Table;

            if (!enableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetByPagingAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool enableTracking = true,
            int pageIndex = 1,
            int pageSize = 10)
        {
            IQueryable<TEntity> query = Table;

            if (!enableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.Skip((pageIndex - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync();

        }
    

    }
}

