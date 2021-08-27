using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/cpumetrics")]
    public class CpuMetricsController : Controller
    {
        [HttpGet]
        [Route("read")]
        public IActionResult GetAllMetrics()
        {
            return Ok();
        }
    }
}