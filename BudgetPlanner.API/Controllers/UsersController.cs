using BudgetPlanner.API.DTO;
using BudgetPlanner.Application;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.API.Controllers
{
    [Route("api/register/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //Метод регистрации пользователя
        [HttpPost("register")]
        public IResult Register(
            RegisterUserRequest request,
            UsersService usersService)
        {
            usersService.Register(request.Username, request.Email, request.Password);

            return Results.Ok();
        }

        //Метод логина пользователя
        [HttpPost("login")]
        public IResult Login(
            LoginUserRequest request,
            UsersService usersService)
        {
            var token = usersService.Login(request.Email, request.Password);

            return Results.Ok(token);
        }
    }
}
