using DigitalSchoolApi.Api;
using DigitalSchoolApi.Core.Managers;
using DigitalSchoolApi.Core.Options;
using DigitalSchoolApi.Core.Repositories;
using DigitalSchoolApi.Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(config => config.Filters.Add(new ProducesAttribute("application/json")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DigitalSchoolApiOptions>(builder.Configuration.GetSection(nameof(DigitalSchoolApiOptions)));
builder.Services.AddScoped<IDigitalSchoolApiRepository, DigitalSchoolApiRepository>();
builder.Services.AddScoped<IDigitalSchoolApiManager, DigitalSchoolApiManager>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.RunDatabaseMigrations<Program>();

app.Run();
