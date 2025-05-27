using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ILogger _logger;
        public TeachersController(ILogger<TeachersController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetTeachersAll")]
        public async Task<IActionResult> GetTeachersAll()
        {
            List<RelationshipModel> list = await TeachersService.GetAll();
            return Ok(list);
        }

        [HttpGet("GetTeachersByFilter/{degreeId}/{classId}")]
        public async Task<IActionResult> GetTeachersByFilter(int degreeId, int classId)
        {
            List<RelationshipModel> list = await TeachersService.GetByFilter(degreeId, classId);
            return Ok(list);
        }
    }
}
