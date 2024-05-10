using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductAPIDB.Models;
using ProductAPIDB.Services.IServices;
using ProductAPIDB.Utility;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductAPIDB.Services
{
    public class JwtService : IJwt
    {
        private readonly JwtOptions _jwtOptions;
        public JwtService(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }
        public string generateToken(User user, IEnumerable<string> roles)
        {   

            //read the secret key  then changes to bytes
           var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
            //hashing mechanism to be used to sign the payload
           var creds= new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //claims === payload

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));

            //roles 
            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

            //token Descriptor

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Audience = _jwtOptions.Audience,
                Issuer = _jwtOptions.Issuer,
                Expires = DateTime.UtcNow.AddHours(3),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = creds
            };

            //create token 
            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
