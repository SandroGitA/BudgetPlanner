using BudgetPlanner.Application;
using BudgetPlanner.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        public OperationsController(OperationsService operationsService)
        {
            
        }
    }
}
