using Core.External.Interfaces;
using Core.External.Models;
using Core.External.Services;
using Core.Interfaces;
using Core.Internal.Services;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v.1.0",
        Title = "Event Rules API Documentation",
        Description = "Documentation for the Rules API."
    });
    o.EnableAnnotations();
    o.ExampleFilters();

    var apiScheme = new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "X-API-KEY",
        Description = "API KEY",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme",
        Reference = new OpenApiReference
        {
            Id = "ApiKey",
            Type = ReferenceType.SecurityScheme,
        }
    };

    o.AddSecurityDefinition("ApiKey", apiScheme);
    o.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { apiScheme, new List<string>() }
    });
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();

builder.Services.Configure<ExternalApiOptions>(builder.Configuration.GetSection("ExternalApis"));
builder.Services.AddHttpClient<IEventValidationService, EventValidationService>();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("AspDB")));

builder.Services.AddScoped<IForbiddenItemRepository, ForbiddenItemRepository>();
builder.Services.AddScoped<IForbiddenItemService, ForbiddenItemService>();

var app = builder.Build();

app.MapOpenApi();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Event Rules API v.1.0");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();
app.MapControllers();

app.Run();
