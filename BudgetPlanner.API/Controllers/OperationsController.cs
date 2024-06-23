using BudgetPlanner.API.FrontendData;
using BudgetPlanner.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly OperationsService _operationsService;

        public OperationsController(OperationsService operationsService)
        {
            _operationsService = operationsService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<OperationsResponse>> GetOperations()
        {
            var operations = _operationsService.GetOperations();

            var response = operations.Select(o => new OperationsResponse(o.ID, o.Date, o.Sum, o.Type, o.Reason));

            return Ok(response);
        }
    }
}
