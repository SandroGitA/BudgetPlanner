using BudgetPlanner.Core;
using BudgetPlanner.DataBase.Repositories;

namespace BudgetPlanner.Application.Services
{
    //Класс прослойки между контроллерами и репозиторием,
    public class OperationsService
    {
        private readonly OperationsRepository _operations;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="operations"></param>
        public OperationsService(OperationsRepository operations)
        {
            _operations = operations;
        }

        /// <summary>
        /// Метод получения операции
        /// </summary>
        /// <returns></returns>
        public List<Operation> GetOperations()
        {
            return _operations.Get();
        }

        /// <summary>
        /// Метод создания операции
        /// </summary>
        /// <returns></returns>
        public Guid CreateOperation(Operation operation)
        {
            return _operations.Create(operation);
        }

        /// <summary>
        /// Метод обновления операции
        /// </summary>
        /// <returns></returns>
        public Guid UpdateOperation(Guid guid, string reason, decimal sum, string type, DateTime date)
        {
            return _operations.Update(guid, reason, sum, type, date);
        }

        /// <summary>
        /// Метод удаления операции
        /// </summary>
        /// <param name="guid"></param>
        public Guid DeleteOperation(Guid guid)
        {
            return _operations.Delete(guid);
        }
    }
}
