using Flow.Business.Helpers.DTOs.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Services.Interfaces
{
    public interface ITagService
    {
        Task<ICollection<GetTagDto>> GetAllAsync();
        Task<GetTagDto> GetByIdAsync(Guid id);
        Task<GetTagDto> CreateAsync(CreateTagDto dto);
        Task UpdateAsync(UpdateTagDto dto);
        Task RemoveAsync(Guid id);
    }
}
