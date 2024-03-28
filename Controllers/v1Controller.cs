using BudgetPlanner.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BudgetPlanner.Controllers
{
    //Класс для работы с данными пользователя
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class v1Controller : ControllerBase
    {
        //Метод для добавления причины траты
        [Authorize]
        [HttpPost]
        public bool AddReason([FromBody] UserOperation userOperation)
        {
            using (BPContext bpContext = new BPContext())
            {
                //Сохраняем детали операции в БД
                bpContext.operations.Add(userOperation);
                bpContext.SaveChanges();

                return true;
            }
        }

        //Тестовый метод
        [HttpGet]
        public void Test()
        {
            ///
        }
    }
}
