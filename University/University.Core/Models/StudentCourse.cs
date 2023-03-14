namespace University.Core.Models
{
    public class StudentCourse
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public StudentCourse(int studentId , int courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}
