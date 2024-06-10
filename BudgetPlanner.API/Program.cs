using BudgetPlanner.Application;
using BudgetPlanner.Core;
using BudgetPlanner.DataBase;
using BudgetPlanner.DataBase.Repositories;
using BudgetPlanner.Logic;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

// Add services to the container.
//Добавляем DbContext в контейнер DI
builder.Services.AddDbContext<BudgetPlannerDbContext>(
    options =>
    {
        options.UseNpgsql("Host=localhost;Username=postgres;Password=SkyCote36;Database=bpdbtest546456456");
    });

//Добавление сервисов
builder.Services.AddScoped<OperationsService>();
builder.Services.AddScoped<UsersService>();

//Добавление репозиториев
builder.Services.AddScoped<OperationsRepository>();
builder.Services.AddScoped<UsersRepository>();

builder.Services.AddScoped<PasswordHasher>();
builder.Services.AddScoped<JWTProvider>();

//Подключение авторизации на основе JWT
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            //указывает, будет ли валидироваться издатель при валидации токена
//            ValidateIssuer = true,
//            //строка, представляющая издателя
//            ValidIssuer = AuthOptions.ISSUER,
//            //будет ли валидироваться потребитель токена
//            ValidateAudience = true,
//            //установка потребителя токена
//            ValidAudience = AuthOptions.AUDIENCE,
//            //будет ли валидироваться время существования
//            ValidateLifetime = true,
//            //установка ключа безопасности
//            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
//            //валидация ключа безопасности
//            ValidateIssuerSigningKey = true,

//        };
//    });

builder.Services.AddControllers();
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

//User settngs
app.UseCors(
    builder => builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    );

//app.UseHttpsRedirection();
//app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

//app.Run("http://*:8888");
app.Run();
