using Flow.Business.Helpers.DTOs.Blog;
using Flow.Business.Helpers.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.DTOs.Category
{
    public record GetCategoryDto:BaseDto
    {
        public string Name { get; set; }
        public ICollection<GetBlogDto>? Blogs { get; set; }
    }
}
