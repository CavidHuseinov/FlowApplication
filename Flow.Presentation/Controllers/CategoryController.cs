using Flow.Business.Helpers.DTOs.Category;
using Flow.Business.Helpers.Exceptions;
using Flow.Business.Services.Interfaces;
using Flow.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var category = await _service.GetAllAsync();
            return Ok(category);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var category = await _service.GetByIdAsync(id);
                return Ok(category);
            }
            catch (GetGenericException<Category> ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _service.CreateAsync(dto);
                return Ok();
            }
            catch (CreateGenericException<Category> ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(UpdateCategoryDto dto)
        {
            try
            {
                await _service.UpdateAsync(dto);
                return NoContent();
            }
            catch (UpdateGenericException<Category> ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (DeleteGenericException<Category> ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
