using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Text;
using ThePatho.Features.MasterData.AdsCategory.Commands;

using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.DateTimeProvider;
using ThePatho.Provider.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
//builder.Services.AddAuthorization();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Use camelCase and ignore nulls for cleaner payloads to Next.js
    options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAdsCategoryCommand).Assembly));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("Identity", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Identity API",
        Version = "v1"
    });
    options.SwaggerDoc("MasterData", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Master Data API",
        Version = "v1"
    });
    options.SwaggerDoc("MasterSetting", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Master Setting API",
        Version = "v1"
    });
    options.SwaggerDoc("Organization", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Organization API",
        Version = "v1"
    });
    options.SwaggerDoc("Applicant", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Applicant API",
        Version = "v1"
    });
    options.SwaggerDoc("Recruitment", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Recruitment API",
        Version = "v1"
    });

    // Use Controller Group Names
    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        var groupName = apiDesc.GroupName ?? string.Empty;
        return docName.Equals(groupName, StringComparison.OrdinalIgnoreCase);
    });

    // Add JWT Bearer security definition to enable token input in Swagger
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Masukkan token JWT dengan format: Bearer {token}",
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

var jwtConfig = builder.Configuration.GetSection("Jwt").Get<JwtConfiguration>();

builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddSingleton(jwtConfig);
builder.Services.AddScoped<IDateTimeService, DateTimeService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(builder.Configuration["Jwt:Key"]!)),
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/Identity/swagger.json", "Identity API");
        options.SwaggerEndpoint("/swagger/MasterData/swagger.json", "Master Data API");
        options.SwaggerEndpoint("/swagger/MasterSetting/swagger.json", "Master Setting API");
        options.SwaggerEndpoint("/swagger/Organization/swagger.json", "Organization API");
        options.SwaggerEndpoint("/swagger/Applicant/swagger.json", "Applicant API");
        options.SwaggerEndpoint("/swagger/Recruitment/swagger.json", "Recruitment API");
    });
}

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
    // Bypass for Swagger UI and CORS preflight
    var path = context.Request.Path;
    if (path.StartsWithSegments("/swagger") || string.Equals(context.Request.Method, "OPTIONS", StringComparison.OrdinalIgnoreCase))
    {
        await next();
        return;
    }

    // Default to v1 if not provided to keep DX simple; validate if provided
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

app.Run();
