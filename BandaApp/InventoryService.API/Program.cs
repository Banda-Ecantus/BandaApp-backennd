using InventoryService.API.Configurations;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Shared.ExceptionHandling;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configurar logging para console
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Load configuration from environment variables
builder.Configuration.AddEnvironmentVariables();


builder.Services
.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddKeycloakWebApi(builder.Configuration);

builder.Services
.AddAuthorization()
.AddKeycloakAuthorization()
.AddAuthorizationBuilder()
.AddPolicy("InventoryPolicy",
policy => policy.RequireResourceRolesForClient(
    "bandaapp_backend_inventory",
["inventory.read"]));

DependencyInjectionConfig.AddDependencyInjectionConfiguration(builder.Services);


var app = builder.Build();

// Adicionando o Middleware de Tratamento de Exceções
app.UseGlobalExceptionHandling();

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
