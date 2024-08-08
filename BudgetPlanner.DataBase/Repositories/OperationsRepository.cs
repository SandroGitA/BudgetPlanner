using BudgetPlanner.Core;
using BudgetPlanner.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.DataBase.Repositories
{
    //Класс репозитория для CRUD операции с "операциями пользователя"
    public class OperationsRepository
    {
        private readonly BudgetPlannerDbContext _context;

        public OperationsRepository(BudgetPlannerDbContext context)
        {
            _context = context;
        }

        //Метод возврата всех операции
        public List<Operation> Get()
        {
            var operationsEntities = _context.Operations.AsNoTracking().ToList();

            var operations = operationsEntities
                .Select(o => Operation.CreateOperation(o.Sum, o.Type, o.Reason)).ToList();

            return operations;
        }

        //Метод создания операции
        public Guid Create(Operation operation)
        {
            var operationEntity = new OperationEntity
            {
                ID = operation.ID,
                Reason = operation.Reason,
                Sum = operation.Sum,
                Type = operation.Type,
                Date = operation.Date,
            };

            _context.Operations.Add(operationEntity);
            _context.SaveChanges();

            return operationEntity.ID;
        }

        //Метод изменения операции
        public Guid Update(Guid guid, string reason, decimal sum, string type, DateTime date)
        {
            _context.Operations
                .Where(o => o.ID == guid)
                .ExecuteUpdate(s => s
                    .SetProperty(o => o.Sum, o => sum)
                    .SetProperty(o => o.Type, o => type)
                    .SetProperty(o => o.Reason, o => reason)
                    .SetProperty(o => o.Date, o => date));

            return guid;
        }

        //Метод удаления операции
        public Guid Delete(Guid guid)
        {
            _context.Operations
                .Where(o => o.ID == guid)
                .ExecuteDelete();

            return guid;
        }
    }
}
