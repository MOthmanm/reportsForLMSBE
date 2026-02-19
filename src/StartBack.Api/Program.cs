using StartBack.Infrastructure.Extensions;
using InsightEngine.Api;
using InsightEngine.Infrastructure;
using InsightEngine.Infrastructure.Configuration;
using StartBack.Infrastructure.Persistence;
using StartBack.Infrastructure.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using StartBack.Api.Auth;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;
using StartBack.Application.Extensions;
using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "StartBack API", Version = "v1" });
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter 'Bearer {token}'",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, Array.Empty<string>() }
    });
});

// Persistence + Infrastructure
builder.Services.AddSqlServerPersistence(builder.Configuration);
builder.Services.AddInfrastructureEf();
builder.Services.AddInfrastructureEf();
builder.Services.AddApplicationServices();

// InsightEngine Services
builder.Services.AddInsightEngine(options =>
{
    options.DatabaseProvider = DatabaseProviderType.PostgreSQL;
    options.ConnectionString = builder.Configuration.GetConnectionString("Default")!;
    options.CacheProvider = CacheProviderType.InMemory;
    // RLS Configuration for ReportsForLMS
    options.RlsMapping = new RlsColumnMapping
    {
         // Defaulting to loose RLS for initial integration
         UnrestrictedEntities = new List<string> { "users", "roles" },
         TenantClaim = "tenant_id"
    };
});

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
}).AddMvc()
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddInsightEngineControllers();

// CORS: allow frontend dev server
const string AllowFrontend = "AllowFrontend";
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowFrontend, policy =>
        policy.WithOrigins("http://localhost:5174", "http://localhost:5175")
              .AllowAnyHeader()
              .AllowAnyMethod());
});
}
else
{

    builder.Services.AddCors(
        options =>
        {
            options.AddPolicy(AllowFrontend, builder =>
            builder.SetIsOriginAllowed(origin =>
            {

                try
                {
                    var uri = new Uri(origin);
                    return uri.Host == "localhost" ||
                    uri.Host.StartsWith("192.168.40") ||
                    uri.Host.StartsWith("192.168.8") ||
                    uri.Host.StartsWith("192.168.20") ||
                    uri.Host.StartsWith("192.168.3") ||
                    uri.Host.StartsWith("1.23") ||
                    uri.Host.StartsWith("dsr");

                }
                catch
                {
                    return false;
                }
            }).AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
        });



}

// JWT & Authorization (permission-based)
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>() ?? new JwtOptions();
builder.Services.AddSingleton<IJwtTokenService, JwtTokenService>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtOptions.Issuer,
        ValidAudience = jwtOptions.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
    };
});
builder.Services.AddAuthorization();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.DocExpansion(DocExpansion.None); // collapse endpoints by default
});
//}

app.UseRouting();
app.UseCors(AllowFrontend);
app.UseAuthentication();
app.UseAuthorization();
app.UseInsightEngine();
app.UseStaticFiles();

app.MapControllers();

//Apply migrations + seed on startup
//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<AemzDbContext>();
//    await DbSeeder.SeedAsync(db);
//}

app.Run();

