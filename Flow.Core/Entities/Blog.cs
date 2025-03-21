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
//0c96a380-a76a-4674-880d-39242c6b57f7
//c1a08d65-df57-437e-b997-abba9d92d112