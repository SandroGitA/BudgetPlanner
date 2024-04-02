namespace BudgetPlanner.Core
{
    //Класс для описания модели операции
    public class Operation
    {
        //ID операции
        public Guid ID { get; }
        //Дата операции
        public DateTime Date { get; }
        //Количество денег потраченных или заработанных
        public decimal Sum { get; }
        //Вид движения денежных средств
        public string Type { get; } = string.Empty;
        //Причина движения денежных средств
        public string Reason { get; } = string.Empty;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор операции</param>
        /// <param name="dateTime">Дата операции</param>
        /// <param name="sum">Сумма операции</param>
        /// <param name="type">Тип операции</param>
        /// <param name="reason">Причина операции</param>
        private Operation(Guid id, DateTime dateTime, decimal sum, string type, string reason)
        {
            ID = id;
            Date = dateTime;
            Sum = sum;
            Type = type;
            Reason = reason;
        }

        //Валидация при создании операции
        public static Operation CreateOperation(decimal sum, string type, string reason)
        {
            //Поле дата и id создаются сами в момент совершения операции
            Guid id = Guid.NewGuid();
            DateTime dateTime = DateTime.Now;

            var operation = new Operation(id, dateTime, sum, type, reason);

            return operation;
        }

    }
}
