namespace BudgetPlanner.Application
{
    //JWT-опции
    public class JWTOptions
    {
        public string ISSUER { get; set; } = string.Empty;
        public string AUDIENCE { get; set; } = string.Empty;
        public string KEY { get; set; } = string.Empty;
        public int EXPIRESHOURS { get; set; }
    }
}
