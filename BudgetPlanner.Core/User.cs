namespace BudgetPlanner.Core
{
    //Класс для описания модели пользователя
    public class User
    {
        //ID пользователя
        public Guid ID { get; set; }

        //username пользователя
        public string UserName { get; private set; }

        //Захешированный пароль пользователя
        public string PasswordHash { get; private set; }

        //mail пользователя
        public string Email { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        /// <param name="passwordHash"></param>
        /// <param name="email"></param>
        private User(Guid id, string userName, string passwordHash, string email)
        {
            ID = id;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
        }

        //Метод для создания пользователя
        public static User CreateUser(Guid id, string userName, string passwordHash, string email)
        {
            return new User(id, userName, passwordHash, email);
        }
    }
}
