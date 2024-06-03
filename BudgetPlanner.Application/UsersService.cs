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
        private readonly PasswordHasher _passwordHasher;

        public UsersService(PasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public void Register(string username, string email, string password)
        {
            var hashPassword = _passwordHasher.Hashed(password);
        }
    }
}
