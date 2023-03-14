namespace University.Core.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherLastName { get; set; }
        public int TeacherNationalCode { get; set; }
        public string LastDiploma { get; set; }
        public string TeacherBirthDay { get; set; }

        public List<User> Users { get; set; }
        public List<Course> Courses { get; set; }
        public Teacher(string teacherName , string teacherLastName , int teacherNationalCode, string lastDiploma , string teacherBirthDay )
        {
            TeacherName = teacherName;
            TeacherLastName = teacherLastName;
            TeacherNationalCode = teacherNationalCode;
            LastDiploma = lastDiploma;
            TeacherBirthDay = teacherBirthDay;

        }

    }
}
