using SEM2WebAPI.Dtos.Request;
using SEM2WebAPI.Dtos.Response;

namespace SEM2WebAPI.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<Loginresponse> LoginAsync(LoginDto loginDto); // interface vitra login async huncha this is called by loginapi
    }
}