using imasderol.api;
using imasderol.infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddImasderolDependencies();

builder.Services.AddControllers();

builder.Services.AddDbContext<ImasderolDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Imasderol API", Description = "", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Imasderol API V1");
});

app.MapControllers();

app.Run();