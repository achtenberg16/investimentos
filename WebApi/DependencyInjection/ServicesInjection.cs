using System.Text;
using Application.interfaces;
using Application.services;
using infrastructure.Context;
using infrastructure.Dao;
using infrastructure.interfaces;
using infrastructure.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
namespace WebApi.dependencyInjection;

public static class Configuration
{
    public static IServiceCollection ServiceInjection(this IServiceCollection services)
    {
        services.AddAuthorization();
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