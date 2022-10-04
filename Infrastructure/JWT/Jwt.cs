using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace infrastructure.JWT;

public class JwtToken
{
    public string Create (int userId)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("8jku18nfjsoifjsaifjoiasjfasoifjsio"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var tokenDescription = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new List<Claim>()
            {
                new Claim("sub", userId.ToString())
            }),
            SigningCredentials = credentials
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescription);
        var stringToken = tokenHandler.WriteToken(token);
        return stringToken;
    }
}