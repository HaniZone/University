namespace University.Core.Models
{
    public class Field
    {
        public int FieldId { get; set; }
        public string FieldName { get; set; }

        public string SectionName { get; set; }
        public int MinUnit { get; set; }
        public int MaxUnit { get; set; }
        public List<Student> Students { get; set; }

        

        public Field(string fieldName , string sectionName , int minUnit , int maxUnit )
        {
            FieldName = fieldName;
            SectionName = sectionName;
            MinUnit = minUnit;
            MaxUnit = maxUnit;
        }

    }
}
