using Flow.Business.Helpers.DTOs.BlogTag;
using Flow.Business.Helpers.DTOs.Color;
using Flow.Business.Helpers.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.DTOs.Tag
{
    public record GetTagDto:BaseDto
    {
        public string Name { get; set; }
        public string? ColorName {  get; set; }
        public string? ColorHexCode { get; set; }
    }
}
