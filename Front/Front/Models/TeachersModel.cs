namespace Front.Models
{
    public class TeachersModel
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class RelationshipModel
    {
        public int id { get; set; }
        public int teacherId { get; set; }
        public string teacherName { get; set; }
        public int matterId { get; set; }
        public string matterName { get; set; }
        public List<TeacherClassModel> classes { get; set; }
    }
    public class TeacherClassModel
    {
        public int degreeId { get; set; }
        public string degreeName { get; set; }
        public int classId { get; set; }
        public string className { get; set; }
    }
}
