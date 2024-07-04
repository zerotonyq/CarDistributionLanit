using System.Text.Json;
using System.Text.Json.Serialization;
using CarDistribution.Application;
using CarDistribution.Common.DB;
using CarDistribution.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;


services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddMediatR
(
    serviceConfiguration =>
    {
        serviceConfiguration
            .RegisterServicesFromAssemblies
            (
                AppDomain
                    .CurrentDomain
                    .GetAssemblies()
            );
    }
);

DatabaseInjection.Configure(services, configuration);
ApplicationInjection.Configure(services, configuration);
InfrastructureInjection.Configure(services, configuration);

services.AddControllers()
    .AddJsonOptions
    (
        x =>
        {
            x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
        }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors
(
    cors => cors.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
);

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
