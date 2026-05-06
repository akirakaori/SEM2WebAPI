using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SEM2WebAPI.Services
{
    public class JwtService(IConfiguration config)
    {
        public string GenerateToken(Data.Entities.User user)
        {
            string secretKey = config["Jwt:SecretKey"]!; //config ma Jwt:Key vanne key ma secret key hun
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretKey"));
            var signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
                
            var tokenObj = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"], //config ma Jwt:Issuer vanne key ma issuer huncha
                audience: config["Jwt:Audience"], //config ma Jwt:Audience vanne key ma audience huncha
                claims: [],
                signingCredentials:  signingCredentials,
                expires : DateTime.UtcNow.AddMinutes(Convert.ToDouble(config["Jwt:ExpiresInMinutes"]!))
                );
           string token = new  JwtSecurityTokenHandler().WriteToken(tokenObj);
           return token;

        }
    }
}
