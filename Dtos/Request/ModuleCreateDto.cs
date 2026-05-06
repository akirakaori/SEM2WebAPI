using System.ComponentModel.DataAnnotations;

namespace SEM2WebAPI.Dtos.Request
{
    public class ModuleCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Range(10, 30)] //depends on business rules
        public int Credit { get; set; }

        public int CourseId { get; set; }

        
    }
}
