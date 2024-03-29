﻿using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class AplicationServiceExtensions
{
    public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        services.AddDbContext<DataContext>(
            options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
        
        return services;
    }
}