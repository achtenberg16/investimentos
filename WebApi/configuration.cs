using System.Text;
using Application.interfaces;
using Application.services;
using infrastructure.Context;
using infrastructure.Dao;
using infrastructure.interfaces;
using infrastructure.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
namespace WebApi.configuration;

public static class Configuration
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddAuthentication
                (JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes("8jku18nfjsoifjsaifjoiasjfasoifjsio")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                };
            });
        
        services.AddScoped<IActivesService, ActivesService>();
        services.AddScoped<IAccountService, AccountsService>();
        services.AddScoped<ITickerDao, TickerDao>();
        services.AddScoped<IAccountDao, AccountDao>();
        services.AddScoped<IJwtToken, JwtToken>();
        services.AddScoped<IUserDao, UserDao>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IInvestimentsService, InvestimentsService>();
        services.AddScoped<IInvestimentDao, InvestimentDao>();
        services.AddEntityFrameworkNpgsql()
            .AddDbContext<Context>();
        services.AddEndpointsApiExplorer();
        return services;
    }
}