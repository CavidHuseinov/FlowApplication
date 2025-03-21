using Flow.Business.Helpers.DTOs.SocialMedia;
using Flow.Business.Helpers.Exceptions;
using Flow.Business.Services.Interfaces;
using Flow.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _service;

        public SocialMediaController(ISocialMediaService service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var media = await _service.GetAllAsync();
            return Ok(media);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var media = await _service.GetByIdAsync(id);
                return Ok(media);
            }
            catch (GetGenericException<SocialMedia> ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateSocialMediaDto dto)
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
            catch (CreateGenericException<SocialMedia> ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateSocialMediaDto dto)
        {
            try
            {
                await _service.UpdateAsync(dto);
                return NoContent();
            }
            catch (UpdateGenericException<SocialMedia> ex)
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
            catch (DeleteGenericException<SocialMedia> ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
