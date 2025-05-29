namespace Front.Models
{
    public class StudentsModel
    {
        public int id { get; set; }
        public int ra { get; set; }
        public string name { get; set; }
        public int degreeId { get; set; }
        public int classId { get; set; }

        public StudentsModel() 
        {
            id = 0;
            ra = 0;
            name = string.Empty;
            degreeId = 0;
            classId = 0;
        }
    }

    public class StudentCompleteModel
    {
        public int id { get; set; }
        public int ra { get; set; }
        public string name { get; set; }
        public int degreeId { get; set; }
        public string degreeName { get; set; }
        public int classId { get; set; }
        public string className { get; set; }
    }
}
