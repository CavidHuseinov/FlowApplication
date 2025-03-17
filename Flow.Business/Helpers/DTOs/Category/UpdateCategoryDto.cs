using Flow.Business.Helpers.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.DTOs.Category
{
    public record UpdateCategoryDto:BaseDto
    {
        public string Name { get; set; }
    }
}
