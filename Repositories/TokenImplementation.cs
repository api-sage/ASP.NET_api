using crudapi.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace crudapi.Repositories
{
    public class TokenImplementation : IToken
    {
        private readonly IConfiguration _configuration;

        public TokenImplementation(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<string> GenerateToken(Model.User client)
        {
            //Assigning key
            SymmetricSecurityKey Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            //creating claims
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, client.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, client.LastName));
            claims.Add(new Claim(ClaimTypes.Email, client.EmailAddress));

            //loop into roles of users
            client.Roles.ForEach((role) =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });

            SigningCredentials Credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken Token = new JwtSecurityToken(
                _configuration["JWT:Issuer"],
                _configuration["JWT:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: Credentials
                );

            string TokenToConsume = new JwtSecurityTokenHandler().WriteToken(Token);

            return Task.FromResult(TokenToConsume);
        }
    }
}
