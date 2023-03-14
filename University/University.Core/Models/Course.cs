namespace University.Core.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public bool IsOptional { get; private set; }
        public int Unit { get; set; }
        public string CourseGp { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
        public List<SelectUnitCourse> SelectUnitCourses { get; set; }

        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public Course(int teacherId ,  string courseName , int unit , string courseGp , bool isOptional )
        {
            TeacherId = teacherId;
            CourseName = courseName;
            Unit = unit;
            CourseGp = courseGp;
            IsOptional = isOptional;
        }
        public void Optional()
        {
            IsOptional = true;
        }

        public void NotOptional()
        {
            IsOptional = false;
        }
    }
}
