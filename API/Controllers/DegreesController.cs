using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DegreesController : ControllerBase
    {
        private readonly ILogger _logger;

        public DegreesController(ILogger<DegreesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetDegrees")]
        public async Task<IActionResult> GetDegrees()
        {
            List<DegreesModel> degrees = await DegreesService.GetAll();
            return Ok(degrees);
        }
    }
}
