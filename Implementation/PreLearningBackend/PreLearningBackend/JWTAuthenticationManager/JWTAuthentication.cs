using Microsoft.IdentityModel.Tokens;
using PreLearningBackend.Context;
using PreLearningBackend.Models.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PreLearningBackend.JWTAuthenticationManager
{
    public class JWTAuthentication : IJWTAuthentication
    {
        private readonly AppDbContext _context;
      

        public JWTAuthentication(AppDbContext context)
        {
            _context = context;
        }
        /*  public JWTAuthentication(string key)
          {
              _key = key;
          }*/


        public string Login(string email, string password)
        {
            var _key = "This is my long private SecretKey";
            Mind mind = _context.Minds.SingleOrDefault(user => user.Email.Equals(email) && user.Password.Equals(password));
            if (mind is null)
                return null;

            var userRole = _context.Roles.Find(mind.RoleId);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokeyKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                  new Claim(ClaimTypes.Email,email),
                  new Claim(ClaimTypes.Role, userRole.Name)
               }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
        new SymmetricSecurityKey(tokeyKey),
        SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
