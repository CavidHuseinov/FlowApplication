using Flow.Infrastructure.Middlewares;
using Flow.Business;
using Flow.DAL;
using Flow.DAL.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDALRepostories();
builder.Services.AddBusinessServices();
builder.Services.AddControllers();
builder.Services.AddDbContext<FlowDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
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