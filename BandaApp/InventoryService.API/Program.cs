using InventoryService.API.Configurations;
using Shared.ExceptionHandling;
using Shared.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Load configuration from environment variables
builder.Configuration.AddEnvironmentVariables();

// Add Keycloak configuration
KeycloakConfig.AddKeycloakConfiguration(builder.Services, builder.Configuration);
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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
