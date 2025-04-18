﻿using Flow.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.DAL.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
           builder.HasKey(x => x.Id);
           builder.Property(x => x.Id).ValueGeneratedOnAdd();
           
           builder.HasMany(x=>x.Tags)
                .WithOne(x => x.Color)
                .HasForeignKey(x => x.ColorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
