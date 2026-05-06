using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEM2WebAPI.Dtos.Request;
using SEM2WebAPI.Services.Interfaces;

namespace SEM2WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController (IAuthService authService): ControllerBase
    {
        [HttpPost("register/studemt")]
        public void RegisterStudent()
        {

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var loginResponce = await authService.LoginAsync(loginDto);
            return loginResponce.Success ? Ok(loginResponce) : Unauthorized(loginResponce);
        }
    }
}
