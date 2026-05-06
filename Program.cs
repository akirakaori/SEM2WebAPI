using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sem2WebAPI.Services.Implementations;
using SEM2WebAPI.Data;
using SEM2WebAPI.Data.Entities;
using SEM2WebAPI.Models;
using SEM2WebAPI.Services;
using SEM2WebAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<Student>(
    builder.Configuration.GetSection("Student")
    );

var postgreSqlConnection = builder.Configuration.GetConnectionString("PostgreSqlConnection")
    ?? throw new InvalidOperationException("Connection string 'PostgreSqlConnection' was not found.");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(postgreSqlConnection)
);

builder.Services.AddScoped<IModuleService, Sem2WebAPI.Services.Implementations.ModuleService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<JwtService>();

builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }
    ).AddJwtBearer(
    options =>
    {
        var jwtOptions = builder.Configuration.GetSection("Jwt");
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions["Issuer"],
            ValidateAudience = true,
            ValidAudience = jwtOptions["Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtOptions["SecretKey"]!)),

        };
    })
    ;
//identity framework registration
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddCors(options =>
{
    // Development - open to all origins
    options.AddPolicy("all", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // Enable Swagger middleware

}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("all");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
using ( var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();  
    db.Database.Migrate();
}
app.Run();
