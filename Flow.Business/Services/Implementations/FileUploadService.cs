using Flow.Business.Helpers.DTOs.FileUpload;
using Flow.Business.Helpers.Exceptions;
using Flow.Business.Helpers.Extensions;
using Flow.Business.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Services.Implementations
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _env;

        public FileUploadService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<GetFileUploadDto> UploadFileAsync(CreateFileUploadDto fileUploadDto)
        {
            if (fileUploadDto.File == null || fileUploadDto.File.Length == 0)
            {
                throw new Exception("File not found");
            }

            if (string.IsNullOrWhiteSpace(fileUploadDto.FolderName))
            {
                throw new Exception("folder not found");
            }
            string imgUrl = fileUploadDto.File.Upload(_env.WebRootPath, fileUploadDto.FolderName);

            return new GetFileUploadDto
            {
                ImgUrl = imgUrl
            };
        }
    }
}
