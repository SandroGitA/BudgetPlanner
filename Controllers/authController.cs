using BudgetPlanner.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BudgetPlanner.Controllers
{
    //Класс регистрации и авторизации пользователя
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class authController : ControllerBase
    {
        //Метод для регистрации пользователя
        [HttpPost(Name = "registry")]
        public string Registry([FromBody] UserInfo userInfo)
        {
            //Добавляем данные о пользователе в БД
            using (BPContext bpContext = new BPContext())
            {
                bpContext.accounts.Add(userInfo);
                bpContext.SaveChanges();

                return "Registration successful";
            }
        }

        //Метод проверки существования имени пользователя в БД
        [HttpPost(Name = "check-username")]
        public bool CheckUsername([FromBody] UsernameCheck inputNewLogin)
        {
            using (BPContext bpContext = new BPContext())
            {
                //Получение всех пользователей в БД
                var users = bpContext.accounts.ToList();
                if (users.Any(account => account.Login == inputNewLogin.inputNewLogin))
                {
                    //Если такой логин есть, возвращаем true, такой добавить больше нельзя
                    return true;
                }
                else
                {
                    //Иначе false, можно добавить
                    return false;
                }
            }
        }

        //Метод авторизации пользователя
        [HttpPost(Name = "login")]
        public IResult Login([FromBody] UserLogin inputNewLoginAuth)
        {
            //Делаем проверку на ввод правильных логина и пароля
            //для этого достаем их из БД
            using (BPContext bpContext = new BPContext())
            {
                //Получаем всех пользователей
                var users = bpContext.accounts.ToList();
                //Находим запись в таблице с таким логином
                bool isLoginExists = users.Any(account => account.Login == inputNewLoginAuth.inputNewLogin);
                //Если такого пользователя не существует, отдаем пользователю json с ошибкой
                if (!isLoginExists)
                {
                    var response = new
                    {
                        status = 406,
                        text = "Такого пользователя не существует",
                        data = DateTime.Now.ToString(),
                    };

                    //return Results.Text("Такого пользователя не существует");
                    return Results.Json(response);
                }

                //Если такой пользователь существует, сравниваем пароль с тем что пришел в запросе
                bool isPasswordMatches = users.Any(account => account.Password == inputNewLoginAuth.inputPasswordAuth);
                if (isPasswordMatches)
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, inputNewLoginAuth.inputNewLogin) };

                    var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromSeconds(30)),//время действия 30 секунд
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                    //Создаем токен
                    string encodedJWT = new JwtSecurityTokenHandler().WriteToken(jwt);

                    //Формируем ответ для пользователя
                    JSONResponse jsonResponse = new JSONResponse();
                    jsonResponse.access_token = encodedJWT;
                    //jsonResponse.refresh_token = GenerateRefreshToken();//Генерируем refresh токен сразу
                    jsonResponse.user_name = inputNewLoginAuth.inputNewLogin;
                    //Передаем время жизни токена, возможно придется убрать
                    jsonResponse.expire = Convert.ToString(jwt.Payload.Exp);

                    return Results.Json(jsonResponse);
                    //return "Авторизация успешна";
                }
                else
                {
                    //Иначе пароль не верный
                    var response = new
                    {
                        status = 405,
                        text = "Неверный логин или пароль",
                        data = DateTime.Now.ToString(),
                    };

                    return Results.Json(response);
                }
            }
        }

        //Метод для генерации refresh токена
        [HttpGet]
        public string GenerateRefreshToken()
        {
            var byteArray = new byte[32];
            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(byteArray);
                return Convert.ToBase64String(byteArray);
            }
        }

        //Метод для сохранения refresh токена в БД
        [HttpGet]
        public void SaveRefreshToken()
        {

        }
    }
}
