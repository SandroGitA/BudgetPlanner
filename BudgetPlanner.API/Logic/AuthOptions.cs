using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BudgetPlanner.Logic
{
    public class AuthOptions
    {
        public const string ISSUER = "BudgetPlannerServer";//издатель токена
        public const string AUDIENCE = "BudgetPlannerClient";//потребитель токена
        const string KEY = "budget_planner_secret_key_from_client";//ключ для шифрации

        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
