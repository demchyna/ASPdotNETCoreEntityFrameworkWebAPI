using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPdotNETCoreEntityFrameworkWebAPI.DAL;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace ASPdotNETCoreEntityFrameworkWebAPI.Security
{
    [Produces("text/html")]
    [Route("api/login")]
    public class AuthenticationController : Controller
    {
        private UserDal userDal;

        public AuthenticationController(UserDal userDal)
        {
            this.userDal = userDal;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult GenerateToken([FromBody]Credentials credentials)
        {
            var user = userDal.GetByUsername(credentials.Username);

            if(user != null)
            {
                if(user.Password.Equals(credentials.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                        new Claim("id", user.Id.ToString()),
                        new Claim("role", user.Role.Name),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthenticationOptions.SIGNING_KEY));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: creds);

                    var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

                    Request.HttpContext.Response.Headers.Add("Authorization", "Bearer " + encodedToken);

                    return Ok();
                }
            }
            return BadRequest("Could not create token");
        }
    }
}