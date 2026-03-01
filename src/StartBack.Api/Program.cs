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

// Apply migrations + seed on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AemzDbContext>();
    await DbSeeder.SeedAsync(db);

    var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
    var connString = config.GetConnectionString("Default");
    if (!string.IsNullOrEmpty(connString))
    {
        try {
            using (var conn = new Npgsql.NpgsqlConnection(connString))
            {
                await conn.OpenAsync();
                
                // 1. Rename plural to singular for common tables found in dump
                string[] tablesToRename = { 
                    "academic_calendars", "academic_levels", "academic_years", "guardians", "persons", 
                    "courses", "sections", "semesters", "subjects", "transcripts", "universities",
                    "attendance_completeds", "attendance_periods", "battalions", "buildings", "companies",
                    "final_grades", "floors", "rooms", "platoons", "quarters", "sections", "semesters"
                };

                foreach (var plural in tablesToRename)
                {
                    string singular = plural.EndsWith("ies") ? plural.Substring(0, plural.Length - 3) + "y" : 
                                     plural.EndsWith("s") ? plural.Substring(0, plural.Length - 1) : plural;
                    
                    // Special case: persons -> person
                    if (plural == "persons") singular = "person";

                    using (var cmd = new Npgsql.NpgsqlCommand($"DO $$ BEGIN IF EXISTS (SELECT FROM information_schema.tables WHERE table_name = '{plural}') AND NOT EXISTS (SELECT FROM information_schema.tables WHERE table_name = '{singular}') THEN ALTER TABLE \"{plural}\" RENAME TO \"{singular}\"; END IF; END $$;", conn))
                    {
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                // 2. Apply the idempotent schema script (DISABLED FOR TROUBLESHOOTING)
                /*
                if (System.IO.File.Exists("full_schema_idempotent.sql"))
                {
                    string sql = await System.IO.File.ReadAllTextAsync("full_schema_idempotent.sql");
                    // Split script by ";" but be careful with functions/DO blocks if any
                    // For now, simple split is okay for EF generated scripts
                    var commands = sql.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var command in commands)
                    {
                        var trimmed = command.Trim();
                        if (string.IsNullOrWhiteSpace(trimmed)) continue;
                        
                        try {
                            using (var cmd = new Npgsql.NpgsqlCommand(trimmed, conn))
                            {
                                await cmd.ExecuteNonQueryAsync();
                            }
                        } catch (Exception ex) {
                            // Only log errors that aren't expected (like Relation already exists or Duplicate key)
                            if (!ex.Message.Contains("already exists") && !ex.Message.Contains("duplicate key")) {
                                Console.WriteLine($"Command failed: {trimmed.Substring(0, Math.Min(trimmed.Length, 50))}... Error: {ex.Message}");
                            }
                        }
                    }
                    Console.WriteLine("Idempotent schema application attempt finished.");
                }
                */
                Console.WriteLine("Schema script execution skipped for troubleshooting.");

                // 3. Create missing InsightEngine tables (idempotent - NEVER drops, preserves data)
                string ieSql = @"
                    CREATE TABLE IF NOT EXISTS ""ie_saved_reports"" (
                        ""Id""        UUID PRIMARY KEY,
                        ""Name""      VARCHAR(255) NOT NULL,
                        ""CreatedBy"" VARCHAR(255),
                        ""TenantId""  VARCHAR(255),
                        ""Definition"" JSONB,
                        ""CreatedAt"" TIMESTAMP WITH TIME ZONE DEFAULT NOW(),
                        ""UpdatedAt"" TIMESTAMP WITH TIME ZONE,
                        ""IsDeleted"" BOOLEAN DEFAULT FALSE
                    );
                    CREATE TABLE IF NOT EXISTS ""ie_export_jobs"" (
                        ""Id""              UUID PRIMARY KEY,
                        ""ReportId""        UUID REFERENCES ""ie_saved_reports""(""Id"") ON DELETE SET NULL,
                        ""Format""          VARCHAR(10) NOT NULL,
                        ""Status""          VARCHAR(20) NOT NULL,
                        ""FilePath""        VARCHAR(1000),
                        ""FileSize""        BIGINT,
                        ""RequestedBy""     VARCHAR(255) NOT NULL,
                        ""TenantId""        VARCHAR(255) NOT NULL,
                        ""ErrorMessage""    TEXT,
                        ""CreatedAt""       TIMESTAMP NOT NULL,
                        ""CompletedAt""     TIMESTAMP,
                        ""QueryDefinition"" JSONB NOT NULL
                    );
                    CREATE TABLE IF NOT EXISTS ie_audit_logs (
                        id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
                        event_type VARCHAR(50) NOT NULL,
                        user_id VARCHAR(255) NOT NULL,
                        tenant_id VARCHAR(255) NOT NULL,
                        payload JSONB NOT NULL,
                        timestamp TIMESTAMP NOT NULL DEFAULT NOW(),
                        trace_id VARCHAR(100)
                    );
                    CREATE INDEX IF NOT EXISTS ix_audit_tenant_time ON ie_audit_logs (tenant_id, timestamp);
                    CREATE INDEX IF NOT EXISTS ix_audit_event ON ie_audit_logs (event_type);
                    CREATE INDEX IF NOT EXISTS ix_audit_user ON ie_audit_logs (user_id);
                    CREATE TABLE IF NOT EXISTS ""ie_report_shares"" (
                        ""Id""         UUID PRIMARY KEY,
                        ""ReportId""   UUID NOT NULL REFERENCES ""ie_saved_reports""(""Id"") ON DELETE CASCADE,
                        ""TargetType"" VARCHAR(10) NOT NULL,
                        ""TargetId""   VARCHAR(255) NOT NULL,
                        ""Permission"" VARCHAR(10) NOT NULL,
                        ""GrantedBy""  VARCHAR(255) NOT NULL,
                        ""GrantedAt""  TIMESTAMP NOT NULL DEFAULT NOW()
                    );
                ";
                using (var cmd = new Npgsql.NpgsqlCommand(ieSql, conn))
                {
                    await cmd.ExecuteNonQueryAsync();
                    Console.WriteLine("InsightEngine tables ensured (idempotent, data preserved).");
                }

                // Diagnostic: Print ie_export_jobs columns to console AND log file
                using (var cmd = new Npgsql.NpgsqlCommand("SELECT column_name, data_type FROM information_schema.columns WHERE table_name = 'ie_export_jobs';", conn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        var schemaInfo = new System.Text.StringBuilder();
                        schemaInfo.AppendLine("Schema for ie_export_jobs:");
                        while (await reader.ReadAsync())
                        {
                            schemaInfo.AppendLine($"- {reader.GetString(0)} ({reader.GetString(1)})");
                        }
                        string info = schemaInfo.ToString();
                        Console.WriteLine(info);
                        await System.IO.File.WriteAllTextAsync("ie_schema_diag.txt", info);
                    }
                }

                // Extra fix: In case InsightEngine expects PascalCase or mixed case columns 
                // we'll try to add aliases or just ensured they are correct.
                // Based on previous logs, QueryDefinition was expected as 'QueryDefinition' or 'query_definition'
                
                // 4. Ensure baseline
                string migrationId = "20260223095837_InitialSnakeCase";
                using (var cmd = new Npgsql.NpgsqlCommand($"INSERT INTO \"__EFMigrationsHistory\" (migration_id, product_version) VALUES ('{migrationId}', '9.0.0') ON CONFLICT (migration_id) DO NOTHING;", conn))
                {
                    await cmd.ExecuteNonQueryAsync();
                    Console.WriteLine($"Migration {migrationId} baselined.");
                }
            }
        } catch (Exception ex) {
            Console.WriteLine("Migration automation failed: " + ex.Message);
        }
    }
}

// Ensure full cleanup of temporary files if needed
if (System.IO.File.Exists("full_schema_idempotent.sql")) {
    // System.IO.File.Delete("full_schema_idempotent.sql");
}

app.Run();

app.Run();

