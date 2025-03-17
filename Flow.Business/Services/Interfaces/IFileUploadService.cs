using Flow.Business.Helpers.DTOs.FileUpload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Services.Interfaces
{
    public interface IFileUploadService
    {
        Task<GetFileUploadDto> UploadFileAsync(CreateFileUploadDto fileUploadDto);
    }
}
