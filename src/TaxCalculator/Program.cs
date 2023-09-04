using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using TaxCalculator;
using TaxCalculator.Contract;

var configuration = new ConfigurationBuilder()
    .AddJsonFile(ConfigUtil.GetConfigurationFile(), optional: false, reloadOnChange: true)
    .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterFeature("Calculators", "TaxCalculator.*.dll", typeof(ITaxCalculator), ConfigUtil.GetRegion());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (ConfigUtil.IsDevEnviornment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
