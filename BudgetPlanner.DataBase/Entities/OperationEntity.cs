namespace BudgetPlanner.DataBase.Entities
{
    //Класс сущности операции
    public class OperationEntity
    {
        //ID операции
        public Guid ID { get; set; }
        //Дата операции
        public DateTime? Date { get; set; }
        //Количество денег потраченных или заработанных
        public decimal? Sum { get; set; }
        //Вид движения денежных средств
        public string? Ante { get; set; }
        //Причина движения денежных средств
        public string? Reason { get; set; }
    }
}
