namespace University.Core.Models
{
    public class SelectUnit
    {
        public int SelectUnitId { get; set; }
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }
        public int Limit { get; set; }
        public List<SelectUnitCourse> SelectUnitCourses { get; set; }
        public SelectUnit(DateTime started , DateTime ended , int limit)
        {
            Started = started;
            Ended = ended;
            Limit = limit;
        }
    }
}
