namespace BudgetPlanner.Logic
{
    //Класс для авторизации пользователя
    public class UserLogin()
    {
        public string inputNewLogin { get; set; }
        public string inputPasswordAuth { get; set; }
    }

    //Класс для проверки существования логина в БД
    public class UsernameCheck()
    {
        public string inputNewLogin { get; set; }
    }

    //Класс для отправки данных авторизации клиенту
    public class JSONResponse()
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string user_name { get; set; }
        public string expire { get; set; }
    }
}
