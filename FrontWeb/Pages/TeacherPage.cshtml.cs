using FrontWeb.Models;
using FrontWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontWeb.Pages
{
    public class TeacherPageModel : PageModel
    {
        private readonly ILogger<TeacherPageModel> logger;
        public IList<RelationshipModel> list;

        public TeacherPageModel(ILogger<TeacherPageModel> logger)
        {
            this.logger = logger;
            this.list = new List<RelationshipModel>();
        }

        public async Task OnGetAsync()
        {
            this.list = await TeachersService.GetTeachersByFilter(0, 0);
        }
    }
}
