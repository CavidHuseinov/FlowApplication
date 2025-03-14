using Flow.Business.Services.Implementations;
using Flow.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business
{
    public static class BusinessServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BusinessServiceRegistration));
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<ISocialMediaService, SocialMediaService>();
        }
    }
}
