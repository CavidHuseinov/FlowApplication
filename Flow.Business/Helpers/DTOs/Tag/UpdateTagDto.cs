using Flow.Business.Helpers.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.DTOs.Tag
{
    public record UpdateTagDto:BaseDto  
    {
        public string Name { get; set; }
        public Guid? ColorId { get; set; }

    }
}
