using BudgetPlanner.API.FrontendData;
using BudgetPlanner.Application.Services;
using BudgetPlanner.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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
        [HttpGet("get")]
        public ActionResult<List<OperationsResponse>> GetOperations()
        {
            var operations = _operationsService.GetOperations();
            var response = operations.Select(o => new OperationsResponse(o.ID, o.Date, o.Sum, o.Type, o.Reason));

            return Ok(response);
        }

        /// <summary>
        /// Запрос на добавление операции
        /// </summary>
        /// <returns></returns>
        [HttpPost("add")]
        public ActionResult<Guid> AddOperation([FromBody] OperationsRequest request)
        {
            var operation = Operation.CreateOperation(request.Sum, request.Type, request.Reason);
            var operationID = _operationsService.CreateOperation(operation);

            return Ok(operationID);
        }

        /// <summary>
        /// Запрос на изменение операции
        /// </summary>
        /// <returns></returns>
        [HttpPost("edit={guid}")]
        public ActionResult<Guid> EditOperation(Guid guid, [FromForm] OperationsRequest request)
        {
            var operationID = _operationsService.UpdateOperation(guid, request.Reason, request.Sum, request.Type, DateTime.UtcNow);
            return Ok(operationID);
        }

        /// <summary>
        /// Запрос на удаление операции
        /// </summary>
        /// <returns></returns>
        [HttpPost("delete={guid}")]
        public ActionResult<Guid> DeleteOperation(Guid guid)
        {
            var operationID = _operationsService.DeleteOperation(guid);
            return Ok(operationID);
        }
    }
}
