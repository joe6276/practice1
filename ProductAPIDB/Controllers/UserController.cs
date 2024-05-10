using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductAPIDB.Models.DTOS;
using ProductAPIDB.Services.IServices;

namespace ProductAPIDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> addUser(RegisterUser newUser)
        {
            var response= await _user.addUser(newUser);
            if (!string.IsNullOrEmpty(response))
            {
                return BadRequest(response);
            }
            return Created("", response);
        }


        [HttpPost("login")]
        public async Task<ActionResult<string>> loginUser(LoginDetails user)
        {
            var response = await _user.login(user);
            if (response.User==null)
            {
                return BadRequest("username or password is incorrect");
            }
            return Ok(response);
        }

        [HttpPost("assign")]
        public async Task<ActionResult<string>> loginUser(  string Email,  string roleName)
        {
            var response = await _user.AssignRole(Email,roleName.ToUpper());
            if (!response)
            {
                return BadRequest("Error occured!1");
            }
            return Ok(response);
        }
    }
}
