using Flow.Business.Helpers.DTOs.BlogTag;
using Flow.Business.Helpers.DTOs.Category;
using Flow.Business.Helpers.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.DTOs.Blog
{
    public record GetBlogDto:BaseDto
    {
        public string? ImgUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public ICollection<GetBlogTagDto>? BlogTags { get; set; }
    }
}
