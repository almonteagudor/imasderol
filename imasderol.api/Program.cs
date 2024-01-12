using imasderol.application.zombicide.skill;
using imasderol.domain.zombicide.skill;
using imasderol.infrastructure;
using imasderol.infrastructure.zombicide.skill;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<CreateUseCase>();
builder.Services.AddScoped<SkillCreator>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Imasderol API", Description = "", Version = "v1" });
});

builder.Services.AddSqlite<ImasderolDb>(null);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Imasderl API V1");
});

app.MapControllers();

app.Run();
