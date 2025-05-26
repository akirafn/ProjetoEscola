namespace API.Models
{
    public class ClassesModel
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class ClassSimpleModel
    {
        public string name { get; set; }
    }

    public class ClassListModel
    {
        public List<ClassSimpleModel> classes { get; set; }
    }
}
