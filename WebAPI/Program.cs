using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// IoC Container implementation of the Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));
// IoC Container implementation of the Autofac

// Add services to the container.
builder.Services.AddControllers();

// CORS Configuration 
builder.Services.AddCors();
// CORS Configuration 

// JWT Configuartion
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});
// JWT Configuartion

// IoC Container of .Net Framework
// It was in the Startup.cs file in the previous versions of the .Net.
//builder.Services.AddSingleton<IProductService, ProductManager>();  // We make this line comment line because we are not going to use the .Net's IoC Container. We will use Autofac to get access for creating AOP structure.
//builder.Services.AddSingleton<IProductDal, EfProductDal>();  // We make this line comment line because we are not going to use the .Net's IoC Container. We will use Autofac to get access for creating AOP structure.
// IoC Container of .Net Framework

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS Configuration → If 4200th port wants to request anything, give it.
app.UseCors(builder=>builder.WithOrigins("http://localhost:4200").AllowAnyHeader());
// CORS Configuration 

// Middlewares
app.UseHttpsRedirection();

// JWT Configuration
app.UseAuthentication();
// JWT Configuration

app.UseAuthorization();

app.MapControllers();
// Middlewares

app.Run();
