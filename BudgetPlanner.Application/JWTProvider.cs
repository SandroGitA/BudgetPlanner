using BudgetPlanner.Core;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace BudgetPlanner.Application
{
    //Класс генерации JWT-токена
    public class JWTProvider
    {
        private readonly JWTOptions _options;

        public JWTProvider(IOptions<JWTOptions> options)
        {
            _options = options.Value;
        }

        public string GenerateToken(User user)
        {
            Claim[] claims = [new("userid", user.ID.ToString())];

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.KEY)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(_options.EXPIRESHOURS),
                issuer: _options.ISSUER,
                audience: _options.AUDIENCE);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
