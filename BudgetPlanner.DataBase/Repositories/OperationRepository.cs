using BudgetPlanner.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.DataBase.Repositories
{
    //Класс репозитория для CRUD операции с "операциями пользователя"
    public class OperationRepository
    {
        private readonly BudgetPlannerDbContext _context;

        public OperationRepository(BudgetPlannerDbContext context)
        {
            _context = context;
        }

        //Метод возврата всех операции
        public List<OperationEntity> GetOperations()
        {
            var operations = _context.Operations.AsNoTracking().ToList();

            return operations;
        }
    }
}
