namespace BudgetPlanner.DataBase.Entities
{
    //Класс сущности пользователя
    public class UserEntity
    {
        //ID пользователя
        public Guid ID { get; set; }
        //username пользователя
        public string UserName { get; set; }
        //Захешированный пароль пользователя
        public string PasswordHash { get; set; }
        //mail пользователя
        public string Email { get; set; }
    }
}
