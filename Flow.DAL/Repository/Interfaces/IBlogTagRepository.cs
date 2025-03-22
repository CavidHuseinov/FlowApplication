using Flow.Core.Entities;
using Flow.DAL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.DAL.Repository.Interfaces
{
    public interface IBlogTagRepository:IWriteRepository<BlogTag>
    {
    }
}
