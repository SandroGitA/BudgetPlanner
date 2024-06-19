using BudgetPlanner.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BudgetPlanner.API.Extensions
{
    //Класс для настройки аутентификации
    public static class ApiAuthentication
    {
        public static void AddApiAuthentication(
            this IServiceCollection services, IConfiguration configuration)
        {
            //Получаем опции
            JWTOptions? jwtOptions = configuration.GetSection(nameof(JWTOptions)).Get<JWTOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        //указывает, будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = true,
                        //будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        //будет ли валидироваться время существования
                        ValidateLifetime = true,
                        //валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                        //установка ключа безопасности
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtOptions!.KEY)),
                        //строка, представляющая издателя
                        ValidIssuer = jwtOptions.ISSUER,
                        //установка потребителя токена
                        ValidAudience = jwtOptions.AUDIENCE
                    };
                });

            services.AddAuthorization();
        }
    }
}
