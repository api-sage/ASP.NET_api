using crudapi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace crudapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUser _user;
        private readonly IToken _token;

        public UserController(IUser user, IToken token)
        {
            _user = user;
            _token = token;
        }
        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> LoginRequest(Model.DTO.LoginParams login)
        {
            //Validate integrity of login details

            //Authenticate user

            Model.User AuthenticatedUser = await _user.AuthenticateUserAsync(login.UserName, login.Password);

            //Grant or deny access

            if (AuthenticatedUser != null)
            {
                //Generate JWT Token
                return Ok(await _token.GenerateToken(AuthenticatedUser));

            }
            return BadRequest("Invalid UserName and/or Password");
        }
    }
}
