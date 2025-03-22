using Flow.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Core.Entities
{
    public class Blog:BaseEntity
    {
        public string? ImgUrl { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<BlogTag>? BlogTags { get; set; }
    }
}
//b98c861d-1dbe-4b3a-998a-ececcebd9008
//ebbd942f-5187-4d89-9f17-ec58199c8cef