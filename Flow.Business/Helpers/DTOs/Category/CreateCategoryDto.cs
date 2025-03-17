using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.DTOs.Category
{
    public record CreateCategoryDto
    {
        public string Name { get; set; }
    }
}
