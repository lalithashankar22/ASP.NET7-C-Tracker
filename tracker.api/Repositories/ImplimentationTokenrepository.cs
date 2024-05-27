using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace tracker.api.Repositories
{
    public class ImplimentationTokenrepository : InterfaceTokenRepository
    {
        private readonly IConfiguration config;

        public ImplimentationTokenrepository(IConfiguration configuration)
        {
            this.config = configuration;
        }


        public string CreateJWT(IdentityUser user, List<string> roles)
        {
            //create cliams from roles

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["jwt:key"]));
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                config["jwt:issuer"],
                config["jwt:audience"],
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes(120), //validity of the token 
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
       
        }
    }
}
