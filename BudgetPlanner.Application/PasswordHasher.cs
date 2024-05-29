namespace BudgetPlanner.Application
{
    //Класс для хеширования паролей
    public class PasswordHasher
    {
        public string Hashed(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public bool Verify(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
        }
    }
}
