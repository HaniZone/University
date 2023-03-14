namespace University.Core.Models
{
    public class SelectUnitDto
    {
        public int SelectUnitId { get; set; }
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }
        public int Limit { get; set; }
    }
}
