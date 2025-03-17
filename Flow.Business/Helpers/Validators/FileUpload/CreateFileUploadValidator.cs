using Flow.Business.Helpers.DTOs.FileUpload;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.Validators.FileUpload
{
    public class CreateFileUploadValidator : AbstractValidator<CreateFileUploadDto>
    {
        public CreateFileUploadValidator()
        {
            RuleFor(x => x.File)
                                       .NotNull().WithMessage("Şəkil mütləq daxil edilməlidir.")
                                       .Must(x => x.Length <= 40 * 1024 * 1024).WithMessage("Şəkilin maksimum ölçüsü 40 mb olmalıdır. Zəhmət olmasa düzgün şəkil daxil edin.")
                                            .Must(x => IsValidImage(x)).WithMessage("Şəkilin formatı düzgün deyil. Dəstəklənən formatlar: .jpeg, .jpg, .png, .svg, .bmp, .webp, .heif, .tiff, .gif");
        }
        private bool IsValidImage(IFormFile file)
        {
            if (file == null) return false;

            var validMimeTypes = new List<string>
        {
            "image/jpeg", "image/png", "image/svg+xml", "image/bmp", "image/webp", "image/heif", "image/tiff", "image/gif", "image/svg"
        };

            return validMimeTypes.Contains(file.ContentType.ToLower());
        }
    }
}
