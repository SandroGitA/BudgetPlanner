using BudgetPlanner.Core;
using BudgetPlanner.DataBase.Repositories;

namespace BudgetPlanner.Application
{
    //Класс для оисания логики приложения для связи с контроллерами
    public class BudgetPlannerService
    {
        private readonly OperationsRepository _operations;

        //Конструктор
        public BudgetPlannerService(OperationsRepository operations)
        {
            _operations = operations;
        }

        public List<Operation> GetOperations()
        {
            return _operations.Get();
        }
    }
}
