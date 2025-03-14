using Flow.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Flow.DAL.Context
{
    public class FlowDbContext : DbContext
    {
        public FlowDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SocialMedia> SocialMedias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
