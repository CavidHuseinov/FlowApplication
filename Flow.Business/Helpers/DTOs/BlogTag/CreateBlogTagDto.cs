using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.DTOs.BlogTag
{
    public record CreateBlogTagDto
    {
        public Guid BlogId { get; set; }
        public Guid TagId { get; set; }
    }
}
