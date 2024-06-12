namespace BudgetPlanner.Application
{
    //JWT-опции
    public class JWTOptions
    {
        public string ISSUER { get; set; } = "BudgetPlannerServer";
        public string AUDIENCE { get; set; } = "BudgetPlannerClient";
        public string KEY { get; set; } = "budget_planner_secret_key_from_client";
        public int EXPIRESHOURS { get; set; } = 12;
    }
}
