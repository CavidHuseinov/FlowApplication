using Flow.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Core.Entities
{
    public class Color:BaseEntity
    {
        public string Name { get; set; }
        public string HexCode { get; set; }
        public ICollection<Tag>? Tags { get; set; }
    }
}
