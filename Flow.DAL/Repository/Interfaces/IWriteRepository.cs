using Flow.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.DAL.Repository.Interfaces
{
    public interface IWriteRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
