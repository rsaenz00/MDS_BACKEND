using MDS.Api.Infrastructure.Helpers;
using MDS.Api.Utility.Extensions;
using MDS.DbContext.Infrastructure;
using MDS.Infrastructure.Services;
using MDS.Infrastructure.Settings;
using MDS.Services.Blog;
using MDS.Services.Blog.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MediSanna API",
        Description = "A big project with an amazing team for a great company"
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
IConfiguration configuration = builder.Configuration;
IAppSettings appSettings = new AppSettings(configuration);


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

IdentityHelper.ConfigureService(builder.Services);
AuthenticationHelper.ConfigureService(builder.Services, appSettings.Issuer, appSettings.Audience, appSettings.Key);


builder.Services.AddScoped<Microsoft.EntityFrameworkCore.DbContext, ApplicationDbContext>();
//builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddUnitOfWork();
builder.Services.AddUnitOfWork<ApplicationDbContext>();

builder.Services.AutoRegisterServices();


builder.Services.AddCors(options =>
{
    options.AddPolicy("default", policy =>
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
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
