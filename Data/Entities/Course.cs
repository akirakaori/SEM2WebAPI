using System.ComponentModel.DataAnnotations;

namespace SEM2WebAPI.Data.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null; //meaning value halcha ki nai sure ho vanna khojeko but =null value le ma pachi halchu value vaneko
        public int DurationYears { get; set; }
        public int ModuleCount { get; set; } // New property to store the count of related Modules

        public List<Module> Module { get; set; } = []; // Navigation Property for related Modules
    }
}
