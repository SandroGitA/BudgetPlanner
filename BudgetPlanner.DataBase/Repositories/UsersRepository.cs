using BudgetPlanner.Core;
using BudgetPlanner.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.DataBase.Repositories
{
    //Класс репозитория для CRUD операции с пользователяvми
    public class UsersRepository
    {
        private readonly BudgetPlannerDbContext _context;

        public UsersRepository(BudgetPlannerDbContext context)
        {
            _context = context;
        }

        //Метод добавления пользователя
        public void AddUser(User user)
        {
            var userEntity = new UserEntity
            {
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                UserName = user.UserName,
                ID = user.ID,
            };

            _context.Users.Add(userEntity);
            _context.SaveChanges();
        }

        //Метод для поиска пользователя по email
        public User GetUserByEmail(string email)
        {
            var userEntity = _context.Users.AsNoTracking().FirstOrDefault(u => u.Email == email);

            return User.CreateUser(userEntity.ID, userEntity.UserName, userEntity.PasswordHash, userEntity.Email);
        }
    }
}
