using BudgetPlanner.API.Extensions;
using BudgetPlanner.Application;
using BudgetPlanner.DataBase;
using BudgetPlanner.DataBase.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

// Add services to the container.
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

//Подключение метода рсширения авторизации
builder.Services.AddApiExtensions(builder.Configuration);


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.Run("http://*:8888");
app.Run();
