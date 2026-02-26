using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using ThePatho.Domain.Models.Identity;
using ThePatho.Features.Global.BloodType.Commands;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.DateTimeProvider;
using ThePatho.Provider.Jwt;
using Swashbuckle.AspNetCore.SwaggerUI;
using ThePatho.Provider.UserContext;
using QuestPDF.Infrastructure;
using ThePatho.Provider.Email;
using ThePatho.Provider;

var builder = WebApplication.CreateBuilder(args);

// Pastikan environment variables tersedia agar menimpa nilai di appsettings
builder.Configuration.AddEnvironmentVariables();

// Load environment variables dari .env hanya saat Development
if (builder.Environment.IsDevelopment())
{
    var envFile = Path.Combine(Directory.GetCurrentDirectory(), ".env");
    if (File.Exists(envFile))
    {
        var envVars = File.ReadAllLines(envFile)
            .Where(line => !string.IsNullOrWhiteSpace(line) && !line.TrimStart().StartsWith("#"))
            .Select(line => line.Split('=', 2))
            .Where(parts => parts.Length == 2)
            .ToDictionary(parts => parts[0].Trim(), parts => parts[1].Trim());

        foreach (var envVar in envVars)
        {
            Environment.SetEnvironmentVariable(envVar.Key, envVar.Value);
        }
    }
}

// Konfigurasi lisensi QuestPDF agar tidak memunculkan exception lisensi
QuestPDF.Settings.License = LicenseType.Community;

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Use camelCase and ignore nulls for cleaner payloads to Next.js
    options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetBloodTypeCommand).Assembly));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("Identity", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Identity API",
        Version = "v1"
    });
    options.SwaggerDoc("Organization", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Organization API",
        Version = "v1"
    });
    options.SwaggerDoc("Global", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Global API",
        Version = "v1"
    });
    options.SwaggerDoc("PersonalInformation", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Personal Information API",
        Version = "v1"
    });

    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        var groupName = apiDesc.GroupName ?? string.Empty;
        return docName.Equals(groupName, StringComparison.OrdinalIgnoreCase);
    });

    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Masukkan token JWT dengan format: {token}",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddSingleton<SqlQueryLoader>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDbConnection>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new SqlConnection(connectionString);
});
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddApplicationServices();
// Access HttpContext and current user info
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

// Email Service
builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration"));
builder.Services.AddScoped<IEmailService, EmailService>();

// Konfigurasi Identity dengan UserManager
builder.Services.AddIdentityCore<User>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
    
    options.User.RequireUniqueEmail = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.Lockout.MaxFailedAccessAttempts = 5;
})
.AddDefaultTokenProviders();

// Mendaftarkan CustomUserStore untuk User
builder.Services.AddScoped<IUserStore<User>, ThePatho.Infrastructure.Persistance.Identity.CustomUserStore>();

// CORS: allow Next.js origins from configuration
const string CorsPolicyName = "NextJsOrigins";
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicyName, policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Safe JWT configuration read (toleran terhadap missing / non-int values)
var jwtSection = builder.Configuration.GetSection("Jwt");
var jwtConfig = new JwtConfiguration
{
    Issuer = jwtSection["Issuer"],
    Audience = jwtSection["Audience"],
    Key = jwtSection["Key"],
    ExpiryMinutes = int.TryParse(jwtSection["ExpiryMinutes"], out var minutes) ? minutes : 60
};

builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddSingleton(jwtConfig);
builder.Services.AddScoped<IDateTimeService, DateTimeService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // Prepare signing key: expect base64, but fallback to UTF8 plain-text
        var jwtKeyConfigValue = builder.Configuration["Jwt:Key"] ?? jwtConfig.Key;
        if (string.IsNullOrWhiteSpace(jwtKeyConfigValue))
        {
            throw new InvalidOperationException("Jwt:Key is not configured. Set environment variable Jwt__Key (base64 or plain text).");
        }

        byte[] keyBytes;
        try
        {
            keyBytes = Convert.FromBase64String(jwtKeyConfigValue);
        }
        catch (FormatException)
        {
            keyBytes = System.Text.Encoding.UTF8.GetBytes(jwtKeyConfigValue);
        }

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfig.Issuer ?? builder.Configuration["Jwt:Issuer"],
            ValidAudience = jwtConfig.Audience ?? builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ClockSkew = TimeSpan.FromMinutes(2)
        };
        options.SaveToken = true;
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine($"JWT auth failed: {context.Exception.Message}");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("JWT token validated");
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/Identity/swagger.json", "Identity API");
    options.SwaggerEndpoint("/swagger/Organization/swagger.json", "Organization API");
    options.SwaggerEndpoint("/swagger/Global/swagger.json", "Global API");
    options.SwaggerEndpoint("/swagger/PersonalInformation/swagger.json", "Personal Information API");
    options.DocExpansion(DocExpansion.None);
});

// Global exception handler with ProblemDetails
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Terjadi kesalahan pada server",
            Detail = "Silakan coba lagi atau hubungi admin jika berlanjut."
        };

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = problemDetails.Status.Value;
        await context.Response.WriteAsJsonAsync(problemDetails);
    });
});

app.UseHttpsRedirection();

// Enable CORS before auth
app.UseCors(CorsPolicyName);

// Header-based API versioning (minimal): require x-api-version=v1
app.Use(async (context, next) =>
{
    var path = context.Request.Path;
    if (path.StartsWithSegments("/swagger") || string.Equals(context.Request.Method, "OPTIONS", StringComparison.OrdinalIgnoreCase))
    {
        await next();
        return;
    }

    if (!context.Request.Headers.TryGetValue("x-api-version", out var version))
    {
        context.Request.Headers.Add("x-api-version", "v1");
        await next();
        return;
    }

    if (version != "v1")
    {
        var problem = new Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Versi API tidak valid",
            Detail = "Gunakan nilai v1 pada header x-api-version."
        };
        context.Response.StatusCode = problem.Status.Value;
        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsJsonAsync(problem);
        return;
    }

    await next();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => Results.Json(new { status = "ok", service = "ThePatho API" }));
app.MapGet("/health", () => Results.Ok("Healthy"));

app.Run();
