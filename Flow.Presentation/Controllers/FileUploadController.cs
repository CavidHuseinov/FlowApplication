using Flow.Business.Helpers.DTOs.FileUpload;
using Flow.Business.Helpers.Exceptions;
using Flow.Business.Services.Implementations;
using Flow.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flow.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadService _service;

        public FileUploadController(IFileUploadService service)
        {
            _service = service;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] CreateFileUploadDto fileUploadDto)
        {

            try
            {
                GetFileUploadDto fileResponse = await _service.UploadFileAsync(fileUploadDto);
                return Ok(fileResponse);
            }
            catch (CreateGenericException<CreateFileUploadDto> ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
