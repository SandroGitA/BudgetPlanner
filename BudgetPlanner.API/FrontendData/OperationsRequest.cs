namespace BudgetPlanner.API.FrontendData
{
    //Класс ответа на фронтенд
    public record OperationsRequest(
        decimal Sum,
        string Type,
        string Reason);
}
