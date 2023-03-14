namespace University.Core.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDay { get; set; }

        public Field Field { get; set; }
        public int FieldId { get; set; }
        public List<User> Users { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }


        public Student(string name , string lastName , int nationalCode , string phoneNumber , string birthDay , int fieldId )
        {
            Name = name;
            LastName = lastName;
            NationalCode = nationalCode;
            PhoneNumber = phoneNumber;
            BirthDay = birthDay;
            FieldId = fieldId;
        }
    }
}
