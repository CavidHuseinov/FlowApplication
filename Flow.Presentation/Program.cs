using Flow.Infrastructure.Middlewares;
using Flow.Business;
using Flow.DAL;
using Flow.DAL.Context;
using Microsoft.EntityFrameworkCore;
namespace Flow.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDALRepostories();
            builder.Services.AddBusinessServices();
            builder.Services.AddControllers();
            builder.Services.AddDbContext<FlowDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Deploy"));
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            app.UseCors("AllowAll");

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.MapControllers();
            app.UseStaticFiles();
            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.Run();
        }
    }
}
