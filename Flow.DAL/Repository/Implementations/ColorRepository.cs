﻿using Flow.Core.Entities;
using Flow.DAL.Context;
using Flow.DAL.Repositories.Implementations;
using Flow.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.DAL.Repository.Implementations
{
    public class ColorRepository : WriteRepository<Color>, IColorRepository
    {
        public ColorRepository(FlowDbContext context) : base(context)
        {
        }
    }
}
