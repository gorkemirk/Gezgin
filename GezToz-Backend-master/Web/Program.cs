using Infrastructure.Data.Postgres.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Text;
using Web.Utilities;

var builder = WebApplication.CreateBuilder(args);

var cultureInfo = new CultureInfo("tr-Tr");

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", cBuilder =>
{
    cBuilder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed(_ => true)
        .AllowCredentials();
}));

var postgresConnectionString = builder.Configuration.GetConnectionString("PsqlConnection");

builder.Services.AddDbContext<PostgresContext>(dbContextOptionsBuilder =>
    dbContextOptionsBuilder.UseNpgsql(postgresConnectionString, npgsqlDbContextOptionsBuilder => 
        npgsqlDbContextOptionsBuilder.MigrationsAssembly("Infrastructure")));

// Add services to the container.
builder.Services.AddMySingleton();
builder.Services.AddMyScoped();
builder.Services.AddMyTransient();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "PortalBackend",
        Description = ".NET 7 / ASP.NET Core Web API",
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtBearerOptions =>
{
    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["TokenOptions:Issuer"],
        ValidAudience = builder.Configuration["TokenOptions:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenOptions:SecurityKey"])),
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
