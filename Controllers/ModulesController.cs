using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Sem2WebAPI.Data.Entities;
//using Sem2WebAPI.Dtos.Request;
//using Sem2WebAPI.Services.Interfaces;
using SEM2WebAPI.Dtos.Request;
using SEM2WebAPI.Services.Interfaces;

namespace Sem2WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController(IModuleService moduleService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddModule(ModuleCreateDto moduleDto)
        {
            var response = await moduleService.AddModuleAsync(moduleDto);
            return Ok(response);
        }


    }
}