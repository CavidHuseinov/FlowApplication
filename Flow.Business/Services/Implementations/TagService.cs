using AutoMapper;
using Flow.Business.Helpers.DTOs.Tag;
using Flow.Business.Helpers.DTOs.Tag;
using Flow.Business.Services.Interfaces;
using Flow.Core.Entities;
using Flow.DAL.Repositories.Interfaces;
using Flow.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Services.Implementations
{
    public class TagService : ITagService
    {
        private readonly IReadRepository<Tag> _readRepository;
        private readonly ITagRepository _writeRepository;
        private readonly IMapper _mapper;

        public TagService(IMapper mapper, ITagRepository writeRepository, IReadRepository<Tag> readRepository)
        {
            _mapper = mapper;
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<GetTagDto> CreateAsync(CreateTagDto dto)
        {
            var tag = _mapper.Map<Tag>(dto);
            var newTag = await _writeRepository.CreateAsync(tag);
            return _mapper.Map<GetTagDto>(newTag);
        }

        public async Task RemoveAsync(Guid Id)
        {
            var tag = await _readRepository.GetByIdAsync(Id);
            if (tag == null)
            {
                throw new KeyNotFoundException($"Tag with id {Id} not found.");
            }
            await _writeRepository.DeleteAsync(tag);
        }

        public async Task<ICollection<GetTagDto>> GetAllAsync()
        {
            var tag = await _readRepository.GetAllAsync(
                include: query=>query
                .Include(x => x.Color)
                );
            return _mapper.Map<ICollection<GetTagDto>>(tag);
        }

        public async Task<GetTagDto> GetByIdAsync(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                throw new ArgumentNullException("Id cannot be null");
            }
            var tag = await _readRepository.GetAllAsync(
                predicate: x => x.Id == Id,
                include: query => query
                .Include(x => x.Color)
                );
            if (tag == null)
            {
                throw new KeyNotFoundException($"Tag with id {Id} not found.");
            }
            return _mapper.Map<GetTagDto>(tag);
        }

        public async Task UpdateAsync(UpdateTagDto dto)
        {
            var tag = await _readRepository.GetByIdAsync(dto.Id);
            if (tag == null) throw new Exception("tag not found");

            _mapper.Map(dto, tag);
            await _writeRepository.UpdateAsync(tag);
        }
    }
}
