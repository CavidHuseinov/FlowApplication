using Flow.Business.Helpers.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.DTOs.Blog
{
    public record CreateBlogDto
    {
        public string? ImgUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public ICollection<Guid>? TagIds { get; set; }
    }
}
