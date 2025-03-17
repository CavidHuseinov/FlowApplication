using Flow.DAL.Repositories.Implementations;
using Flow.DAL.Repositories.Interfaces;
using Flow.DAL.Repository.Implementations;
using Flow.DAL.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.DAL
{
    public static class DALRepositoryRegistration
    {
        public static void AddDALRepostories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<IBlogRepository,BlogRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
        }
    }
}
