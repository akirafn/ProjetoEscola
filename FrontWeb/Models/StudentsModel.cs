namespace FrontWeb.Models
{
    public class StudentsModel
    {
        public int id { get; set; }
        public int ra { get; set; }
        public string name { get; set; }
        public int degreeId { get; set; }
        public int classId { get; set; }
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
