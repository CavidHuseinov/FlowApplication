using Flow.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.DAL.Configurations
{
    public class BlogTagConfiguration : IEntityTypeConfiguration<BlogTag>
    {
        public void Configure(EntityTypeBuilder<BlogTag> builder)
        {
            builder.HasKey(xc=> new{ xc.BlogId, xc.TagId });
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(xc => xc.Blog)
                .WithMany(xc => xc.BlogTags)
                .HasForeignKey(xc => xc.BlogId);

            builder.HasOne(xc => xc.Tag)
                .WithMany(xc => xc.BlogTags)
                .HasForeignKey(xc => xc.TagId);
        }
    }
}
