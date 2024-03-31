using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetPlanner.Logic
{
    //Класс описания контекста
    public class BPContext : DbContext
    {
        //Строка подключения к PostreSQL серверу        
        string pgsqlConnectionString =
            "Host=localhost;Username=postgres;" +
            "Password=SkyCote36;Database=bpdbtest";

        //Таблица с аккаунтами пользователей
        public DbSet<UserInfo> accounts => Set<UserInfo>();
        //Таблица с операциями пользователей
        public DbSet<UserOperation> operations => Set<UserOperation>();        

        //Конструктор        
        public BPContext()
        {
            //Database.EnsureDeleted();
            //Создает БД если она не создана и таблицы на основе описания контекста
            Database.EnsureCreated();
        }

        //Переорпеделяем метод для подключения к бд
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(pgsqlConnectionString);
        }
    }

    //Класс описания пользователя
    public class UserInfo()
    {
        //Геттеры и сеттеры для сопоставления тела запроса с данными  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    //Класс описания операции пользователя
    public class UserOperation()
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public string? Budget { get; set; }
        public string? Ante { get; set; }
        public string? Reason { get; set; }
    }

    //Класс для хранения двух токенов
    public class jwtTokens()
    {
        public string access_token { get;set; }
        public string refresh_token { get; set; }
        public bool is_expired { get; set; } = false;
    }
}