using Microsoft.AspNetCore.Mvc;
using YetAnotherStore.Core.Dtos;
using YetAnotherStore.Core.ServiceContracts;

namespace YetAnotherStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUsersService usersService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest? registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest("Invalid registration request");
            }

            var authResponse = await usersService.RegisterAsync(registerRequest);

            if (authResponse?.Success == false)
            {
                return BadRequest(authResponse);
            }

            return Created(nameof(Login), authResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest? loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Invalid login request");
            }

            var authResponse = await usersService.LoginAsync(loginRequest);

            if (authResponse?.Success == false)
            {
                return Unauthorized(authResponse);
            }

            return Ok(authResponse);
        }
    }
}
