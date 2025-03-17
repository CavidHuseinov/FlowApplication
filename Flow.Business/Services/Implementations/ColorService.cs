using AutoMapper;
using Flow.Business.Helpers.DTOs.Color;
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
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;
        private readonly IReadRepository<Color> _readRepository;
        private readonly IMapper _mapper;

        public ColorService(IMapper mapper, IReadRepository<Color> readRepository, IColorRepository colorRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
            _colorRepository = colorRepository;
        }

        public async Task<GetColorDto> CreateAsync(CreateColorDto dto)
        {
            var color = _mapper.Map<Color>(dto);
            var newColor = await _colorRepository.CreateAsync(color);
            return _mapper.Map<GetColorDto>(newColor);
        }

        public async Task<ICollection<GetColorDto>> GetAllAsync()
        {
            var color = await _readRepository.GetAllAsync();
            return _mapper.Map<ICollection<GetColorDto>>(color);
        }

        public async Task<GetColorDto> GetByIdAsync(Guid Id)
        {
            var color = await _readRepository.GetByIdAsync(Id);
            if(color == null)
            {
                throw new Exception("Color not found");
            }
            return _mapper.Map<GetColorDto>(color);
        }

        public async Task RemoveAsync(Guid Id)
        {
            var color = await _readRepository.GetByIdAsync(Id);
            if (color == null)
            {
                throw new Exception("Color not found");
            }
            await _colorRepository.DeleteAsync(color);
        }
    }
}
