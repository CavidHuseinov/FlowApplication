using Flow.Business.Helpers.DTOs.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Services.Interfaces
{
        public interface ISocialMediaService
        {
            Task<ICollection<GetSocialMediaDto>> GetAllAsync();
            Task<GetSocialMediaDto> GetByIdAsync(Guid Id);
            Task<GetSocialMediaDto> CreateAsync(CreateSocialMediaDto dto);
            Task UpdateAsync(UpdateSocialMediaDto dto);
            Task DeleteAsync(Guid Id);
        }
}
