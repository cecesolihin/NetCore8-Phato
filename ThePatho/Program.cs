using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ThePatho.Features.MasterData.AdsCategory.Commands;

using ThePatho.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

//builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
//builder.Services.AddIdentity<User, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
//        ValidAudience = builder.Configuration["JwtSettings:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(
//            Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"])
//        )
//    };
//});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/Identity/swagger.json", "Identity API");
        options.SwaggerEndpoint("/swagger/MasterData/swagger.json", "Master Data API");
        options.SwaggerEndpoint("/swagger/MasterSetting/swagger.json", "Master Setting API");
        options.SwaggerEndpoint("/swagger/Applicant/swagger.json", "Applicant API");
        options.SwaggerEndpoint("/swagger/Recruitment/swagger.json", "Recruitment API");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
