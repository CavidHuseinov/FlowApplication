using AutoMapper;
using Flow.Business.Helpers.DTOs.SocialMedia;
using Flow.Business.Services.Interfaces;
using Flow.Core.Entities;
using Flow.DAL.Repositories.Interfaces;
using Flow.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Services.Implementations
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IReadRepository<SocialMedia> _readRepository;
        private readonly ISocialMediaRepository _writeRepository;
        private readonly IMapper _mapper;

        public SocialMediaService(IMapper mapper, ISocialMediaRepository writeRepository, IReadRepository<SocialMedia> readRepository)
        {
            _mapper = mapper;
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<ICollection<GetSocialMediaDto>> GetAllAsync()
        {
            var media = await _readRepository.GetAllAsync();
            return _mapper.Map<ICollection<GetSocialMediaDto>>(media);
        }
        public async Task<GetSocialMediaDto> GetByIdAsync(Guid Id)
        {
            if(Id == Guid.Empty)
            {
                throw new ArgumentNullException("Id cannot be null");
            }
            var media = await _readRepository.GetByIdAsync(Id);
            if (media == null)
            {
                throw new KeyNotFoundException($"SocialMedia with id {Id} not found.");
            }
            return _mapper.Map<GetSocialMediaDto>(media);
        }

        public async Task<GetSocialMediaDto> CreateAsync(CreateSocialMediaDto dto)
        {

            var media = _mapper.Map<SocialMedia>(dto);
            var newMedia = await _writeRepository.CreateAsync(media);
            return _mapper.Map<GetSocialMediaDto>(newMedia);
        }
        public Task UpdateAsync(UpdateSocialMediaDto dto)
        {

            var media = _mapper.Map<SocialMedia>(dto);
            return _writeRepository.UpdateAsync(media);
        }

        public async Task DeleteAsync(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(Id), "Id cannot be empty");
            }

            var media = await _readRepository.GetByIdAsync(Id);
            if (media == null)
            {
                throw new KeyNotFoundException($"SocialMedia with id {Id} not found.");
            }

            await _writeRepository.DeleteAsync(media);
        }


    }
}
