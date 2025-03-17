using Flow.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Core.Entities
{
    public class Tag:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<BlogTag>? BlogTags { get; set; }
        public Guid? ColorId { get; set; }
        public Color? Color { get; set; }
    }
}
