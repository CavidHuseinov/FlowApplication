using AutoMapper;
using Flow.Business.Helpers.DTOs.Category;
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
    public class CategoryService : ICategoryService
    {
        private readonly IReadRepository<Category> _readRepository;
        private readonly IWriteRepository<Category> _writeRepository;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IWriteRepository<Category> writeRepository, IReadRepository<Category> readRepository)
        {
            _mapper = mapper;
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<GetCategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            var newCategory = await _writeRepository.CreateAsync(category);
            return _mapper.Map<GetCategoryDto>(newCategory);
        }

        public async Task DeleteAsync(Guid Id)
        {
            var category = await _readRepository.GetByIdAsync(Id);
            if (category == null)
            {
                throw new KeyNotFoundException($"category with id {Id} not found.");
            }
            await _writeRepository.DeleteAsync(category);
        }

        public async Task<ICollection<GetCategoryDto>> GetAllAsync()
        {
            var categories = await _readRepository.GetAllAsync(
                include: query =>query
                .Include(x => x.Blogs)
                );
            return _mapper.Map<ICollection<GetCategoryDto>>(categories);
        }

        public async Task<GetCategoryDto> GetByIdAsync(Guid Id)
        {
           if(Id == Guid.Empty)
            {
                throw new ArgumentNullException("Id cannot be null");
            }
            var category = await _readRepository.GetByIdAsync(Id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with id {Id} not found.");
            }
            return _mapper.Map<GetCategoryDto>(category);
        }

        public async Task UpdateAsync(UpdateCategoryDto dto)
        {
            var category = await _readRepository.GetByIdAsync(dto.Id);
            if (category == null) throw new Exception("category not found");

            _mapper.Map(dto, category);
            await _writeRepository.UpdateAsync(category);
        }
    }
}
