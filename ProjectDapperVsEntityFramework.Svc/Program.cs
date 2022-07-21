using ProjectDapperVsEntityFramework.Infra.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ContextSettings(builder.Configuration);
builder.Services.InterfaceSettings();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.ServiceExtensionSettings();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
