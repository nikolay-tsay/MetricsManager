using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/memorymetrics")]
    public class MemoryMetricsController : Controller
    {
        [HttpGet]
        [Route("read")]
        public IActionResult GetAllMetrics()
        {
            return Ok();
        }
    }
}