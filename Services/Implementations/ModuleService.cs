//using Sem2WebAPI.Data;
//using Sem2WebAPI.Data.Entities;
//using Sem2WebAPI.Dtos;
//using Sem2WebAPI.Dtos.Request;

using SEM2WebAPI.Data;
using SEM2WebAPI.Data.Entities;
using SEM2WebAPI.Dtos;
using SEM2WebAPI.Dtos.Request;
using SEM2WebAPI.Services.Interfaces;

namespace Sem2WebAPI.Services.Implementations
{
    public class ModuleService(AppDbContext dbContext) : IModuleService
    {
        public async Task<ApiResponse<Module>> AddModuleAsync(ModuleCreateDto moduleDto)
        {
            Module module = new Module
            {
                Title = moduleDto.Title,
                Credits = moduleDto.Credit,
                CourseId = moduleDto.CourseId
            };

            dbContext.Modules.Add(module);
            await dbContext.SaveChangesAsync();
            return new ApiResponse<Module>
            {
                Success = true,
                Data = module,
                Message = "Success"
            };
        }

        //Task<ApiResponse<Module>> IModuleService.AddModuleAsync(ModuleCreateDto moduleDto)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<ApiResponse<Module>> AddModuleAsync(ModuleCreateDto moduleDto)
        //{
        //    // Validate the input DTO
        //    if (moduleDto == null)
        //    {
        //        return new ApiResponse<Module> { Success = false, Message = "Module data is required." };
        //    }

        //    // Create a new Module entity from the DTO
        //    var module = new Module
        //    {
        //        Title = moduleDto.Title,
        //        Credit = moduleDto.Credit,
        //        CourseId = moduleDto.CourseId
        //    };

        //    // Add the module to the database context
        //    await dbContext.Modules.AddAsync(module);
        //    await dbContext.SaveChangesAsync();

        //    // Return a successful response with the created module
        //    return new ApiResponse<Module> { Success = true, Data = module };
        //}
    }
}