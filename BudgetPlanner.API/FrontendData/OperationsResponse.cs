namespace BudgetPlanner.API.FrontendData
{
    //Класс ответа на фронтенд
    public record OperationsResponse(
        Guid Id,
        DateTime Date,
        decimal Sum,
        string Type,
        string Reason);
}
