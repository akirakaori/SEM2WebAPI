namespace SEM2WebAPI.Data.Entities
{
    public class Module
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; } // Navigation Property for related Course
        public int Credit { get; internal set; }
    }
}
