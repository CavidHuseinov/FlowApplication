using Flow.Business.Helpers.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Services.Interfaces
{
    public interface IBlogService
    {
        Task<ICollection<GetBlogDto>> GetAllAsync();
        Task<GetBlogDto> GetByIdAsync(Guid Id);
        Task<GetBlogDto> CreateAsync(CreateBlogDto dto);
        Task UpdateAsync(UpdateBlogDto dto);
        Task RemoveAsync(Guid Id);
    }
}
