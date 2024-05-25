using DigitalSchoolApi.Core;
using DigitalSchoolApi.Core.Options;
using DigitalSchoolApi.Core.Repositories;
using DigitalSchoolApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DigitalSchoolApiOptions>(builder.Configuration.GetSection(nameof(DigitalSchoolApiOptions)));
builder.Services.AddScoped<IDigitalSchoolApiRepository, DigitalSchoolApiRepository>();
builder.Services.AddScoped<IDigitalSchoolApiManager, DigitalSchoolApiManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
