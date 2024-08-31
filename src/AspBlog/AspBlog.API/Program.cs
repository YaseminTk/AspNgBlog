using AspBlog.Infrastructure;
using AspBlog.Application;
using Microsoft.EntityFrameworkCore;
using AspBlog.API;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOriginsPolicy", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

int cookieExpiresInMinutes = config.GetValue<int>("AuthenticationOptions:ExpiresInMinutes");
if (cookieExpiresInMinutes == default)
    cookieExpiresInMinutes = 180;

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // General cookie settings
        options.LoginPath = "/api/auth/in"; // Log in path
        options.LogoutPath = "/api/auth/out"; // Log out path
        options.ExpireTimeSpan = TimeSpan.FromMinutes(cookieExpiresInMinutes); // Cookie expiration time
        options.SlidingExpiration = true; // Refresh the expiration time on each request

        // Cookie settings
        options.Cookie.HttpOnly = true; // Prevent client-side scripts from accessing the cookie
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.Cookie.SameSite = SameSiteMode.Strict; // Prevent cookies from being sent with cross-site requests

        // Optional: Customize cookie name
        options.Cookie.Name = "YourAppNameCookie";
    });

// Add db context
builder.Services.AddDbContext<BlogDbContex>(options => options.UseSqlServer(config.GetConnectionString("Default")));

// Add repositories and services to the container.
builder.Services
    .AddBlogRepositories()
    .AddBlogServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AuthenticationOptions>(config);

var app = builder.Build();

app.UseCors("AllowedOriginsPolicy");

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