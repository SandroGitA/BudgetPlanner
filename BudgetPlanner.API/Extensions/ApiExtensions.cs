﻿using BudgetPlanner.Application;
using BudgetPlanner.Logic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BudgetPlanner.API.Extensions
{
    public static class ApiExtensions
    {
        public static void AddApiExtensions(
            this IServiceCollection services, IConfiguration configuration)
        {

            JWTOptions? jwtOptions = configuration.GetSection(nameof(JWTOptions)).Get<JWTOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtOptions?.ISSUER,
                        ValidateAudience = true,
                        ValidAudience = jwtOptions?.AUDIENCE,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtOptions?.KEY))
                    };
                });

            services.AddAuthorization();
        }
    }
}
