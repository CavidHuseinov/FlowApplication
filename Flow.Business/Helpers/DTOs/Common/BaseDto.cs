﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Helpers.DTOs.Common
{
    public record BaseDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
    }
}
