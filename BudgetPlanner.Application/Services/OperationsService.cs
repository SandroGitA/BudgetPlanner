using BudgetPlanner.Core;
using BudgetPlanner.DataBase.Repositories;

namespace BudgetPlanner.Application.Services
{
    //Класс для описания логики приложения для связи с контроллерами
    public class OperationsService
    {
        private readonly OperationsRepository _operations;

        //Конструктор
        public OperationsService(OperationsRepository operations)
        {
            _operations = operations;
        }

        public List<Operation> GetOperations()
        {
            return _operations.Get();
        }
    }
}
