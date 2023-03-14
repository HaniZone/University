namespace University.Core.Models
{
    public class SelectUnitCourse
    {
        public int SelectUnitCourseId { get; set; }
        public int Capability { get; set; }
        public SelectUnit SelectUnit { get; set; }
        public Course Course { get; set; }
        public SelectUnitCourse( int capability)
        {
            Capability = capability;
        }
    }
}
