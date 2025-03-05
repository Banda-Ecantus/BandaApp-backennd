using InventoryService.API.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Shared.ExceptionHandling;
using Shared.Infrastructure;
using Shared.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configurar logging para console
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Load configuration from environment variables
builder.Configuration.AddEnvironmentVariables();

// Register HttpClient for the middleware
builder.Services.AddHttpClient<KeycloackAuthenticationMiddleware>();

// Configurar autenticação com Keycloak
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.Authority = SharedSettings.kcAuthUrl;
        options.Audience = Settings.kcClientInventoryId;
        options.RequireHttpsMetadata = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidIssuer = $"{SharedSettings.kcAuthUrl}/realms/{SharedSettings.kcRealm}",
            ValidateAudience = false,
            ValidAudience = Settings.kcClientInventoryId,
            ValidateLifetime = false
        };
    });

// Configurar políticas de autorização
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("InventoryPolicy", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "inventory.read");
    });
});

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

// Use the custom authentication middleware
app.UseMiddleware<KeycloackAuthenticationMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
