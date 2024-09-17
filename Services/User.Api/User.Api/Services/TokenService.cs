using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using User.Api.Interfaces;
using User.Api.Models;

namespace User.Api.Services
{
    public static class TokenService
    {
        public static Token CreateToken(CustomIdentityUser usuario)
        {
            Claim[] direitosUsuario = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id.ToString()),
            };

            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("minhachavesupersecreta")
            );

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: direitosUsuario,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            
            return new Token(tokenString);
        }
    }
}