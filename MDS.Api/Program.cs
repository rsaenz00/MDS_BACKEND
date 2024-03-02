using MDS.Api.Infrastructure.Helpers;
using MDS.Api.Utility.Extensions;
using MDS.DbContext.Infrastructure;
using MDS.Infrastructure.Services;
using MDS.Infrastructure.Settings;
using MDS.Services.Blog;
using MDS.Services.Blog.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesAttribute("application/json"));
});

builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
IConfiguration configuration = builder.Configuration;
IAppSettings appSettings = new AppSettings(configuration);


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

IdentityHelper.ConfigureService(builder.Services);
AuthenticationHelper.ConfigureService(builder.Services, appSettings.Issuer, appSettings.Audience, appSettings.Key);
SwaggerHelper.ConfigureService(builder.Services);

builder.Services.AddScoped<Microsoft.EntityFrameworkCore.DbContext, ApplicationDbContext>();
builder.Services.AddUnitOfWork();
builder.Services.AddUnitOfWork<ApplicationDbContext>();

builder.Services.AutoRegisterServices();


builder.Services.AddCors(options =>
{
    options.AddPolicy("development", policy =>
    {
        policy.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });

    options.AddPolicy("production", policy =>
    {
        policy.WithOrigins(appSettings.ClientBaseUrl)
        .SetIsOriginAllowed(isOriginAllowed: _ => true)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("development");
}
else 
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("production");
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
