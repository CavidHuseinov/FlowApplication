using Flow.Business.Helpers.DTOs.Blog;
using Flow.Business.Helpers.DTOs.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Services.Interfaces
{
    public interface IColorService
    {
        Task<ICollection<GetColorDto>> GetAllAsync();
        Task<GetColorDto> GetByIdAsync(Guid Id);
        Task<GetColorDto> CreateAsync(CreateColorDto dto);
        Task RemoveAsync(Guid Id);
    }
}
