using Flow.Business.Helpers.DTOs.Tag;
using Flow.Business.Helpers.Exceptions;
using Flow.Business.Services.Interfaces;
using Flow.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _service;

        public TagController(ITagService service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var tag = await _service.GetAllAsync();
            return Ok(tag);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var tag = await _service.GetByIdAsync(id);
                return Ok(tag);
            }
            catch (GetGenericException<Tag> ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateTagDto dto)
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
            catch (CreateGenericException<Tag> ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(UpdateTagDto dto)
        {
            try
            {
                await _service.UpdateAsync(dto);
                return NoContent();
            }
            catch (UpdateGenericException<Tag> ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            try
            {
                await _service.RemoveAsync(id);
                return NoContent();
            }
            catch (DeleteGenericException<Tag> ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
