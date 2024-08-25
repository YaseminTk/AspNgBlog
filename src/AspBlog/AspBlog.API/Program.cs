using AspBlog.Infrastructure;
using AspBlog.Application;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

// Add db context
builder.Services.AddDbContext<BlogDbContex>(options => options.UseSqlServer(config.GetConnectionString("Default")));

// Add repositories and services to the container.
builder.Services
    .AddBlogRepositories()
    .AddBlogServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var scope = app.Services.CreateScope();
using var context = scope.ServiceProvider.GetRequiredService<BlogDbContex>();
context.Database.EnsureCreated();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();