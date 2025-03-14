using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flow.DAL.Repositories.Interfaces;
using Flow.Core.Entities.Common;
using Flow.DAL.Context;
using Flow.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Flow.DAL.Repositories.Implementations
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity, new()
    {
       private readonly FlowDbContext _context;

        public WriteRepository(FlowDbContext context)
        {
            _context = context;
        }

        private DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => Table.Remove(entity));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => Table.Update(entity));
            await _context.SaveChangesAsync();
        }
    }
}
