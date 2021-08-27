using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/diskmetrics")]
    public class PhysicalDiskMetricsController : Controller
    {
        [HttpGet]
        [Route("read")]
        public IActionResult GetAllMetrics()
        {
            return Ok();
        }
    }
}