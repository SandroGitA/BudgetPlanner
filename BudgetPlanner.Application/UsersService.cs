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

        public void Register(string username, string email, string password)
        {
            var hashPassword = _passwordHasher.Hashed(password);

            var user = User.CreateUser(Guid.NewGuid(), username, hashPassword, email);

            _usersRepository.AddUser(user);
        }
    }
}
