using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEM2WebAPI.Data;
using SEM2WebAPI.Data.Entities;

namespace SEM2WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(AppDbContext dbContext) : ControllerBase //primary constructor
    {
        //private AppDbContext dbContext;
        //public CoursesController(AppDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //} yo code lai primary constructor lekhna sakinchha jasma constructor ko body nai haina ra dbContext lai parameter ma lkhna sakinchha



        [HttpPost("add")] //api/Courses/add , add rakhdani huncha or just [httppost] matra lkehda hunchas post means add so
        public IActionResult AddCourse(Course course)
        {
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();
            return Ok("Successfully Created!"); //return type void cha vane return statement ma kunai pani value return garna mildaina but yaha return statement ma string return garna khojeko cha so return type void bata IActionResult ma change garna parcha
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var allCourses = dbContext.Courses.ToListAsync();
            return Ok(allCourses);
        }

        [HttpGet("modules")]
        public async Task<IActionResult> GetAllCoursesWithModules()
        {
            var allCourses = dbContext.Courses.Select(
                c=> new {c.Id, c.Name, c.DurationYears, c.Module.Count, c.Module}
                
                )
                
                .ToListAsync();
            return Ok(allCourses);
        }
    }
}
