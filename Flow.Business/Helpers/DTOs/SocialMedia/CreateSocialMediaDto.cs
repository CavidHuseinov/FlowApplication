using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.DTOs.SocialMedia
{
    public record CreateSocialMediaDto
    {
        public string? InstagramUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? LinkedInUrl { get; set; }
    }
}
