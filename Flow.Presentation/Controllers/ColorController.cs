using Flow.Business.Helpers.DTOs.Color;
using Flow.Business.Helpers.Exceptions;
using Flow.Business.Services.Interfaces;
using Flow.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _service;

        public ColorController(IColorService service)
        {
            _service = service;
        }

        [HttpGet("getall")]

        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
            var result = await _service.GetAllAsync();
            return Ok(result);
            }
            catch (GetGenericException<Color> ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                return Ok(result);
            }
            catch (GetGenericException<Color> ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateColorDto dto)
        {
            try
            {
                var result = await _service.CreateAsync(dto);
                return Ok(result);
            }
            catch (CreateGenericException<Color> ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            try
            {
                await _service.RemoveAsync(id);
                return Ok();
            }
            catch (DeleteGenericException<Color> ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
