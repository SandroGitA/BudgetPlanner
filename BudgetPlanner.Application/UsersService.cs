using BudgetPlanner.Core;
using BudgetPlanner.DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Application
{
    //Класс для регистрации пользователей
    public class UsersService
    {
        private readonly UsersRepository _usersRepository;
        private readonly PasswordHasher _passwordHasher;

        public UsersService(UsersRepository usersRepository, PasswordHasher passwordHasher)
        {
            _usersRepository = usersRepository;
            _passwordHasher = passwordHasher;
        }

        //Метод для регистрации пользователя
        public void Register(string username, string email, string password)
        {
            var hashPassword = _passwordHasher.Hashed(password);

            var user = User.CreateUser(Guid.NewGuid(), username, hashPassword, email);

            _usersRepository.AddUser(user);
        }

        //Метод для логина пользователя
        public string Login(string email, string password)
        {
            var user = _usersRepository.GetUserByEmail(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result == false)
            {
                throw new Exception("Failed to login");
            }

            return "";
        }
    }
}
