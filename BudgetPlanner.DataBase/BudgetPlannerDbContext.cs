﻿using BudgetPlanner.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.DataBase
{
    //Класс для настройки контекста БД с помощью EntityFrameworkCore
    public class BudgetPlannerDbContext : DbContext
    {
        public BudgetPlannerDbContext(DbContextOptions<BudgetPlannerDbContext> options)
            : base(options) { }

        public DbSet<OperationEntity> Operations { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
