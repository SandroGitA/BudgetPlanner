using BudgetPlanner.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetPlanner.DataBase.Configurations
{
    //Класс конфигурации сущности операции
    class OperationConfiguration : IEntityTypeConfiguration<OperationEntity>
    {
        public void Configure(EntityTypeBuilder<OperationEntity> builder)
        {
            //Настраиваем сущность, сделаем все поля обязательными
            //Поле id будет primary key
            builder.HasKey(k => k.ID);

            builder.Property(d => d.Date)
                .IsRequired();

            builder.Property(s => s.Sum)
                .IsRequired();

            builder.Property(a => a.Type)
                .IsRequired();

            builder.Property(r => r.Reason)
                .IsRequired();
        }
    }
}
