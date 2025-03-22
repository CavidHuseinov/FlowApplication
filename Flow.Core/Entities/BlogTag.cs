using Flow.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Core.Entities
{
    public class BlogTag:BaseEntity
    {
        public Guid BlogId { get; set; }
        public Blog? Blog { get; set; }
        public Guid TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
