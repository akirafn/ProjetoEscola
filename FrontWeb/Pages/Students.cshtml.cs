using FrontWeb.Models;
using FrontWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontWeb.Pages
{
    public class StudentsModel : PageModel
    {
        private readonly ILogger<StudentsModel> _logger;
        public IList<StudentCompleteModel> studentList { get; set; }
        public StudentsModel(ILogger<StudentsModel> logger)
        {
            this._logger = logger;
            this.studentList = new List<StudentCompleteModel>();
        }
        public async Task OnGetAsync()
        {
            studentList = await StudentsService.GetStudentsByFilter(0, 0);
        }
    }
}
