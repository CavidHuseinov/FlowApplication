using Flow.Business.Helpers.DTOs.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.DTOs.BlogTag
{
    public record GetBlogTagDto
    {
        public Guid Id { get; set; }
        public Guid BlogId { get; set; }
        public GetTagDto? Tag { get; set; }
    }
}
