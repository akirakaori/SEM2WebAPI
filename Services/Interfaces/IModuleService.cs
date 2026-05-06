using SEM2WebAPI.Data.Entities;
using SEM2WebAPI.Dtos;
using SEM2WebAPI.Dtos.Request;

namespace SEM2WebAPI.Services.Interfaces
{
    public interface IModuleService
    {
        public Task<ApiResponse<Module>> AddModuleAsync(ModuleCreateDto moduleDto);

        //update, delete, get by id, get all etc. can be added here as needed

    }
}
