using Flow.Business.Helpers.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.DTOs.Color
{
    public record GetColorDto:BaseDto
    {
        public string Name { get; set; }
        public string HexCode { get; set; }
    }
}
