namespace University.Core.Models
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public int TeacherId{ get; private set; }
        public string CourseName { get; set; }
        public int Unit { get; set; }
        public string CourseGp { get; set; }
        public bool IsOptional { get; private set; }

    }
}
