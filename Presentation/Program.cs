using Core.External.Interfaces;
using Core.External.Models;
using Core.External.Services;
using Core.Interfaces;
using Core.Internal.Services;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.Configure<ExternalApiOptions>(builder.Configuration.GetSection("ExternalApis"));
builder.Services.AddHttpClient<IEventValidationService, EventValidationService>();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("AspDB")));

builder.Services.AddScoped<IForbiddenItemRepository, ForbiddenItemRepository>();
builder.Services.AddScoped<IForbiddenItemService, ForbiddenItemService>();

var app = builder.Build();


app.MapOpenApi();
app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();
app.MapControllers();

app.Run();
