using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger _logger;
        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetStudentsAll")]
        public async Task<IActionResult> GetStudentsAll()
        {
            List<StudentsModel> list = await StudentsService.GetAll();
            return Ok(list);
        }

        [HttpGet("GetStudentsByFilter/{degreeId}/{classId}")]
        public async Task<IActionResult> GetStudentsByFilter(int degreeId, int classId)
        {
            List<StudentCompleteModel> list = await StudentsService.GetStudentsByFilter(degreeId, classId);
            return Ok(list);
        }
    }
}
