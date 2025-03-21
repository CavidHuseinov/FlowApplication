﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.DTOs.FileUpload
{
    public record CreateFileUploadDto
    {
        public IFormFile File { get; set; }
        public string FolderName { get; set; }

    }
}
