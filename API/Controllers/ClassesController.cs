using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassesController : ControllerBase
    {
        private readonly ILogger _logger;

        public ClassesController(ILogger<ClassesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetClasses")]
        public async Task<IActionResult> GetClasses()
        {
            List<ClassesModel> list = new List<ClassesModel>();
            list = await ClassesService.GetAll();
            return Ok(list);
        }
    }
}
