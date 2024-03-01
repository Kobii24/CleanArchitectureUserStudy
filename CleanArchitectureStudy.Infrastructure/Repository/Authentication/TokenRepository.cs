using CleanArchitectureStudy.Application.Service;
using CleanArchitectureStudy.Application.VM;
using CleanArchitectureStudy.Domain.Models;
using CleanArchitectureStudy.Infrastructure.Repository.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudy.Infrastructure.Repository.Authentication
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _repo;
        
        private static Dictionary<string, string> UsersRecords = new Dictionary<string, string>
        {

                 { "admin@gmail.com","123456"},
                 { "password","password"}
        };

        public TokenRepository(IConfiguration configuration, IUserRepository repo)
        {
            _configuration = configuration;
            _repo = repo;
        }
        public Token Authenticator(User user)
        {
            if (!UsersRecords.Any(x => x.Key == user.userEmail && x.Value == user.passWord))
            {
                return null;
            }
            //We have Authenticated
            //Generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Email, user.userEmail),
             new Claim(ClaimTypes.Name, user.userName)
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Token { token = tokenHandler.WriteToken(token) };
        }
    }
}
