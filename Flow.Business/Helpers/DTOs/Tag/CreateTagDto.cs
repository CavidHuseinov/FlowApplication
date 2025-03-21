using Flow.Business.Helpers.DTOs.Color;
using Flow.Business.Helpers.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.DTOs.Tag
{
    public record CreateTagDto
    {
        public string Name { get; set; }
        public Guid? ColorId { get; set; }
    }
}
