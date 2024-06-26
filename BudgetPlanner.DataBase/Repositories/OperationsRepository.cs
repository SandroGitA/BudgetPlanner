﻿using BudgetPlanner.Core;
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
            return Guid.NewGuid();
        }

        //Метод изменения операции
        public Guid Update(Guid guid)
        {
            return Guid.NewGuid();
        }

        //Метод удаления операции
        public Guid Delete(Guid guid)
        {
            return Guid.NewGuid();
        }
    }
}
