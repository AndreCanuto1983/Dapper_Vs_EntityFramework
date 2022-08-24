using ProjectDapperVsEntityFramework.Infra.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ContextSettings(builder.Configuration);
builder.Services.InterfaceSettings();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.ServiceExtensionSettings();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseHealthChecks("/health");
    app.UseCustomExceptionMiddleware();
    app.UseResponseCaching();
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseAuthorization();

app.MapControllers();

app.Run();
