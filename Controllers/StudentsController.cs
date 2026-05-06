using Microsoft.AspNetCore.Mvc;
using SEM2WebAPI.Models;
using Microsoft.Extensions.Options;
namespace SEM2WebAPI.Controllers

{
    [ApiController]
    [Route("[controller]")]  //base route sabai mthod ma /student lekhnu vanda route esari lekhesi we dont have to write /students in all method
    public class StudentsController(IConfiguration config): ControllerBase
    {

        
        private static List<Student> _students = [];



        //POST: students/add - post request

        [HttpPost("add")]
        public IActionResult Add(Student student)
        {
            _students.Add(student);
            return Created($"students/getbyid/{student.Id}","Succesfully Added");

        }

        [HttpGet("getall")] //ekaichoti dina milcha no need to write in diff lines
        //[Route("students/getall")]
        public List<Student> GetStudentsName()
        {
            return _students;
        }

        //GET: students/getbyid/1 - get request

        [HttpGetAttribute("getbyid/{id:int}")]
        public IActionResult GetById(int id)
        {
            Student? student = _students.FirstOrDefault(s => s.Id == id); //null ni return garna sakcha  so question mark

            if (student == null)
            {
                return NotFound($"Student haveing id {id} is not found.");
            }

            return Ok(student);
        }

        [HttpPut("update/{id:int}")]
        public IActionResult Update(int id, Student updatedStudent)
        {
            Student? student = _students.FirstOrDefault(s => s.Id == id); //null ni return garna sakcha  so question mark

            if (student == null)
            {
                return NotFound($"Student haveing id {id} is not found.");
            }

            student.Name= updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.Age = updatedStudent.Age;

            return Ok("Sucessfully Updated");
        }

        [HttpDelete("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            Student? student = _students.FirstOrDefault(s => s.Id == id); //null ni return garna sakcha  so question mark

            if (student == null)
            {
                return NotFound($"Student haveing id {id} is not found.");
            }

            _students.Remove(student);
            return Ok("Successfully Deleted.");
        }

        [HttpGet("Setings")]
        public IActionResult GetStudentFromSetting(IOptions<Student> options)
        {
            //int id = Convert.ToInt32(config["Student:Id"]);
            //string name = config["Student:Name"]!; //nested configuration //question mark if null auna sakcha,  exclamation marks vaneko null audai audena vaneko
            //string email = config["Student:Email"]!;
            //int age = Convert.ToInt32(config["Student:Age"]);

            //return Ok(new Student { Id = id, Name = name, Email = email, Age = age }); //anonymous object

            Student student = options.Value; //options ma value huncha tyo student ma rakhne
            return Ok(student);
        }

        //Ioptions c# ko object create gardine and object ma jun value huncha tyo pani c# le afai set gardincha we dont need to set value manually 
        //need object ani framework le afai create gardincha we dont need to create - Dependency Injection


    }
}
