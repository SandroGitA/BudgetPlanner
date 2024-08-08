using BudgetPlanner.API.FrontendData;
using BudgetPlanner.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.API.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly OperationsService _operationsService;

        public OperationsController(OperationsService operationsService)
        {
            _operationsService = operationsService;
        }

        //Получение всех операции
        [HttpGet("operations")]
        //[Authorize]
        public ActionResult<List<OperationsResponse>> GetOperations()
        {
            var operations = _operationsService.GetOperations();

            var response = operations.Select(o => new OperationsResponse(o.ID, o.Date, o.Sum, o.Type, o.Reason));

            return Ok(response);
        }

        //Добавление операции
        [HttpPost("add")]
        public ActionResult AddOperation()
        {
            return Ok();
        }

        //Удаление операции
        [HttpPost("delete")]
        public ActionResult DeleteOperation()
        {
            return Ok();
        }

        //Изменение операции
        [HttpPost("edit")]
        public ActionResult EditOperation()
        {
            return Ok();
        }
    }
}
