using Microsoft.AspNetCore.Identity;
using SEM2WebAPI.Data.Entities;
using SEM2WebAPI.Dtos.Request;
using SEM2WebAPI.Dtos.Response;
using SEM2WebAPI.Services;
using SEM2WebAPI.Services.Interfaces;

namespace Sem2WebAPI.Services.Implementations
{
    public class AuthService(SignInManager<User> signInManager, UserManager<User> userManager, JwtService jwtService) : IAuthService
    {
        public async Task<Loginresponse> LoginAsync(LoginDto loginDto)
        {
            User? user = await userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return new Loginresponse
                {
                    Success = false,
                    Message = "User Not Found."
                };
            }
            var signInResult = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, lockoutOnFailure: false);
            if (!signInResult.Succeeded)
            {
                return new Loginresponse
                {
                    Success = false,
                    Message = "Invalid email or password."
                };
            }
            return new Loginresponse
            {
                Success = true,
                Message = "Login successful.",
                Token = jwtService.GenerateToken(user)
            };
        }
    }
}