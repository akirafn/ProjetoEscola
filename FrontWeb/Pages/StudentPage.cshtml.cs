using FrontWeb.Models;
using FrontWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontWeb.Pages
{
    public class StudentPageModel : PageModel
    {
        private readonly ILogger<StudentPageModel> logger;
        public List<StudentCompleteModel> list;
        public List<DegreesModel> degrees;
        public List<ClassesModel> classes;
        public int stDegree;
        public int stClass;

        public StudentPageModel(ILogger<StudentPageModel> logger)
        {
            this.logger = logger;
            this.list = new List<StudentCompleteModel>();
            this.degrees = new List<DegreesModel>();
            this.classes = new List<ClassesModel>();
            this.stClass = 0;
            this.stDegree = 0;
        }
        public async Task OnGetAsync()
        {
            this.list = await StudentsService.GetStudentsByFilter(0, 0);
            this.degrees = await DegreesService.GetAll();
            this.classes = await ClassesService.GetAll();
        }

        public async Task GetStudentByFilter(int studentDegree, int studentClass)
        {
            this.list = await StudentsService.GetStudentsByFilter(studentDegree, studentClass);
        }
    }
}
